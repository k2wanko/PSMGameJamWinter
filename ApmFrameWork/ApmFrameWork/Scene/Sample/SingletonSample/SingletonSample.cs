// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic; //List

//save
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using System.Timers; //timer

using ApmFw;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using System.Diagnostics; //[Conditional ("DEBUG")]



namespace ApmFw
{
	public class SingletonSample
	{
		
		public static SingletonSample SS;
		
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <returns>
		/// The instance.
		/// </returns>
		public static SingletonSample getInstance ()
		{
			if (SingletonSample.SS == null){
				SingletonSample.SS = new SingletonSample();
			}
			
			return SingletonSample.SS;
		}
		
		private SingletonSample () {
			//コンストラクタ
			this.scene = new Scene();
			
			this.startMainTime=0;
			this.playTime=0;
			this.playTimeSaveData=0;
		}
		
		public SpriteUV SpritePicture{get;set;}
		public SpriteUV Description{get;set;}
		
		//共通
		public Scene scene{get;set;}
		public TouchData touchData{get;set;}
		public byte touchStatus{get;set;}
		
		public System.Timers.Timer myTimer{get;set;}//timer
		public int startMainTime{get;set;}
		public int playTime{get;set;}
		public int playTimeSaveData{get;set;}
		
		public int counter{get;set;}
		
		//timer
		public byte timerFlag{get;set;}
		
		//MethodClass 一覧
		public SingletonDrawSpriteInitializeSample SingletonDrawSpriteInitialize{get;set;}
		public SingletonDrawSpriteUpdateSample SingletonDrawSpriteUpdate{get;set;}
		
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initialize SS.instance.
		/// </summary>
		public Scene Initialize(){
			//必要なクラスをnewする（コンストラクタでやると無限ループに陥る）
			SS.SingletonDrawSpriteInitialize = new SingletonDrawSpriteInitializeSample();
			SS.SingletonDrawSpriteUpdate = new SingletonDrawSpriteUpdateSample();
			
			return SS.SingletonDrawSpriteInitialize.Initialize();
		}//Initialize()
		
		/// <summary>
		/// Update SS.instance.
		/// </summary>
		public void Update(){
			
			
			
			SS.SingletonDrawSpriteUpdate.Update();
		}//Update()
	
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		public void changeScene(NextScene next){
			Const.ChangeScene = true;
			Const.Nextscene = next;
			NowLoading.NOW_LOADING(this.scene);
		}
		
		public void setTouchData(TouchData touchData, byte touchStatus){
			SS.touchData = touchData;
			SS.touchStatus = touchStatus;
		}
		
		public void Render(){
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Render();
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.SwapBuffers();
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.PostSwap();
		}
		
			
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// My timer.
		/// 0.1秒ごとに呼び出し
		/// </summary>
		public void NewTimer(){
			myTimer = null;
			myTimer = new System.Timers.Timer();
			myTimer.Enabled = true;
			myTimer.AutoReset = true;
			myTimer.Interval = 100;//0.1秒ごとに呼び出し
			myTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
		}

		public void OnTimerEvent(object source, ElapsedEventArgs e){
			SS.counter++;
		}

		public void StartTimer(){
			myTimer.Start();
		}

		public void StopTimer(){
			SS.counter = 0;
			SS.timerFlag = 0;
			myTimer.Stop();
		}
		
		//タイマーが死んでたらスタートさせる
		public void CheckTimer(){
			SS.timerFlag++;
			if(50 < SS.timerFlag && counter == 0){
				SS.NewTimer();
				SS.StartTimer();
			}
		}
		
		public void Terminate() {
			SingletonSample.SS = null;
		}
	}
}

