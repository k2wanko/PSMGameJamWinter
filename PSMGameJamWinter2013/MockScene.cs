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
	public class MockScene : GameScene
	{
		public MockScene ()
		{
		}
		
		//このシーンのタイマー
		private long mockSceneTime = 0;
		
		//スコア
		private int score = 0;
		
		//ボタンの押し込み
		private bool triangleBtnOn = false;
		private bool circleBtnOn = false;
		private bool squareBtnOn = false;
		private bool crossBtnOn = false;
		
		private SpriteForTouchList teki_ki{get;set;}
		private byte teki_kiSpriteNum = 2;
		private SpriteForTouch background = new SpriteForTouch();
		private SpriteForTouchList ki{get;set;}
		private byte kiSpriteNum = 2;
		private SpriteForTouchList teki_ki_tobira{get;set;}
		private byte teki_ki_tobiraSpriteNum = 2;
		private SpriteForTouchList danro{get;set;}
		private byte danroSpriteNum = 2;
		private SpriteForTouchList kapet{get;set;}
		private byte kapetSpriteNum = 2;
		private SpriteForTouchList bed{get;set;}
		private byte bedSpriteNum = 2;
		private SpriteForTouchList ike{get;set;}
		private byte ikeSpriteNum = 2;
		private SpriteForTouchList maou{get;set;}
		private byte maouSpriteNum = 2;
		
		private SpriteForTouch timeBar = new SpriteForTouch();
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			//敵_木_窓
			List<SpriteForTouch> teki_kiList = new List<SpriteForTouch>();
			SpriteForTouch[] teki_kiSpriteForTouch = new SpriteForTouch[this.teki_kiSpriteNum];
			for(int i = 0; i < this.teki_kiSpriteNum; i++) {
				teki_kiSpriteForTouch[i] = new SpriteForTouch();
			}
			teki_kiSpriteForTouch[0].DrawSprite("teki_ki.png", -240, 10, 240f, 240f);
			teki_kiSpriteForTouch[1].DrawSprite("teki_ki.png", -240, 10, 240f, 240f);
			
			foreach (SpriteForTouch temp in teki_kiSpriteForTouch) {
				teki_kiList.Add(temp);
			}
			
			this.teki_ki = new SpriteForTouchList(teki_kiList,false);
			this.teki_ki.AddToScene(scene);
			this.teki_kiSpriteNum = this.teki_ki.SetVisible(0);
			
			//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
			//画像のセット
			//背景
			background.DrawSprite("gamen_rafu_2.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
//			background.Sprite.Visible = false;
			
			//木
			List<SpriteForTouch> kiList = new List<SpriteForTouch>();
			SpriteForTouch[] kiSpriteForTouch = new SpriteForTouch[this.kiSpriteNum];
			for(int i = 0; i < this.kiSpriteNum; i++) {
				kiSpriteForTouch[i] = new SpriteForTouch();
			}
			kiSpriteForTouch[0].DrawSprite("waku_blue.png", 480, 10,220f,340f);
			kiSpriteForTouch[1].DrawSprite("waku_red.png", 480, 10,220f,340f);
			
			foreach (SpriteForTouch temp in kiSpriteForTouch) {
				kiList.Add(temp);
			}
			this.ki = new SpriteForTouchList(kiList,true);
			this.ki.AddToScene(scene);
			this.kiSpriteNum = this.ki.SetVisible(0);
			
			//敵_木_扉
			List<SpriteForTouch> teki_ki_tobiraList = new List<SpriteForTouch>();
			SpriteForTouch[] teki_ki_tobiraSpriteForTouch = new SpriteForTouch[this.teki_ki_tobiraSpriteNum];
			for(int i = 0; i < this.teki_ki_tobiraSpriteNum; i++) {
				teki_ki_tobiraSpriteForTouch[i] = new SpriteForTouch();
			}
			teki_ki_tobiraSpriteForTouch[0].DrawSprite("teki_ki.png", 300, 10, 240f, 240f);
			teki_ki_tobiraSpriteForTouch[1].DrawSprite("teki_ki.png", 300, 10, 240f, 240f);
			
			foreach (SpriteForTouch temp in teki_ki_tobiraSpriteForTouch) {
				teki_ki_tobiraList.Add(temp);
			}
			this.teki_ki_tobira = new SpriteForTouchList(teki_ki_tobiraList,false);
			this.teki_ki_tobira.AddToScene(scene);
			this.teki_ki_tobiraSpriteNum = this.teki_ki_tobira.SetVisible(0);
			this.teki_ki_tobira.SetUnVisible();
			
			//暖炉
			List<SpriteForTouch> danroList = new List<SpriteForTouch>();
			SpriteForTouch[] danroSpriteForTouch = new SpriteForTouch[this.danroSpriteNum];
			for(int i = 0; i < this.danroSpriteNum; i++) {
				danroSpriteForTouch[i] = new SpriteForTouch();
			}
			danroSpriteForTouch[0].DrawSprite("waku_blue.png", 710, 220,250f,250f);
			danroSpriteForTouch[1].DrawSprite("waku_red.png", 710, 220,250f,250f);
			
			foreach (SpriteForTouch temp in danroSpriteForTouch) {
				danroList.Add(temp);
			}
			this.danro = new SpriteForTouchList(danroList,true);
			this.danro.AddToScene(scene);
			this.danroSpriteNum = this.danro.SetVisible(0);
			
			//ベッド
			List<SpriteForTouch> bedList = new List<SpriteForTouch>();
			SpriteForTouch[] bedSpriteForTouch = new SpriteForTouch[this.bedSpriteNum];
			for(int i = 0; i < this.bedSpriteNum; i++) {
				bedSpriteForTouch[i] = new SpriteForTouch();
			}
			bedSpriteForTouch[0].DrawSprite("waku_blue.png", 500, 250, 240f, 200f);
			bedSpriteForTouch[1].DrawSprite("waku_red.png", 500, 250, 240f, 200f);
			
			foreach (SpriteForTouch temp in bedSpriteForTouch) {
				bedList.Add(temp);
			}
			this.bed = new SpriteForTouchList(bedList,false);
			this.bed.AddToScene(scene);
			this.bedSpriteNum = this.bed.SetVisible(0);
			
			//魔王
			List<SpriteForTouch> maouList = new List<SpriteForTouch>();
			SpriteForTouch[] maouSpriteForTouch = new SpriteForTouch[this.maouSpriteNum];
			for(int i = 0; i < this.maouSpriteNum; i++) {
				maouSpriteForTouch[i] = new SpriteForTouch();
			}
			maouSpriteForTouch[0].DrawSprite("maou.png", 520, 180,180f,180f);
			maouSpriteForTouch[1].DrawSprite("maou2.png", 520, 180,180f,180f);
			
			foreach (SpriteForTouch temp in maouSpriteForTouch) {
				maouList.Add(temp);
			}
			this.maou = new SpriteForTouchList(maouList,false);
			this.maou.AddToScene(scene);
			this.maouSpriteNum = this.maou.SetVisible(0);
			
			//カーペット
			List<SpriteForTouch> kapetList = new List<SpriteForTouch>();
			SpriteForTouch[] kapetSpriteForTouch = new SpriteForTouch[this.kapetSpriteNum];
			for(int i = 0; i < this.kapetSpriteNum; i++) {
				kapetSpriteForTouch[i] = new SpriteForTouch();
			}
			kapetSpriteForTouch[0].DrawSprite("waku_blue.png", 180, 300,350f,200f);
			kapetSpriteForTouch[1].DrawSprite("waku_red.png", 180, 300,350f,200f);
			
			foreach (SpriteForTouch temp in kapetSpriteForTouch) {
				kapetList.Add(temp);
			}
			this.kapet = new SpriteForTouchList(kapetList,true);
			this.kapet.AddToScene(scene);
			this.kapetSpriteNum = this.kapet.SetVisible(0);
			
			//池
			List<SpriteForTouch> ikeList = new List<SpriteForTouch>();
			SpriteForTouch[] ikeSpriteForTouch = new SpriteForTouch[this.ikeSpriteNum];
			for(int i = 0; i < this.ikeSpriteNum; i++) {
				ikeSpriteForTouch[i] = new SpriteForTouch();
			}
			ikeSpriteForTouch[0].DrawSprite("waku_blue.png", 470, 400,350f,144f);
			ikeSpriteForTouch[1].DrawSprite("waku_red.png", 470, 400, 350f,144f);
			
			foreach (SpriteForTouch temp in ikeSpriteForTouch) {
				ikeList.Add(temp);
			}
			this.ike = new SpriteForTouchList(ikeList,true);
			this.ike.AddToScene(scene);
			this.ikeSpriteNum = this.ike.SetVisible(0);
			
			
			//タイムバー
			timeBar.DrawSprite("lightBlue.png",
									10,
									500,
									300,
									30,
									scene,
			                       	false);
			//画像のセットここまで
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			if (this.mockSceneTime % 60 == 0) {
				this.timeBar.Sprite.Quad.S.X -= 2;
				if (this.timeBar.Sprite.Quad.S.X <= 0) {
//					ChangeScene( () => {return new TitleScene();} );
				}
			}
			
			if (this.mockSceneTime % 2 == 0) {
				MoveSprite.Right(teki_ki,5);
				if (300 <= this.teki_ki.Sprites[teki_ki.NowIndex].Sprite.Quad.T.X) {
					teki_ki_tobira.SetVisible(0);
				}
			}
			
			//LボタンはQ
			if(InputDevice.LButton()){
			}
			
			//RボタンはE
			if(InputDevice.RButton()){
			}
			
			//四角ボタンはA
			if(InputDevice.SquareButtonRepeat()
			   || InputDevice.LeftKeyRepeat()){
				squareBtnOn = true;
			} else {
				squareBtnOn = false;
			}
			
			//三角ボタンはW
			if(InputDevice.TriangleButtonRepeat()
			   || InputDevice.UpKeyRepeat()){
				triangleBtnOn = true;
			} else {
				triangleBtnOn = false;
			}
			
			//バツボタンはS
			if(InputDevice.CrossButtonRepeat()
			   || InputDevice.DownKeyRepeat()){
				crossBtnOn = true;
			} else {
				crossBtnOn = false;
			}
			
			//丸ボタンはD
			if(InputDevice.CircleButtonRepeat()
			   || InputDevice.RightKeyRepeat()){
				circleBtnOn = true;
			} else {
				circleBtnOn = false;
			}
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
				
			}
			
			this.hideMaou();
			
			//time++
			mockSceneTime++;
			
		}//Update()
		
		private void hideMaou() {
			if (triangleBtnOn
			    || circleBtnOn
			    || squareBtnOn
			    || crossBtnOn ) {
				this.maou.SetUnVisible();
			} else {
				this.maou.SetVisible(0);
			}
			
			if (triangleBtnOn) {
				this.ki.SetVisible(1);
			} else {
				this.ki.SetVisible(0);
			}
			
			if (circleBtnOn) {
				this.danro.SetVisible(1);
			} else {
				this.danro.SetVisible(0);
			}
			
			if (squareBtnOn) {
				this.kapet.SetVisible(1);
			} else {
				this.kapet.SetVisible(0);
			}
			
			if (crossBtnOn) {
				this.ike.SetVisible(1);
			} else {
				this.ike.SetVisible(0);
			}
			
		}
		
		/// <summary>
		/// Terminate of Scene.
		/// </summary>
		public override void Terminate(){
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			scene = null;
			background = null;
			maou = null;
		}//Terminate
	}
}
