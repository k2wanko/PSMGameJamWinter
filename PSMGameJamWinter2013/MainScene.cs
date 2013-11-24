using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Imaging; // for Font

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using ApmFw;
using System.Timers;

namespace PSMGameJamWinter2013
{
	public class MainScene : GameScene
	{
		private SpriteForTouch message = new SpriteForTouch();
		
		public PlayerEntity player;
		System.Timers.Timer timer = new System.Timers.Timer(10000);
		
		public EnemyEntity[] enemyArray = null;
		
		//public GameScene scene = scene;
		
		private bool isStart = false;
		
		public int score = 0;
		
		public float wait = 10;
		
		protected long frame = 0;
		public MainScene ()
		{
			
		}
		public TextLabel scoreLabel = null;
		
		public string scoreText = "Score: ";
		
		
		public override Scene Initialize()
		{
			scene.Camera.SetViewFromViewport();
			//GameLog.DebugLog.Log("start");
			
			BaseSprite background = new BaseSprite();
			background.setTexture("background.png");
			//background.Quad.S = new Vector2(128,128);
			
			
			player = new PlayerEntity();
			
			scoreLabel = new TextLabel(scoreText + 0);
			
			//enemyArray[0] = new FireEnemyEntity(); 
			//enemyArray[1] = new WaterEnemyEntity(); 
			//enemyArray[2] = new GrandEnemyEntity(); 
			//enemyArray[3] = new WoodEnemyEntity(); 
			
			
			
			
			scene.AddChild(background);
			scene.AddChild(player);
			scene.AddChild(scoreLabel);

			return scene;
		}
		
		public void start()
		{
			isStart = true;
			GameLog.DebugLog.Log("start");
			
			//spwan
			spawnEnemy();
			timer.Elapsed += new ElapsedEventHandler(spawnEnemy);
			timer.Interval = 1000;
			timer.Enabled = true;
			Console.ReadLine();
			
		}
		
		public List<EnemyEntity> enemyList = new List<EnemyEntity>();
		
		public void spawnEnemy(object source, ElapsedEventArgs tEvent){
			int rand = (new System.Random()).Next(0, 3);
			EnemyEntity e = new EnemyEntity();
			Console.WriteLine(rand);
			
			//this.scene.AddChild();
		}
		
		public int max = 5;
		private EnemyEntity enemyEnt = new EnemyEntity();
		
		public void spawnEnemy() // Update
		{
			//GameLog.DebugLog.Log("as" + enemyList.Count);
			int rand = (new System.Random()).Next(0, 4);
			
			
			EnemyEntity e = new EnemyEntity(enemyEnt);
			//Console.WriteLine (rand);
			e.setType(rand);
			
			//if(max < enemyList.Count) {
			enemyList.Reverse();
			enemyList.Add(e);
			enemyList.Reverse();
			//}
			
			if (max < enemyList.Count) {
					enemyList.Remove(enemyList[enemyList.Count - 1]);
			}
			
			int i = enemyList.Count;
			foreach (EnemyEntity v in enemyList){
				if (!v.Next()){
					v.Visible = false;
					//enemyList.RemoveAt( i );
				}
			}
			//Console.WriteLine("Yahoo " + i);
			
			/*if (0 < i){
				
				for(int j = i; j > 0 ; j--){
					
					EnemyEntity tmp = enemyList[j - 1];
					Console.WriteLine("i:"+i + " j:" + j + " " + tmp.pos);
					tmp.Next();
					if(tmp.pos > max){
						tmp.Visible = false;
						tmp = null;
					}
					/*if(i == j){
						if(max > i){
							enemyList.Add(e);
							enemyList[j] = tmp;
						} else {
							tmp.Visible = false;
							tmp = null;
						}
					}/
					//if (max > i )
					//if(j == 0 ) enemyList[0] = e;
				}
				
			} else {
				enemyList.Add(e);
			}*/
			//enemyList[0] = e;
			scene.AddChild(e);
			
			/**/
			/*
			int i = 0;
			for(i = 0; i < enemyArray.Length; i++)
			{	
				EnemyEntity e = enemyArray[i] = new EnemyEntity();
				int j = (new System.Random()).Next(0, 3);
				e.setPos(i);
				
				//type set
				e.setTexture(j);
				scene.AddChild(e);
			}
			enemyArray[0].Visible = false;
			*/
		}
		
		public void nextScene()
		{
		}
		
		protected long UpdateFrame()
		{
			return frame++ ;
		}
		
		
		public override void Update(){
			float f = UpdateFrame();
			
			//GameLog.DebugLog.Log("" + f);
			if (f == wait){
				start ();
			} else if(isStart) {// start
				
				player.Update(f);
				
				if( (f % 60) == 0) {
					spawnEnemy();
					if(enemyList.Count >= 5)
					{
						EnemyEntity e = enemyList[3];
						bool flag = false;
						int b = 0;
						switch(e.type){
						case 0:
							flag = InputDevice.CircleButtonRepeat();
							break;
						case 1:
							flag = InputDevice.CrossButtonRepeat();
							break;
						case 2:
							flag = InputDevice.SquareButtonRepeat();
							break;
						case 3:
							flag = InputDevice.TriangleButtonRepeat();
							break;
						}
						Console.WriteLine (flag);
					}
				}
				
				
			}
			
			/*if(InputDevice.CircleButtonRepeat()){
				//GameLog.DebugLog.Log ("AAA" + frame);
				//player.Position = new Vector2(1000F, 10F);
				player.setTexture(1);
			} else {
				player.setTexture(0);
			}*/
			
		}//Update()
		public override void Terminate()
		{
		}
		
	}
}

