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
	/// Scene sample.
	/// </summary>
	public class SaveAndLoadSample : GameScene
	{
		private SpriteUV description;
		private String testStr;
		private SpriteUV spriteString;
		
		public SaveAndLoadSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			//saveDataのロード
			testStr = LoadFromXmlSample.LoadGameData(Const.NEW_GAME_FLAG);
			
			scene.Camera.SetViewFromViewport();
				
			//文字の描画 960x544 //vita画面解像度 20x11.25(左上)
			description = WriteString.DrawSprite("L・R・○・□・△・x:お知らボタンをセーブして戻る/Start:セーブせずに戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			spriteString = WriteString.DrawSprite(testStr,
															1.5f*Const.FIX,
															2.5f*Const.FIX,
															140,
															new ImageColor(255,0,0,255),
															scene);
			
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
			}
			if(InputDevice.RightKeyRepeat()){
			}
			
			//LボタンはQ
			if(InputDevice.LButton()){
				//データのセーブ
				SaveToXmlSample.SaveGameData("Lボタン");
				ChangeScene( () => {return new MainMenuSample();} );
			}
			
			//RボタンはE
			if(InputDevice.RButton()){
				//データのセーブ
				SaveToXmlSample.SaveGameData("Rボタン");
				ChangeScene( () => {return new MainMenuSample();} );
			}
			
			//四角ボタンはA
			if(InputDevice.SquareButton()){
				//データのセーブ
				SaveToXmlSample.SaveGameData("□ボタン");
				ChangeScene( () => {return new MainMenuSample();} );
			}
			//三角ボタンはW
			if(InputDevice.TriangleButton()){
				//データのセーブ
				SaveToXmlSample.SaveGameData("△ボタン");
				ChangeScene( () => {return new MainMenuSample();} );
			}
			//バツボタンはS
			if(InputDevice.CrossButton()){
				//データのセーブ
				SaveToXmlSample.SaveGameData("Xボタン");
				ChangeScene( () => {return new MainMenuSample();} );
			}
			//丸ボタンはD
			if(InputDevice.CircleButton()){
				//データのセーブ
				SaveToXmlSample.SaveGameData("◯ボタン");
				ChangeScene( () => {return new MainMenuSample();} );
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
			testStr = null;
			scene = null;
			spriteString = null;
		}//Terminate
		
	}//class SceneSample
}//namespace DiceGame_01

