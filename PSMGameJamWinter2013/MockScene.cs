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

using System.Timers;//timer

using ApmFw;
namespace PSMGameJamWinter2013
{
	public class MockScene : GameScene
	{
		//音
		private SoundPlayer doorCloseSe;
		private SoundPlayer doorOpenSe;
		private SoundPlayer endBadSe;
		private SoundPlayer endGoodSe;
		private SoundPlayer fireSe;
		private SoundPlayer landSe;
		private SoundPlayer waterSe;
		private SoundPlayer woodSe;
		
		//レベルUP
		
		//敵がドアを開けている時間フレーム数UP
		private static readonly int DOOR_OPEN_FRAME = 5;
		
		private int enemyMoveSpeed = 6;
		
		private int doorOpenCount = 0;
		
		private static readonly byte DOOR_OPEN_SANKAKU  = 0;
		private static readonly byte DOOR_OPEN_SIKAKU  = 1;
		private static readonly byte DOOR_OPEN_BATU  = 2;
		private static readonly byte DOOR_OPEN_MARU  = 3;
		private static readonly byte DOOR_CLOSE  = 4;
		private static readonly byte DOOR_OPEN_MAX  = 5;
		
		//敵のID
		private static readonly byte ENEMY_ID_NONE = 255;
		private static readonly byte ENEMY_ID_SANKAKU = 0;
		private static readonly byte ENEMY_ID_SIKAKU = 1;
		private static readonly byte ENEMY_ID_BATU = 2;
		private static readonly byte ENEMY_ID_MARU = 3;
		private static readonly byte ENEMY_ID_MAX = 4;
		
		//1回に入る点数
		private static readonly int SCORE_PULS = 10;
		
		//300フレームごとにレベルアップ
		private static readonly int LEVELUP_FRAME = 500;
		//1回で上がるスピード
		private static readonly int LEVELUP_SPEED = 1;
		private static readonly int LEVELUP_MAX = 30;	//速度の限界
		
		//出現するモンスターの種類が増えるタイミング
		private static readonly int MONSTER_ADD_FRAME = 500;
		private int monsterTypeCnt = 0;
		
		private int monsterType = 5;	//初期のモンスターの数（1で２匹）
		
		private int monsterRate = 100;//モンスターの出現率（１００で１０％）
		
		private readonly int MONSTER_RATE_UP = 200;//1回で上がる出現率
		private readonly int MONSTER_RATE_FRAME = 300;//設定フレームごとに出現率アップ
		private int monsterRateUpCnt = 0;
		
		//難易度カウンターこのカウントがレベルアップフレームを超えたら
		private int levelUpCnt = 0;
		
		private bool gameOver = false;
		
		private bool doorOpen = false;
		
		
		public MockScene ()
		{
		}
		
		//ランダム
		private Random rand = new Random();
		
		//このシーンのタイマー
		private long mockSceneTime = 0;
		
		private System.Timers.Timer timer = new System.Timers.Timer(100);//0/1秒に1回呼び出し
		
		//初期位置
		private readonly int CREATE_ENEMY_POS = -200;
		
		//スコア
		private int score = 0;
		
		//ボタンの押し込み
		private bool triangleBtnOn = false;
		private bool circleBtnOn = false;
		private bool squareBtnOn = false;
		private bool crossBtnOn = false;
		
		//窓の外の敵の数
		private int tekiNum = 6;		
		
		private SpriteForTouch background0 = new SpriteForTouch();
		private List<SpriteForTouchList> Teki_soto{get;set;}
		private byte teki_kiSpriteNum = 2;
		private SpriteForTouch background1 = new SpriteForTouch();
		private SpriteForTouchList Ki{get;set;}
		private byte kiSpriteNum = 2;
		private SpriteForTouchList Teki_tobira{get;set;}
		private byte teki_tobiraSpriteNum = DOOR_OPEN_MAX;
		private SpriteForTouchList Danro{get;set;}
		private byte danroSpriteNum = 2;
		private SpriteForTouchList Kapet{get;set;}
		private byte kapetSpriteNum = 2;
		private SpriteForTouchList Bed{get;set;}
		private byte bedSpriteNum = 2;
		private SpriteForTouchList Ike{get;set;}
		private byte ikeSpriteNum = 2;
		private SpriteForTouchList Maou{get;set;}
		private byte maouSpriteNum = 2;
		
		private SpriteForTouch Success = new SpriteForTouch();
		private SpriteForTouch Loosing = new SpriteForTouch();
		
		private SpriteForTouch timeBar = new SpriteForTouch();
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			background0.DrawSprite("haikei_ushiro.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
			//敵_窓の外
			this.Teki_soto = new List<SpriteForTouchList>();
			//とりあえず5体ぐらい作る
			for (int i = 0; i < this.tekiNum ; i++) {
				//敵_木
				List<SpriteForTouch> teki_kiList = new List<SpriteForTouch>();
				SpriteForTouch[] teki_kiSpriteForTouch = new SpriteForTouch[ENEMY_ID_MAX];
				for(int k = 0; k < ENEMY_ID_MAX; k++) {
					teki_kiSpriteForTouch[k] = new SpriteForTouch();
				}
				//アニメーション(各敵の種類
				
//				teki_kiSpriteForTouch[0].DrawSprite("teki_ki.png", -240 * (i + 1), 10, 240f, 240f);
//				teki_kiSpriteForTouch[1].DrawSprite("teki_ki.png", -240 * (i + 1), 10, 240f, 240f);
				
				//各対応した敵キャラクターをロード
				teki_kiSpriteForTouch[ENEMY_ID_MARU].DrawSprite("teki_ki.png", -240 * (i + 1), 10, 240f, 240f);
				teki_kiSpriteForTouch[ENEMY_ID_SANKAKU].DrawSprite("teki_hikui.png", -240 * (i + 1), 10, 240f, 240f);
				teki_kiSpriteForTouch[ENEMY_ID_SIKAKU].DrawSprite("teki_mizu.png", -240 * (i + 1), 10, 240f, 240f);
				teki_kiSpriteForTouch[ENEMY_ID_BATU].DrawSprite("teki_honoo.png", -240 * (i + 1), 10, 240f, 240f);
				
				foreach (SpriteForTouch temp in teki_kiSpriteForTouch) {
					teki_kiList.Add(temp);
				}
				
				this.Teki_soto.Add(new SpriteForTouchList(teki_kiList,false));
				this.Teki_soto[i].AddToScene(scene);
				this.Teki_soto[i].SetVisible(0);
			}
			
			
			//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
			//画像のセット
			//背景
			background1.DrawSprite("haikei.png",
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
			kiSpriteForTouch[0].DrawSprite("ki.png", 450, 10,280f,340f);
			kiSpriteForTouch[1].DrawSprite("ki_kakure.png", 450, 10,280f,340f);
			
			foreach (SpriteForTouch temp in kiSpriteForTouch) {
				kiList.Add(temp);
			}
			this.Ki = new SpriteForTouchList(kiList,true);
			this.Ki.AddToScene(scene);
			this.Ki.SetVisible(0);
			
			//敵_木_扉
			List<SpriteForTouch> teki_ki_tobiraList = new List<SpriteForTouch>();
			SpriteForTouch[] teki_ki_tobiraSpriteForTouch = new SpriteForTouch[this.teki_tobiraSpriteNum];
			for(int i = 0; i < this.teki_tobiraSpriteNum; i++) {
				teki_ki_tobiraSpriteForTouch[i] = new SpriteForTouch();
			}
			teki_ki_tobiraSpriteForTouch[DOOR_OPEN_SANKAKU].DrawSprite("teki_hikui.png", 300, 10, 240f, 240f);
			teki_ki_tobiraSpriteForTouch[DOOR_OPEN_SIKAKU].DrawSprite("teki_mizu.png", 300, 10, 240f, 240f);
			teki_ki_tobiraSpriteForTouch[DOOR_OPEN_BATU].DrawSprite("teki_honoo.png", 300, 10, 240f, 240f);
			teki_ki_tobiraSpriteForTouch[DOOR_OPEN_MARU].DrawSprite("teki_ki.png", 300, 10, 240f, 240f);
			teki_ki_tobiraSpriteForTouch[DOOR_CLOSE].DrawSprite("tobira.png", 300, 10, 240f, 240f);
			
			foreach (SpriteForTouch temp in teki_ki_tobiraSpriteForTouch) {
				teki_ki_tobiraList.Add(temp);
			}
			this.Teki_tobira = new SpriteForTouchList(teki_ki_tobiraList,false);
			this.Teki_tobira.AddToScene(scene);
			this.teki_tobiraSpriteNum = this.Teki_tobira.SetVisible(DOOR_CLOSE);
			this.Teki_tobira.SetUnVisible();
			this.Teki_tobira.SetVisible(DOOR_CLOSE);
			
			//暖炉
			List<SpriteForTouch> danroList = new List<SpriteForTouch>();
			SpriteForTouch[] danroSpriteForTouch = new SpriteForTouch[this.danroSpriteNum];
			for(int i = 0; i < this.danroSpriteNum; i++) {
				danroSpriteForTouch[i] = new SpriteForTouch();
			}
			danroSpriteForTouch[0].DrawSprite("danro.png", 710, 215,250f,240f);
			danroSpriteForTouch[1].DrawSprite("danro_kakure.png", 710, 215,250f,240f);
			
			foreach (SpriteForTouch temp in danroSpriteForTouch) {
				danroList.Add(temp);
			}
			this.Danro = new SpriteForTouchList(danroList,true);
			this.Danro.AddToScene(scene);
			this.Danro.SetVisible(0);
			
			//ベッド
			List<SpriteForTouch> bedList = new List<SpriteForTouch>();
			SpriteForTouch[] bedSpriteForTouch = new SpriteForTouch[this.bedSpriteNum];
			for(int i = 0; i < this.bedSpriteNum; i++) {
				bedSpriteForTouch[i] = new SpriteForTouch();
			}
			bedSpriteForTouch[0].DrawSprite("bed.png", 450, 250, 260f, 185f);
			bedSpriteForTouch[1].DrawSprite("bed.png", 450, 250, 260f, 185f);
			
			foreach (SpriteForTouch temp in bedSpriteForTouch) {
				bedList.Add(temp);
			}
			this.Bed = new SpriteForTouchList(bedList,false);
			this.Bed.AddToScene(scene);
			this.Bed.SetVisible(0);
			
			//魔王
			List<SpriteForTouch> maouList = new List<SpriteForTouch>();
			SpriteForTouch[] maouSpriteForTouch = new SpriteForTouch[this.maouSpriteNum];
			for(int i = 0; i < this.maouSpriteNum; i++) {
				maouSpriteForTouch[i] = new SpriteForTouch();
			}
			maouSpriteForTouch[0].DrawSprite("maou.png", 520, 180,150f,180f);
			maouSpriteForTouch[1].DrawSprite("maou2.png", 520, 180,150f,180f);
			
			foreach (SpriteForTouch temp in maouSpriteForTouch) {
				maouList.Add(temp);
			}
			this.Maou = new SpriteForTouchList(maouList,false);
			this.Maou.AddToScene(scene);
			this.Maou.SetVisible(0);
			
			//カーペット
			List<SpriteForTouch> kapetList = new List<SpriteForTouch>();
			SpriteForTouch[] kapetSpriteForTouch = new SpriteForTouch[this.kapetSpriteNum];
			for(int i = 0; i < this.kapetSpriteNum; i++) {
				kapetSpriteForTouch[i] = new SpriteForTouch();
			}
			kapetSpriteForTouch[0].DrawSprite("karpet.png", 180, 305, 290f,150f);
			kapetSpriteForTouch[1].DrawSprite("karpet_kakure.png", 180, 305, 290f,150f);
			
			foreach (SpriteForTouch temp in kapetSpriteForTouch) {
				kapetList.Add(temp);
			}
			this.Kapet = new SpriteForTouchList(kapetList,true);
			this.Kapet.AddToScene(scene);
			this.Kapet.SetVisible(0);
			
			//池
			List<SpriteForTouch> ikeList = new List<SpriteForTouch>();
			SpriteForTouch[] ikeSpriteForTouch = new SpriteForTouch[this.ikeSpriteNum];
			for(int i = 0; i < this.ikeSpriteNum; i++) {
				ikeSpriteForTouch[i] = new SpriteForTouch();
			}
			ikeSpriteForTouch[0].DrawSprite("ike.png", 450, 397,305f,144f);
			ikeSpriteForTouch[1].DrawSprite("ike_kakure.png", 450, 397, 305f,144f);
			
			foreach (SpriteForTouch temp in ikeSpriteForTouch) {
				ikeList.Add(temp);
			}
			this.Ike = new SpriteForTouchList(ikeList,true);
			this.Ike.AddToScene(scene);
			this.Ike.SetVisible(0);
			
			//タイムバー
			timeBar.DrawSprite("lightBlue.png",
									10,
									500,
									300,
									30,
									scene,
			                       	false);
			//画像のセットここまで
			
			
			//効果音のセット
			this.doorCloseSe = Audio.SetEffect("/Application/sound/door_close.wav");
			this.doorOpenSe = Audio.SetEffect("/Application/sound/door_open.wav");
			this.endBadSe = Audio.SetEffect("/Application/sound/end_bad.wav");
			this.endGoodSe = Audio.SetEffect("/Application/sound/end_good.wav");
			this.fireSe = Audio.SetEffect("/Application/sound/fire.wav");
			this.landSe = Audio.SetEffect("/Application/sound/land.wav");
			this.waterSe = Audio.SetEffect("/Application/sound/water.wav");
			this.woodSe = Audio.SetEffect("/Application/sound/wood.wav");
			this.woodSe.Volume = 0.8f;
			
			//Bgmのセット
			Audio.SetBgm("/Application/sound/game_maoudamashii_6_dangeon07.mp3");
			Audio.SetVolumeBgm(0.1f);
			Audio.StartBgm();
			
			return scene;

		}//Initialize()
		
		//0.1秒ごとの呼び出し
    	private void createEnemy()
		{
			
			// ゲームオーバー処理
			if(gameOver)
			{
				return;
			}
			//敵の生成
			int randomDraw =(int)(rand.Next() % 1000);
			
			byte monster = (byte)(rand.Next() % (monsterType - 1));
			
			//毎秒１０％の確率で生成
			if(randomDraw < monsterRate)
			{
				for(int i = 0; i < this.tekiNum; i++)
				{
					//描画できるSpriteがあるか見る
					//ぶつかってたら生成しない
					if(!Teki_soto[i].isVisible())
					{
						//Draw
						Teki_soto[i].SetVisible(monster);
						MoveSprite.SetPositonGridX(Teki_soto[i], CREATE_ENEMY_POS);
						for(int j = 0; j < this.tekiNum; j++)
						{
							//出現位置でぶつかるようなら表示しない
							if(i != j
							   && Teki_soto[i].isHit(Teki_soto[j].Sprites[Teki_soto[j].NowIndex]))
							{
								Teki_soto[i].SetUnVisible();
								break;
							}
						
						}
					}
				}
			}
		}
		
		private bool oneFlg= false;
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			createEnemy();
			
			if (this.mockSceneTime % 30 == 0) 
			{
				this.timeBar.Sprite.Quad.S.X -= 2;
				if (this.timeBar.Sprite.Quad.S.X <= 0) 
				{
					if(!oneFlg)
					{
						this.endGoodSe.Play();
						Success.DrawSprite("seikou.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
						Success.Sprite.Visible = true;
						oneFlg = true;
					}
					//丸ボタンはD
					if(InputDevice.CircleButton())
					{
						ChangeScene( () => {return new TitleScene();} );
						
					}
					return;
				}
			}
			
				if(gameOver)
				{
					if(!oneFlg)
					{
						this.endBadSe.Play();
						Loosing.DrawSprite("shippai.png",
									0,
									0,
									960,
									544,
									scene,
			                       	false);
						Loosing.Sprite.Visible = true;
						oneFlg = true;
					}
					//丸ボタンはD
					if(InputDevice.CircleButton())
					{
						ChangeScene( () => {return new TitleScene();} );
						
					}
					return;
				}
			
			if (this.mockSceneTime % 2 == 0) {
				for (int i = 0; i < this.tekiNum; i++) {
					MoveSprite.Right(Teki_soto[i],enemyMoveSpeed);
					if (300 <= this.Teki_soto[i].Sprites[Teki_soto[i].NowIndex].Sprite.Quad.T.X) {
						//後ろを通過した敵と絵を合わせる
						Teki_tobira.SetVisible(Teki_soto[i].NowIndex);
						Teki_soto[i].SetUnVisible();	//全部非表示
//						Teki_tobira.SetVisible(DOOR_OPEN);
						doorOpen = true;	//ドアを開ける
						doorOpenCount = 0;
					}
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
			   && !InputDevice.CircleButtonRepeat()
			   && !InputDevice.TriangleButtonRepeat()
			   && !InputDevice.CrossButtonRepeat()){
				if(!squareBtnOn)
				{
					this.landSe.Play();
				}
				squareBtnOn = true;
				this.Kapet.SetVisible(1);
			} else {
				squareBtnOn = false;
				this.Kapet.SetVisible(0);
			}
			
			//三角ボタンはW
			if(!InputDevice.SquareButtonRepeat() 
			   && !InputDevice.CircleButtonRepeat()
			   && InputDevice.TriangleButtonRepeat()
			   && !InputDevice.CrossButtonRepeat()){
				if(!triangleBtnOn)
				{
					this.woodSe.Play();
				}
				triangleBtnOn = true;
				this.Ki.SetVisible(1);

			} else {
				triangleBtnOn = false;
				this.Ki.SetVisible(0);
			}
			
			//バツボタンはS
			if(!InputDevice.SquareButtonRepeat() 
			   && !InputDevice.CircleButtonRepeat()
			   && !InputDevice.TriangleButtonRepeat()
			   && InputDevice.CrossButtonRepeat()){
				if(!crossBtnOn)
				{
					this.waterSe.Play();
				}
				crossBtnOn = true;
				this.Ike.SetVisible(1);
				
			} else {
				crossBtnOn = false;
				this.Ike.SetVisible(0);
			}
			
			//丸ボタンはD
			if(!InputDevice.SquareButtonRepeat() 
			   && InputDevice.CircleButtonRepeat()
			   && !InputDevice.TriangleButtonRepeat()
			   && !InputDevice.CrossButtonRepeat()){
				if(!circleBtnOn)
				{
					this.fireSe.Play();
				}
				circleBtnOn = true;
				this.Danro.SetVisible(1);
				
			} else {
				circleBtnOn = false;
				this.Danro.SetVisible(0);
			}
			
			
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
				
			}
			
			this.hideMaou();
			
			if(doorOpen)
			{
				doorOpenCount ++;
				if(doorOpenCount > DOOR_OPEN_FRAME)
				{
					//△これが正しい処理
					Teki_tobira.SetVisible(DOOR_CLOSE);
					//見た目上の仮処理
//					Teki_tobira.SetUnVisible();
					doorOpenCount = 0;
					doorOpen = false;
				}
				
				if(
					(Teki_tobira.NowIndex == ENEMY_ID_SIKAKU && squareBtnOn)
					||((Teki_tobira.NowIndex == ENEMY_ID_BATU && crossBtnOn))
					||((Teki_tobira.NowIndex == ENEMY_ID_MARU && circleBtnOn))
					||((Teki_tobira.NowIndex == ENEMY_ID_SANKAKU && triangleBtnOn))
					||(Teki_tobira.NowIndex >= ENEMY_ID_MAX)
					)
				{
					score += (SCORE_PULS/DOOR_OPEN_FRAME);
				}
				else
				{
					gameOver = true;
				}
				
			}
			//time++
			mockSceneTime++;
			
			if(levelUpCnt > LEVELUP_FRAME)
			{
					levelUpCnt = 0;
					enemyMoveSpeed += LEVELUP_SPEED;
					if(enemyMoveSpeed > LEVELUP_MAX)
					{
						enemyMoveSpeed = LEVELUP_MAX;
					}
				}
				levelUpCnt++;
				
				if(monsterTypeCnt > MONSTER_ADD_FRAME)
				{
					monsterType ++;
					if(monsterType >= ENEMY_ID_MAX)
					{
						monsterType = ENEMY_ID_MAX - 1;
					}
					monsterTypeCnt = 0;
				}
				monsterTypeCnt++;
				
				if(monsterRateUpCnt > MONSTER_RATE_FRAME)
				{
					monsterRate += MONSTER_RATE_UP;
				}
				monsterRateUpCnt ++;
			
		}//Update()
		
		private void hideMaou() {
			if (triangleBtnOn
			    || circleBtnOn
			    || squareBtnOn
			    || crossBtnOn ) {
				this.Maou.SetUnVisible();
			} else {
				this.Maou.SetVisible(0);
			}
			
			if (triangleBtnOn) {
				this.Ki.SetVisible(1);
			} else {
				this.Ki.SetVisible(0);
			}
			
			if (circleBtnOn) {
				this.Danro.SetVisible(1);
			} else {
				this.Danro.SetVisible(0);
			}
			
			if (squareBtnOn) {
				this.Kapet.SetVisible(1);
			} else {
				this.Kapet.SetVisible(0);
			}
			
			if (crossBtnOn) {
				this.Ike.SetVisible(1);
			} else {
				this.Ike.SetVisible(0);
			}
		}
		
		/// <summary>
		/// Terminate of Scene.
		/// </summary>
		public override void Terminate(){
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			scene = null;
			background1 = null;
			Maou = null;
			Audio.StopBgm();
		}//Terminate
	}
}
