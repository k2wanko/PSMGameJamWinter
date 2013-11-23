// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Timers;//timer

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Audio;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using ApmFw;

namespace ApmFw
{
	public class APMGameFramework
	{
		//使うシーン
		protected GameScene sceneClass;
		private GameScene preSceneClass;
		private Scene scene;
		
		private System.Timers.Timer mainTimer;//timer
		
//#if DEBUG
		protected SpriteUV debugGrid;
		protected Boolean debugStartFlag = true;
		protected Boolean debugMode = false;
//#endif
		private readonly Boolean UPDATE = true;
		private readonly Boolean RENDER = false;
		
		private Random rand = new Random(123);
		
		private long appCounter=0;
		
		GamePadData gamePadData;
		
		protected bool loop = true;
		protected bool drawDebugString = true;
		
		Stopwatch stopwatch;
		const int pinSize=3;
		int[] time= new int[pinSize];
		int[] preTime= new int[pinSize];
		float[] timePercent= new float[pinSize];
		
		
		protected Texture2D textureFont;
		
		protected GraphicsContext graphics;
		
		protected GraphicsContext Graphics 
		{ 
			get {return graphics;}
		}
		
		protected GamePadData PadData 
		{ 
			get { return gamePadData;}
		}
		
		virtual protected void SetFirstScene() {
			this.sceneClass = new MainMenuSample();
		}
		
		virtual protected void Initialize()
		{
			
			Director.Initialize();
			Const.Set_DISPLAY();
			
			this.stopwatch = new Stopwatch();
			this.stopwatch.Start();
			
			//NowLoading
			NowLoading.NowLoadingInisialize();
			//最初のシーン
			this.SetFirstScene();
			this.preSceneClass = this.sceneClass;//前のシーンを今のシーンに
			GameLog.DebugLog.Log("Start -> Initialize : " + this.sceneClass.GetType().Name);
			this.scene = this.sceneClass.Initialize();
			GameLog.DebugLog.Log("  End -> Initialize : " + this.sceneClass.GetType().Name);
			
			Director.Instance.RunWithScene(this.scene,true);
			
			this.NewTimer();//timerStart
#if DEBUG
			this.debugGrid = DrawPicture.DrawSprite("VitaGrid.png", 0, 0,
			                                        Const.DISPLAY_WIDTH,
			                                        Const.DISPLAY_HEIGHT-16);
#endif
		}
		
		
		protected void Input()
		{
			gamePadData = GamePad.GetData(0);
			
		}	
		
		
		public void Run(string[] args)
		{
			Initialize();
			//sceneNow = testScene.Initialize();
			//Director.Instance.RunWithScene(sceneNow,true); 
			
			while (loop)
			{
				this.time[0] = (int)stopwatch.ElapsedTicks;// start
				SystemEvents.CheckEvents();
				this.TouchPanelUI();
				this.Update();
				this.time[1] = (int)stopwatch.ElapsedTicks;
				this.Render();

				this.MyDebug();

			}
			this.Terminate();
		}
		
		//file:///C:/Documents%20and%20Settings/All%20Users/Documents/PSM/doc/ja/structSce_1_1PlayStation_1_1Core_1_1Input_1_1TouchData.html
		protected void TouchPanelUI(){
			InputDevice.TouchPanelUI(this.sceneClass, appCounter);
		}
		
		
		protected void Update()
		{
			//base.Update();
			//debugString.Clear();
			
			this.Input();
			
			//四角ボタンはA
			if(InputDevice.SquareButton()){
				//セリフの自動化ON,OFF
				Const.VOICE_AUTO = !Const.VOICE_AUTO;
			}
			
			//丸ボタンはD
			if(InputDevice.CircleButton()){
				Const.GLOBAL_O_BTN = true;
			}
			
			//@j StartボタンとSelectボタンの同時押しでプログラムを終了します。
			//@e Terminate a program with simultaneously pressing Start button and Select button.
#if DEBUG			
			if((gamePadData.Buttons & GamePadButtons.Start) != 0 &&  (gamePadData.Buttons & GamePadButtons.Select) != 0)
			{
				Console.WriteLine("exit."); 
				this.loop = false;
				return;
			}
			
			// Z key
			if((gamePadData.ButtonsDown & GamePadButtons.Select) != 0)
			{
				if(debugMode == true){
					this.debugMode=false;
					this.RemoveMyDebug();
				}else{
					this.debugMode=true;
					this.debugStartFlag = true;
				}
			}
#endif
			
			this.CalculateProcessTime();
			
			this.ChangeNextScene();
			
			this.UpdateAndRender(this.UPDATE);
			
			++this.appCounter;
		}
		
		protected void ChangeNextScene(){
			if(Const.ChangeScene){
				this.RemoveMyDebug();
				if(Director.Instance.CurrentScene.IsRunning){
					this.ChooseNextScene();
				
					GameLog.DebugLog.Log("Start -> Initialize : " + this.sceneClass.GetType().Name);
					this.scene = this.sceneClass.Initialize();//sceneを交換
					GameLog.DebugLog.Log("  End -> Initialize : " + this.sceneClass.GetType().Name);
					
					Director.Instance.ReplaceScene( new TransitionSolidFade( this.scene )
							{ Duration = 1.0f, Tween = (x) => Sce.PlayStation.HighLevel.GameEngine2D.Base.Math.PowEaseOut( x, 3.0f )} );
#if DEBUG
					debugStartFlag = true;
#endif
				}
				//terminate
				GameLog.DebugLog.Log("Start -> Terminate : " + this.preSceneClass.GetType().Name);
				this.preSceneClass.Terminate();//前のシーンの終了処理
				GameLog.DebugLog.Log("  End -> Terminate : " + this.preSceneClass.GetType().Name);
				this.preSceneClass = null;
				NowLoading.RemoveNowLoading();
				GC.Collect();//強制的にすべてのジェネレーションのガベージ コレクションを行う
				GC.WaitForPendingFinalizers();
				GC.Collect();
				this.preSceneClass = this.sceneClass;//前のシーンを今のシーンに
			}
			
			Const.ChangeScene = false;
		}
		
		protected void UpdateAndRender(Boolean updateOrRender){		
			if(updateOrRender) {
				//Updateだけ最初(残りの必要な実行は最後)
				Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Update();
				this.sceneClass.Update();
			} else {
				this.sceneClass.Render();
			}
		}
		
		
		protected void Render()
		{
			this.UpdateAndRender(this.RENDER);

			this.time[2] = (int)stopwatch.ElapsedTicks;
			
			this.preTime=(int[])time.Clone();
		}
		
		protected void Dispose()
		{
		}
		
		protected void Terminate()
		{
			Director.Terminate();
		}
		
		/// <summary>
		/// 処理にかかった時間を計算する。
		/// </summary>
		void CalculateProcessTime()
		{
			float fps = 60.0f;
			
			float ticksPerFrame = Stopwatch.Frequency / fps;	
			this.timePercent[0]=(this.preTime[1]-this.preTime[0])/ticksPerFrame;
			this.timePercent[1]=(this.preTime[2]-this.preTime[1])/ticksPerFrame;
		}
		
		[Conditional ("DEBUG")]
		virtual protected void MyDebug(){
			//UpdateやRenderが100%を超えたら処理落ち
			if(this.debugMode == true){
				//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
				if(this.debugStartFlag){
					this.RemoveMyDebug();
					this.scene.AddChild(this.debugGrid);
					this.debugStartFlag = false;
				}
				
			}
		}//MyDebug()
		
		[Conditional ("DEBUG")]
		virtual protected void RemoveMyDebug(){
			this.scene.RemoveChild(this.debugGrid, true);
		}//RemoveMyDebug()
		
		/// <summary>
		/// Chooses the next scene.
		/// シーン名をすべて書いて場合わけ
		/// </summary>
		void ChooseNextScene(){
			if (Const.Nextscene != null){
				this.sceneClass = Const.Nextscene();
			}
			
		}
		
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// My timer.
		/// 0.1秒ごとに呼び出し
		/// </summary>
		protected void NewTimer(){
			this.mainTimer = null;
			this.mainTimer = new System.Timers.Timer();
			this.mainTimer.Enabled = true;
			this.mainTimer.AutoReset = true;
			this.mainTimer.Interval = 1000;//1秒ごとに呼び出し
			this.mainTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
		}

		private void OnTimerEvent(object source, ElapsedEventArgs e){
			Const.TIME_COUNT++;
			if(NowLoading.NowLoadingFlag){
				NowLoading.MoveDot();
			}
		}

		protected void StartTimer(){
			mainTimer.Start();
		}

		protected void StopTimer(){
			Const.TIME_COUNT = 0;
			mainTimer.Stop();
		}
		
	}
}


