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
	public class SingletonDrawSpriteUpdateSample : SingletonBaseSample
	{
		
		
		public SingletonDrawSpriteUpdateSample ()
		{
		}
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			
			
			if(InputDevice.UpKeyRepeat()){
				SS.SpritePicture.Quad.T.Y += SS.SpritePicture.Quad.S.Y/10;
				if((Const.DISPLAY_HEIGHT - SS.SpritePicture.Quad.S.Y) < SS.SpritePicture.Quad.T.Y) SS.SpritePicture.Quad.T.Y -= SS.SpritePicture.Quad.S.Y/10;
			}
			if(InputDevice.DownKeyRepeat()){
				SS.SpritePicture.Quad.T.Y -= SS.SpritePicture.Quad.S.Y/10;
				if(SS.SpritePicture.Quad.T.Y < 0) SS.SpritePicture.Quad.T.Y += SS.SpritePicture.Quad.S.Y/10;
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
				MoveSprite.Left(SS.SpritePicture,SS.SpritePicture.Quad.S.X/10);
				if(SS.SpritePicture.Quad.T.X < 0) {
					MoveSprite.Right(SS.SpritePicture,(float)(SS.SpritePicture.Quad.S.X/10));
				}
			}
			if(InputDevice.RightKeyRepeat()){
				MoveSprite.Right(SS.SpritePicture,SS.SpritePicture.Quad.S.X/10);
				if((Const.DISPLAY_WIDTH-SS.SpritePicture.Quad.S.X) < SS.SpritePicture.Quad.T.X) {
					MoveSprite.Left(SS.SpritePicture,SS.SpritePicture.Quad.S.X/10);
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
				MoveSprite.Stretch(SS.SpritePicture,-10.0f,-10.0f);
			}
			//三角ボタンはW
			if(InputDevice.TriangleButton()){
				MoveSprite.SetScale(SS.SpritePicture,64f,64f);
			}
			//バツボタンはS
			if(InputDevice.CrossButton()){
				SS.SpritePicture.Visible = !SS.SpritePicture.Visible;
			}
			//丸ボタンはD
			if(InputDevice.CircleButtonRepeat()){
				MoveSprite.Stretch(SS.SpritePicture,10.0f,10.0f);
			}
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
				ChangeScene( () => {return new MainMenuSample();} );
			}
			
		}//Update()
		
	}//class SceneSample0
}//namespace ApmFw

