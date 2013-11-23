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
	public class DrawSpritesSample : GameScene
	{
		private SpriteUV description;
		private SpriteForTouchList ball{get;set;}
		private byte ballSpriteNum = 8;
		private float rollBallNum = 48f;
		
		public DrawSpritesSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			description = WriteString.DrawSprite("十字キー:移動/BallをTouch:色の変更" +
				"/Start:戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			
			//画像のセット
			List<SpriteForTouch> ballList = new List<SpriteForTouch>();
			SpriteForTouch[] ballSpriteForTouch = new SpriteForTouch[this.ballSpriteNum];
			for(int i = 0; i < this.ballSpriteNum; i++) {
				ballSpriteForTouch[i] = new SpriteForTouch();
			}
			ballSpriteForTouch[0].DrawSprite("ball_blue_top.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[1].DrawSprite("ball_blue_right.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[2].DrawSprite("ball_blue_down.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[3].DrawSprite("ball_blue_left.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[4].DrawSprite("ball_red_top.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[5].DrawSprite("ball_red_right.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[6].DrawSprite("ball_red_down.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			ballSpriteForTouch[7].DrawSprite("ball_red_left.png", 9*Const.FIX, 4*Const.FIX,96f,96f);
			foreach (SpriteForTouch temp in ballSpriteForTouch) {
				ballList.Add(temp);
			}
			this.ball = new SpriteForTouchList(ballList,true);
			this.ball.AddToScene(scene);
			this.ballSpriteNum = this.ball.SetVisible(4);
			//画像のセットここまで
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			
			
			//touchアクション
			if (InputDevice.TouchPanel(this.touchStatus)){
				if (this.ball.TouchSprite(touchData)){
					this.ballSpriteNum += 4;
					if (7 < ballSpriteNum) {
						this.ballSpriteNum -= 8;
					}
					this.ball.SetVisible(this.ballSpriteNum);
				}
			}
			
			this.touchStatus = (byte)InputDevice.TOUCH_STATUS.TOUCH_NOT; //touchが全部終わったら書く
			
			
			if(InputDevice.UpKeyRepeat()){
				MoveSprite.Up(this.ball,this.ball.Sprites[this.ballSpriteNum].Sprite.Quad.S.X/20);
			}
			if(InputDevice.DownKeyRepeat()){
				MoveSprite.Down(this.ball,this.ball.Sprites[this.ballSpriteNum].Sprite.Quad.S.X/20);
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
				MoveSprite.Left(this.ball,this.ball.Sprites[this.ballSpriteNum].Sprite.Quad.S.X/20);
				if(this.rollBallNum < (this.ball.BeforeX - this.ball.Sprites[this.ballSpriteNum].Sprite.Quad.T.X)) {
					this.ballSpriteNum--;
					if (ballSpriteNum == 255) {
						this.ballSpriteNum = 3;
					} else if (ballSpriteNum == 3) {
						this.ballSpriteNum = 7;
					}
					this.ball.SetVisible(this.ballSpriteNum);
				}
			}
			if(InputDevice.RightKeyRepeat()){
				MoveSprite.Right(this.ball,this.ball.Sprites[this.ballSpriteNum].Sprite.Quad.S.X/20);
				if(this.rollBallNum < (this.ball.Sprites[this.ballSpriteNum].Sprite.Quad.T.X - this.ball.BeforeX)) {
					this.ballSpriteNum++;
					if (ballSpriteNum == 4) {
						this.ballSpriteNum = 0;
					} else if(ballSpriteNum == 8){
						this.ballSpriteNum = 4;
					}
					this.ball.SetVisible(this.ballSpriteNum);
				}
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
		}//Terminate
		
	}//class SceneSample3
}//namespace ApmFw

