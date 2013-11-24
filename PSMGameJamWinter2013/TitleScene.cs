using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;


using ApmFw;
namespace PSMGameJamWinter2013
{
	public class TitleScene : GameScene
	{
		public TitleScene ()
		{
		}
		
		private int count = 0;
		private bool circleBtnOn = false;
		private int setumeiNum = 1;
		
		private SpriteForTouch title = new SpriteForTouch();
		private SpriteForTouch cursor = new SpriteForTouch();
		private SpriteForTouch background0 = new SpriteForTouch();
		private SpriteForTouch background1 = new SpriteForTouch();
		private SpriteForTouch background2 = new SpriteForTouch();
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
			background0.DrawSprite("taitoru.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
			
			background1.DrawSprite("setsumei.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
			background1.Sprite.Visible = false;
			
			background2.DrawSprite("none.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
			background2.Sprite.Visible = false;
			
			
//			title.DrawSprite("○ボタンスタート！",
//									380,
//									344,
//									50,
//									new ImageColor(255,255,255,255),
//									scene,
//			                       	false);
			
//			cursor.DrawSprite("cursorRight.png",
//									330,
//									344,
//									50,
//									50,
//									scene,
//			                       	false);
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			if (this.circleBtnOn) {
				this.count ++;
				if (this.count < 400) {
					background1.Sprite.Visible = true;
				} else if (this.count < 800) {
					background1.Sprite.Visible = false;
					background2.Sprite.Visible = true;
				} else {
					ChangeScene( () => {return new MockScene();} );
				}
			}
			
			if(InputDevice.UpKeyRepeat()){
				
			}
			if(InputDevice.DownKeyRepeat()){
				
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
				
			}
			if(InputDevice.RightKeyRepeat()){
				
			}
			
			//LボタンはQ
			if(InputDevice.LButton()){
			}
			
			//RボタンはE
			if(InputDevice.RButton()){
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
			if(InputDevice.CircleButton()){
				this.circleBtnOn = true;
//				ChangeScene( () => {return new MockScene();} );
//				ChangeScene( () => {return new MainScene();} );
			}
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
				
			}
			
		}//Update()
		
		/// <summary>
		/// Terminate of Scene.
		/// </summary>
		public override void Terminate(){
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			scene = null;
			title = null;
		}//Terminate
		
	}
}

