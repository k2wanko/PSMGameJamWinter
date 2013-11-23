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
		
		public EnemyEntity[] enemyArray = new EnemyEntity[4];
		
		private bool isStart = false;
		
		public int score = 0;
		
		public float wait = 10;
		
		protected long frame = 0;
		public MainScene ()
		{
			
		}
		public override Scene Initialize()
		{
			scene.Camera.SetViewFromViewport();
			//GameLog.DebugLog.Log("start");
			
			BaseSprite background = new BaseSprite();
			background.setTexture("background.png");
			//background.Quad.S = new Vector2(128,128);
			
			
			player = new PlayerEntity();
			
			enemyArray[0] = new EnemyEntity(); 
			
			
			scene.AddChild(background);
			scene.AddChild(player);

			return scene;
		}
		
		public void start()
		{
			isStart = true;
			GameLog.DebugLog.Log("start");
			timer.Elapsed += new ElapsedEventHandler(spawnEnemy);
			timer.Interval = 1000;
			timer.Enabled = true;
			Console.ReadLine();
			
		}
		
		public EnemyEntity[] enemyArray = new EnemyEntity[5];
		
		public System.Collections.Generic.List<EnemyEntity> enemyList = new System.Collections.Generic.List<EnemyEntity>();
		
		public void spawnEnemy(object source, ElapsedEventArgs tEvent)
		{
			//GameLog.DebugLog.Log("as" + enemyList.Count);
			int rand = (new System.Random()).Next(0, 3);
			
			
			EnemyEntity e = new EnemyEntity();
			int i = enemyList.Count;
			Console.WriteLine("Yahoo " + i);
			/*
			if (0 < i){
				
				
				scene.AddChild(e);
				int j = i;
				for(; 0 < j; j--){
					//GameLog.DebugLog.Log("as" + j);
					EnemyEntity ce = enemyList[j];
				}
				
			}else {
				enemyList.Add(e);
				scene.AddChild(e);
			}
			
			Console.Write("Test");			
			*/
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
				
				player.Update(frame);
				
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

