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
	public class MainMenuSample : GameScene
	{
		public MainMenuSample ()
		{
		}
		
		private SpriteUV spriteCursor;
		
		private SpriteForTouch[] spriteSampleTouch{get;set;}
		private Boolean touchedOBtn = false;
		private Boolean oBtnAlready = false;
		private int cursorPositionY = 0;
		private int cursorPositionX = 0;
		private Boolean firstAction = true;
		private SpriteForTouch xBtn; //戻るボタン
		private Boolean touchedXBtn = false;
		private Boolean xBtnAlready = false;
		
		private String flagOfUpdate = "first"; //Updateのメソッドを選択
		private String flagFromUpdate; //どのUpdateメソッドから来たかを記録
		
		public override Scene Initialize(){
			//sceneはオブジェクトの追加や削除のためにも描画メソッドの外で作ったほうが良い
			
			scene.Camera.SetViewFromViewport();
			
			//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
			spriteCursor = DrawPicture.DrawSprite("cursorRight.png", 0*Const.FIX, 1*Const.FIX, Const.GRID_SIZE*Const.FIX, Const.GRID_SIZE*Const.FIX,scene);
			
			int menuNum = 10;
			spriteSampleTouch = new SpriteForTouch[menuNum];
			for(int i = 0; i < menuNum ; i++){
				spriteSampleTouch[i] = new SpriteForTouch();
			}
			
			//文字の描画 960x544 //vita画面解像度 20x11.25(左上)
			spriteSampleTouch[0].DrawSprite("DrawSpriteSample",
										1*Const.FIX,
										0.6f*Const.FIX,
										Const.FONT_SIZE_TOUCH,
										new ImageColor(255,255,255,255),
										scene,
			                             true);
			spriteSampleTouch[1].DrawSprite("DrawSpriteSheetSample",
										1*Const.FIX,
										1.6f*Const.FIX,
										Const.FONT_SIZE_TOUCH,
										new ImageColor(255,255,255,255),
										scene,
			                             true);
			spriteSampleTouch[2].DrawSprite("DrawSpritesSample",
											1*Const.FIX,
											2.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
											scene,
			                             true);
			spriteSampleTouch[3].DrawSprite("TouchSample",
											1*Const.FIX,
											3.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
											scene,
			                             true);
			spriteSampleTouch[4].DrawSprite("AudioSample",
											1*Const.FIX,
											4.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
											scene,
			                                true);
			spriteSampleTouch[5].DrawSprite("SaveAndLoadSample",
											1*Const.FIX,
											5.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
											scene,
			                                true);
			spriteSampleTouch[6].DrawSprite("NovelSceneSample",
											1*Const.FIX,
											6.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
											scene,
			                                true);
			spriteSampleTouch[7].DrawSprite("Continue",
											12*Const.FIX,
											5.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
			                                scene,
			                               true);
			spriteSampleTouch[8].DrawSprite("New",
											12*Const.FIX,
											6.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
			                                scene,
			                                true);
			spriteSampleTouch[9].DrawSprite("SingletonSceneSample",
											1*Const.FIX,
											7.6f*Const.FIX,
											Const.FONT_SIZE_TOUCH,
											new ImageColor(255,255,255,255),
											scene,
			                                true);
			
			//戻るボタン
			xBtn = Const.XBtn(scene);
			
			return scene;

		}//Initialize()
		
		
		public override void Update(){
			
			
			
			switch(flagOfUpdate){
			case "first": //起動時につくところ
				this.firstUpdate();
				break;
			case "selectSaveAndLoad":
				this.selectStoryUpdate();
				break;
			}
		}//Update()
		
		private void firstUpdate(){
			if(this.firstAction){
				GameLog.DebugLog.StartMethod();
				
				cursorPositionY = 0;
				cursorPositionX = 0;
				
				MoveSprite.SetPositonGridY(spriteCursor,1*Const.FIX);
				MoveSprite.SetPositonGridX(spriteCursor,0*Const.FIX);
				
				this.spriteSampleTouch[7].Sprite.Visible = false;
				this.spriteSampleTouch[8].Sprite.Visible = false;
				
				this.xBtn.Sprite.Visible = false;
				
				this.firstAction = false;
			}
			
			if (InputDevice.TouchDown(this.touchStatus)){
				if (spriteSampleTouch[0].TouchSprite(this.touchData)){
					cursorPositionY = 0;
					MoveSprite.SetPositonGridY(spriteCursor,1*Const.FIX);
				}else if (spriteSampleTouch[1].TouchSprite(this.touchData)){
					cursorPositionY = 1;
					MoveSprite.SetPositonGridY(spriteCursor,2*Const.FIX);
				}else if (spriteSampleTouch[2].TouchSprite(touchData)){
					cursorPositionY = 2;
					MoveSprite.SetPositonGridY(spriteCursor,3*Const.FIX);
				}else if (spriteSampleTouch[3].TouchSprite(touchData)){
					cursorPositionY = 3;
					MoveSprite.SetPositonGridY(spriteCursor,4*Const.FIX);
				}else if (spriteSampleTouch[4].TouchSprite(touchData)){
					cursorPositionY = 4;
					MoveSprite.SetPositonGridY(spriteCursor,5*Const.FIX);
				}else if (spriteSampleTouch[5].TouchSprite(touchData)){
					cursorPositionY = 5;
					MoveSprite.SetPositonGridY(spriteCursor,6*Const.FIX);
				}else if (spriteSampleTouch[6].TouchSprite(touchData)){
					cursorPositionY = 6;
					MoveSprite.SetPositonGridY(spriteCursor,7*Const.FIX);
				}else if (spriteSampleTouch[9].TouchSprite(touchData)){
					cursorPositionY = 7;
					MoveSprite.SetPositonGridY(spriteCursor,8*Const.FIX);
				}
			}else
			if (InputDevice.TouchPanel(this.touchStatus)){
				
				if (spriteSampleTouch[0].TouchSprite(this.touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[1].TouchSprite(this.touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[2].TouchSprite(touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[3].TouchSprite(touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[4].TouchSprite(touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[5].TouchSprite(touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[6].TouchSprite(touchData)){
					this.touchedOBtn = true;
				}else if (spriteSampleTouch[9].TouchSprite(touchData)){
					this.touchedOBtn = true;
				}
			}
			
			this.touchStatus = (byte)InputDevice.TOUCH_STATUS.TOUCH_NOT; //touchが全部終わったら書く
			
			//UPボタン
			if(InputDevice.UpKeyRepeat()){
				MoveSprite.Up(spriteCursor,Const.GRID_SIZE*Const.FIX);
				cursorPositionY--;
				if(cursorPositionY < 0){
					MoveSprite.Down(spriteCursor,Const.GRID_SIZE*Const.FIX);
					cursorPositionY++;
				}
				System.Threading.Thread.Sleep(Const.SLEEP_TIME); //sleep
			}
			
			//Downボタン
			if(InputDevice.DownKeyRepeat()){
				MoveSprite.Down(spriteCursor,Const.GRID_SIZE*Const.FIX);
				cursorPositionY++;
				if(7 < cursorPositionY){
					MoveSprite.Up(spriteCursor,Const.GRID_SIZE*Const.FIX);
					cursorPositionY--;
				}
				System.Threading.Thread.Sleep(Const.SLEEP_TIME); //sleep
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
			}
			
			//Rightボタンが押されたとき
			if(InputDevice.RightKeyRepeat()){
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
			if((InputDevice.CircleButton() || touchedOBtn) && !this.oBtnAlready){
				this.touchedOBtn = true;
				this.oBtnAlready = true;
				//TODO scene遷移
				switch(cursorPositionY){
				case 0:
					ChangeScene( () => {return new DrawSpriteSample();} );
					break;
				case 1:
					ChangeScene( () => {return new DrawSpriteSheetSample();} );
					break;
				case 2:
					ChangeScene( () => {return new DrawSpritesSample();} );
					break;
				case 3:
					ChangeScene( () => {return new TouchSample();} );
					break;
				case 4:
					ChangeScene( () => {return new AudioSample();} );
					break;
				case 5:
					this.firstAction = true;
					this.flagFromUpdate = this.flagOfUpdate;
					this.flagOfUpdate = "selectSaveAndLoad";
					GameLog.DebugLog.EndMethod();
					break;
				case 6:
					//ノベルシーンを呼ぶ前に呼び出して左右のキャラと、そのシーン番号を登録する（これで振り分ける）
					Const.LEFTCHARACTER = Const.testVoice;
					Const.RIGHTCHARACTER = Const.testVoice;
					Const.NOVELID = 99999;
					ChangeScene( () => {return new NovelSceneSample();} );
					break;
				case 7:
					ChangeScene( () => {return new SingletonSceneSample();} );
					break;
				default:
					GameLog.DebugLog.Log("err");
					break;
				}
				GameLog.DebugLog.EndMethod("case " + cursorPositionY);
			}
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
			}
				
			// Z keyはSelect
			//連射不可
			if(Input2.GamePad.GetData(0).Select.Release)
			{
			}
			
			///////////
			//初期化
			///////////
			if (!this.touchedOBtn) this.oBtnAlready = false; //丸ボタンから手を離していたら
			this.touchedOBtn = false;
			if (!this.touchedXBtn) this.xBtnAlready = false; //Xボタンから手を離していたら
			this.touchedXBtn = false;
			
		}//firstUpdate()
		
		private void selectStoryUpdate(){
			if(this.firstAction){
				GameLog.DebugLog.StartMethod();
			
				cursorPositionX = 1;
				
				MoveSprite.SetPositonGridX(spriteCursor,11*Const.FIX);
				
				this.spriteSampleTouch[8].Sprite.Visible = true;
				
				if (System.IO.File.Exists("/Documents/sample/saveData.dat")){
					cursorPositionY = 5;
					MoveSprite.SetPositonGridY(spriteCursor,6*Const.FIX);
					this.spriteSampleTouch[7].Sprite.Visible = true;
				
				}else{
					//ファイルがない
					cursorPositionY = 6;
					MoveSprite.SetPositonGridY(spriteCursor,7*Const.FIX);
				}
				this.xBtn.Sprite.Visible = true;
				
				this.firstAction = false;
			}
			
			if (InputDevice.TouchDown(this.touchStatus)){
				if (this.spriteSampleTouch[7].TouchSprite(this.touchData)){
					cursorPositionY = 5;
					MoveSprite.SetPositonGridY(spriteCursor,6*Const.FIX);
				}else if (this.spriteSampleTouch[8].TouchSprite(this.touchData)){
					cursorPositionY = 6;
					MoveSprite.SetPositonGridY(spriteCursor,7*Const.FIX);
				}
			}else
			if (InputDevice.TouchPanel(this.touchStatus)){
				
				if (this.spriteSampleTouch[7].TouchSprite(this.touchData)){
					this.touchedOBtn = true;
				}else if (this.spriteSampleTouch[8].TouchSprite(this.touchData)){
					this.touchedOBtn = true;
				}
				if (xBtn.TouchSprite(this.touchData)){ //Xボタンがタッチされたら
					this.touchedXBtn = true;
				}
			}
			
			this.touchStatus = (byte)InputDevice.TOUCH_STATUS.TOUCH_NOT; //touchが全部終わったら書く
			
			//UPボタン
			if(InputDevice.UpKeyRepeat()){
				MoveSprite.Up(spriteCursor,Const.GRID_SIZE*Const.FIX);
				cursorPositionY--;
				int limitUp = 5;
				if (!System.IO.File.Exists("/Documents/sample/saveData.dat")){limitUp = 6;}
				if(cursorPositionY < limitUp){
					MoveSprite.Down(spriteCursor,Const.GRID_SIZE*Const.FIX);
					cursorPositionY++;
				}
				System.Threading.Thread.Sleep(Const.SLEEP_TIME); //sleep
			}
			
			//Downボタン
			if(InputDevice.DownKeyRepeat()){
				MoveSprite.Down(spriteCursor,Const.GRID_SIZE*Const.FIX);
				cursorPositionY++;
				if(6 < cursorPositionY){
					MoveSprite.Up(spriteCursor,Const.GRID_SIZE*Const.FIX);
					cursorPositionY--;
				}
				System.Threading.Thread.Sleep(Const.SLEEP_TIME); //sleep
			}
			//Leftボタンが押された時& GamePadButtons.Up == GamePadButtons.Up。連射可(Input)
			if(InputDevice.LeftKeyRepeat()){
			}
			
			//Rightボタンが押されたとき
			if(InputDevice.RightKeyRepeat()){
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
			if((InputDevice.CrossButton() || touchedXBtn) && !this.xBtnAlready){
				this.touchedXBtn = true;
				this.xBtnAlready = true;
				
				this.firstAction = true;
				this.flagFromUpdate = this.flagOfUpdate;
				this.flagOfUpdate = "first";
				
				GameLog.DebugLog.EndMethod("back");
			}
			//丸ボタンはD
			if((InputDevice.CircleButton() || touchedOBtn) && !this.oBtnAlready){
				this.touchedOBtn = true;
				this.oBtnAlready = true;
				//scene遷移
				switch(cursorPositionY){
				case 5: //LoadGame
					Const.NEW_GAME_FLAG = false;
					ChangeScene( () => {return new SaveAndLoadSample();} );
					break;
				case 6: //NewGame
					Const.NEW_GAME_FLAG = true;
					ChangeScene( () => {return new SaveAndLoadSample();} );
					break;
				default:
					GameLog.DebugLog.Log("err");
					break;
				}
				GameLog.DebugLog.EndMethod("case " + cursorPositionY);
			}
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
			}
				
			// Z keyはSelect
			//連射不可
			if(Input2.GamePad.GetData(0).Select.Release)
			{
			}
			
			///////////
			//初期化
			///////////
			if (!this.touchedOBtn) this.oBtnAlready = false; //丸ボタンから手を離していたら
			this.touchedOBtn = false;
			if (!this.touchedXBtn) this.xBtnAlready = false; //Xボタンから手を離していたら
			this.touchedXBtn = false;
			
		}//selectStoryUpdate
		
		
		//シーン終了時に呼び出す
		public override void Terminate(){
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			scene = null;
			spriteCursor = null;
			spriteSampleTouch = null;
		}//Terminate
		
	}
}

