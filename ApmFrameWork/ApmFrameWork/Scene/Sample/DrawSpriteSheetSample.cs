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
	public class DrawSpriteSheetSample : GameScene
	{
		private SpriteUV description;
		private DrawPlayerSheetSample drawPlayerSheet = null;
		private SpriteTile spritePlayerSheet;

		public DrawSpriteSheetSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			
			scene.Camera.SetViewFromViewport();
				
			description = WriteString.DrawSprite("左右キー:移動/" +
				"x:画面から消す/Start:戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			
			//SpriteSheet画像描画クラス
			this.drawPlayerSheet = new DrawPlayerSheetSample(10*Const.FIX,9*Const.FIX,
			                                                 1,1,
			                                                 "walk.png","walk.xml",this.scene);
			this.spritePlayerSheet = this.drawPlayerSheet.DrawPlayer("init");
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			
			
			if(InputDevice.UpKeyRepeat()){
			}
			if(InputDevice.DownKeyRepeat()){
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
				this.spritePlayerSheet.Quad.T.X -= this.spritePlayerSheet.Quad.S.X/20;
				drawPlayerSheet.DrawPlayer("left"); //左向きに歩かせる
				drawPlayerSheet.CountSpriteOffset(); //動かすのに必要な数字をプラスする
			}
			if(InputDevice.RightKeyRepeat()){
				this.spritePlayerSheet.Quad.T.X += this.spritePlayerSheet.Quad.S.X/20;
				drawPlayerSheet.DrawPlayer("right"); //右向きに歩かせる
				drawPlayerSheet.CountSpriteOffset(); //動かすのに必要な数字をプラスする
			}
			
			//LボタンはQ
			if(InputDevice.LButton()){
			}
			
			//RボタンはE
			if(InputDevice.RButton()){
			}
			
			//四角ボタンはA
			if(InputDevice.SquareButton()){
			}
			//三角ボタンはW
			if(InputDevice.TriangleButton()){
			}
			//バツボタンはS
			if(InputDevice.CrossButton()){
				this.spritePlayerSheet.Visible = !this.spritePlayerSheet.Visible;
			}
			//丸ボタンはD
			if(InputDevice.CircleButton()){
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
			drawPlayerSheet = null;
			spritePlayerSheet = null;
		}//Terminate
		
	}//class SceneSample1
}//namespace ApmFw

