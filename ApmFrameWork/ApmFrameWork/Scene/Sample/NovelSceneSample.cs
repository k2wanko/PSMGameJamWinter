// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections; //ArrayList

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
	public class NovelSceneSample: GameScene
	{
		public NovelSceneSample ()
		{
		}
		
		
		
		private SpriteUV name = new SpriteUV(); //喋ってるキャラの名前
		private SpriteUV[] str = null; //台詞
		private SpriteUV background = new SpriteUV(); //背景
		private SpriteUV charaLeft = new SpriteUV(); //左の人
		private SpriteUV charaMid = new SpriteUV(); //真ん中の人
		private SpriteUV charaRight = new SpriteUV(); //右の人
		private SpriteUV textBox = new SpriteUV(); //テキストボックス
		private SoundPlayer soundPlayer;
		private SelectVoiceSample selectVoice = new SelectVoiceSample();
		private Voice voice;
		
		private Boolean touchedOBtn = false;
		private Boolean oBtnAlready = false;
		private int clickNumOBtn = 0; //丸ボタンを押した回数
		private int changeCharaPageNum = 0; //キャラクターを変えるタイミングを図る
		
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			str = new SpriteUV[4]; //max4行
			
			voice = selectVoice.getString(Const.NOVELID,Const.LEFTCHARACTER,Const.RIGHTCHARACTER);
			
			//画像描画クラス
			background = DrawPicture.DrawSprite((string)this.voice.getBackground()[0], 0*Const.FIX, 0*Const.FIX, Const.DISPLAY_WIDTH, Const.DISPLAY_HEIGHT,scene);
			charaLeft = DrawPicture.DrawSprite((string)this.voice.getCharaLeft()[0], 0*Const.FIX, 0*Const.FIX, (float)Const.GRID_SIZE*(Const.GRID_NUM_X/3), Const.DISPLAY_HEIGHT,scene); //左の人
			if(this.voice.getCharaLeftFlip()[0]){DrawPicture.FlipHorizontal(this.charaLeft);}
			charaMid = DrawPicture.DrawSprite((string)this.voice.getCharaMid()[0], (float)(Const.GRID_NUM_X/3)*Const.FIX, 0*Const.FIX, (float)Const.GRID_SIZE*Const.GRID_NUM_X/3, Const.DISPLAY_HEIGHT,scene); //真ん中の人
			if(this.voice.getCharaMidFlip()[0]){DrawPicture.FlipHorizontal(this.charaMid);}
			charaRight = DrawPicture.DrawSprite((string)this.voice.getCharaRight()[0], (float)(Const.GRID_NUM_X*2/3), 0*Const.FIX, (float)Const.GRID_SIZE*Const.GRID_NUM_X/3, Const.DISPLAY_HEIGHT,scene); //右の人
			if(this.voice.getCharaRightFlip()[0]){DrawPicture.FlipHorizontal(this.charaRight);}
			textBox = DrawPicture.DrawSprite("textBox.png", 0*Const.FIX, 6*Const.FIX, Const.GRID_SIZE*20*Const.FIX, Const.GRID_SIZE*5.2f*Const.FIX,scene); //テキストボックス
			name = WriteString.DrawSprite((string)this.voice.getNameList()[0],1.5f*Const.FIX,6.4f*Const.FIX,Const.FONT_SIZE_MESSAGE,new ImageColor(255,255,255,255),scene);

			
			for (int i = 0; i < 4; i++){
				//台詞の書き込み
				str[i]= WriteString.DrawSprite((string)this.voice.getStrList()[i],
				                               1*Const.FIX,
				                               (float)(7.2+i*0.8)*Const.FIX,
				                               Const.FONT_SIZE_MESSAGE,
				                               new ImageColor(255,255,255,255),
				                               scene);
			}
			
			//effect(効果音)もbgmも一つにつき一回newする。
			this.soundPlayer = Audio.SetEffect("/Application/sound/Bullet.wav");
			Audio.SetBgm("/Application/sound/GameBgm.mp3");
//			Audio.StartBgm();
			
			return scene;

		}//Initialize()
		
		public override void Update(){
			
			
			
			//////////////////
			// touch入力
			//////////////////
			if (InputDevice.TouchDown(this.touchStatus)){
			}else
			if (InputDevice.TouchPanel(this.touchStatus)){
				this.touchedOBtn = true;
				//this.oBtnAlready = true;
			}
			this.touchStatus = (byte)InputDevice.TOUCH_STATUS.TOUCH_NOT; //touchが全部終わったら書く
			
			
			//////////////////
			// Buttons入力
			//////////////////
			//UPボタン
			if(InputDevice.UpKeyRepeat()){
			}
			
			//Downボタン
			if(InputDevice.DownKeyRepeat()){
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
				this.soundPlayer.Play();
				this.clickNumOBtn++; //Oボタンを押した回数
				
				if (this.voice.getPageNum() <= this.clickNumOBtn){
					ChangeScene( () => {return new MainMenuSample();} );
				}else{
					if ((int)this.voice.getCharaChangeNum()[this.changeCharaPageNum] == this.clickNumOBtn){
					this.nextChara();
					}
					//次の台詞ページ
					this.nextStr();
				}
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
			
		}//Update()
		
		/// <summary>
		/// Nexts the chara.
		/// しゃべるキャラクター画像が変化するとき呼び出す
		/// </summary>
		public void nextChara(){
			this.scene.RemoveAllChildren(true);
			this.background = null;
			this.charaLeft = null;
			this.charaMid = null;
			this.charaRight = null;
			this.textBox = null;
			this.name = null;
			this.changeCharaPageNum++;
			this.background = DrawPicture.DrawSprite((string)this.voice.getBackground()[this.changeCharaPageNum], 0, 0, Const.DISPLAY_WIDTH, Const.DISPLAY_HEIGHT,scene); //左の人
			this.charaLeft = DrawPicture.DrawSprite((string)this.voice.getCharaLeft()[this.changeCharaPageNum], 0, 0, (float)Const.GRID_SIZE*Const.GRID_NUM_X/3, Const.DISPLAY_HEIGHT,scene); //左の人
			if(this.voice.getCharaLeftFlip()[this.changeCharaPageNum]){DrawPicture.FlipHorizontal(this.charaLeft);}
			this.charaMid = DrawPicture.DrawSprite((string)this.voice.getCharaMid()[this.changeCharaPageNum], (float)(Const.GRID_NUM_X/3), 0, (float)Const.GRID_SIZE*Const.GRID_NUM_X/3, Const.DISPLAY_HEIGHT,scene); //真ん中の人
			if(this.voice.getCharaMidFlip()[this.changeCharaPageNum]){DrawPicture.FlipHorizontal(this.charaMid);}
			this.charaRight = DrawPicture.DrawSprite((string)this.voice.getCharaRight()[this.changeCharaPageNum], (float)(Const.GRID_NUM_X*2/3), 0, (float)Const.GRID_SIZE*Const.GRID_NUM_X/3, Const.DISPLAY_HEIGHT,scene); //右の人
			if(this.voice.getCharaRightFlip()[this.changeCharaPageNum]){DrawPicture.FlipHorizontal(this.charaRight);}
			this.textBox = DrawPicture.DrawSprite("textBox.png", 0*Const.FIX, 6*Const.FIX, Const.GRID_SIZE*20*Const.FIX, Const.GRID_SIZE*5.2f*Const.FIX,scene); //テキストボックス
			this.name = WriteString.DrawSprite((string)this.voice.getNameList()[this.changeCharaPageNum],1.5f*Const.FIX,6.4f*Const.FIX,Const.FONT_SIZE_MESSAGE,new ImageColor(255,255,255,255),scene);
		}
		
		
		/// <summary>
		/// Sets the string.
		/// 台詞の入力
		/// </summary>
		/// <param name='str'>
		/// String.
		/// 台詞
		/// </param>
		/// <param name='num'>
		/// Number.
		/// 行数（一行目は0）　num < 4
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public void nextStr(){
			for (int j =0; j < 4; j++){
				this.scene.RemoveChild(str[j],true);
				str[j] = null;
			}
			
			int k = 0;
			for (int i = 4*this.clickNumOBtn; i < (4+4*this.clickNumOBtn); i++){
				//台詞の書き込み
				str[k]= WriteString.DrawSprite((string)this.voice.getStrList()[i],
				                               1*Const.FIX,
				                               (float)(7.2+k*0.8)*Const.FIX,
				                               Const.FONT_SIZE_MESSAGE,
				                               new ImageColor(255,255,255,255),
				                               scene);
				k++; //0-3
			}
			
		}//setStr(String str, int num, Scene scene)
		
		//シーン終了時に呼び出す
		public override void Terminate(){
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			Audio.StopBgm();
			scene = null;
			name = null; //喋ってるキャラの名前
			for (int j =0; j < 4; j++){
				str[j] = null;
			}
			str = null; //台詞
			background = null; //背景
			charaLeft = null; //左の人
			charaMid = null; //真ん中の人
			charaRight = null; //右の人
			textBox = null; //テキストボックス
			
			selectVoice = null;
			voice = null;
			this.soundPlayer.Dispose();
		}//Terminate
		
	}
}

