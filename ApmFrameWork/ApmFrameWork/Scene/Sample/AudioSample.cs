// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;


namespace ApmFw
{
	/// <summary>
	/// Scene sample2.
	/// </summary>
	public class AudioSample : GameScene
	{
		private SpriteUV description;
		private SoundPlayer soundPlayer;
		
		public AudioSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			//sceneはオブジェクトの追加や削除のためにも描画メソッドの外で作ったほうが良い
			
			scene.Camera.SetViewFromViewport();
			
			description = WriteString.DrawSprite("上下キー:ピッチ/左右キー:volume/L:BgmStop/R:BgmStart" +
				"/○:効果音/Start:戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			
			//効果音のセット
			this.soundPlayer = Audio.SetEffect("/Application/sound/Bullet.wav");
			//Bgmのセット
			Audio.SetBgm("/Application/sound/GameBgm.mp3");
			Audio.StartBgm();
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			
			
			if(InputDevice.UpKey()){
				Audio.PitchChangeBgm(0.2f);
			}
			if(InputDevice.DownKey()){
				Audio.PitchChangeBgm(-0.2f);
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKey()){
				Audio.VolumeChangeBgm(-0.1f);
			}
			if(InputDevice.RightKey()){
				Audio.VolumeChangeBgm(0.1f);
			}
			
			//LボタンはQ
			if(InputDevice.LButton()){
				Audio.StopBgm();
			}
			
			//RボタンはE
			if(InputDevice.RButton()){
				Audio.StartBgm();
			}
			
			//四角ボタンはA
			if(InputDevice.SquareButtonRepeat()){
			}
			//三角ボタンはW
			if(InputDevice.TriangleButton()){
			}
			//バツボタンはS
			if(InputDevice.CrossButton()){
			}
			//丸ボタンはD
			if(InputDevice.CircleButtonRepeat()){
				this.soundPlayer.Play();
			}
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
				ChangeScene( () => {return new MainMenuSample();} );
			}
		}//Update()
		
		/// <summary>
		/// Terminate of Scene.
		/// </summary>
		public override void Terminate(){
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			Audio.StopBgm();
			this.soundPlayer.Dispose();
			scene = null;
		}//Terminate
		
	}//class SceneSample2
}//namespace ApmFw


