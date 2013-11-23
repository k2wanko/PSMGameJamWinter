// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;


namespace ApmFw
{
	/// <summary>
	/// Scene sample.
	/// </summary>
	public class DrawSpriteSample : GameScene
	{
		private SpriteUV description;
		private SpriteUV spritePicture;
		
		public DrawSpriteSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
			description = WriteString.DrawSprite("十字キー:移動/○・□:拡大縮小/△:サイズのリセット/" +
				"x:画面から消す/Start:戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			spritePicture = DrawPicture.DrawSprite("Player.png", 10f*Const.FIX, 5f*Const.FIX,scene);
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			
			
			if(InputDevice.UpKeyRepeat()){
				spritePicture.Quad.T.Y += spritePicture.Quad.S.Y/10;
				if((Const.DISPLAY_HEIGHT - spritePicture.Quad.S.Y) < spritePicture.Quad.T.Y) spritePicture.Quad.T.Y -= spritePicture.Quad.S.Y/10;
			}
			if(InputDevice.DownKeyRepeat()){
				spritePicture.Quad.T.Y -= spritePicture.Quad.S.Y/10;
				if(spritePicture.Quad.T.Y < 0) spritePicture.Quad.T.Y += spritePicture.Quad.S.Y/10;
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
				MoveSprite.Left(spritePicture,spritePicture.Quad.S.X/10);
				if(spritePicture.Quad.T.X < 0) {
					MoveSprite.Right(spritePicture,(float)(spritePicture.Quad.S.X/10));
				}
			}
			if(InputDevice.RightKeyRepeat()){
				MoveSprite.Right(spritePicture,spritePicture.Quad.S.X/10);
				if((Const.DISPLAY_WIDTH-spritePicture.Quad.S.X) < spritePicture.Quad.T.X) {
					MoveSprite.Left(spritePicture,spritePicture.Quad.S.X/10);
				}
			}
			
			//LボタンはQ
			if(InputDevice.LButton()){
			}
			
			//RボタンはE
			if(InputDevice.RButton()){
			}
			
			//四角ボタンはA
			if(InputDevice.SquareButtonRepeat()){
				MoveSprite.Stretch(spritePicture,-10.0f,-10.0f);
			}
			//三角ボタンはW
			if(InputDevice.TriangleButton()){
				MoveSprite.SetScale(spritePicture,64f,64f);
			}
			//バツボタンはS
			if(InputDevice.CrossButton()){
				spritePicture.Visible = !spritePicture.Visible;
			}
			//丸ボタンはD
			if(InputDevice.CircleButtonRepeat()){
				MoveSprite.Stretch(spritePicture,10.0f,10.0f);
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
			scene = null;
			spritePicture = null;
		}//Terminate
		
	}//class SceneSample0
}//namespace ApmFw

