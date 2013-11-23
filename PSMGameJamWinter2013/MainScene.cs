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

namespace PSMGameJamWinter2013
{
	public class MainScene : GameScene
	{
		private SpriteForTouch message = new SpriteForTouch();
		
		public PlayerEntity player;
		
		protected long frame = 0;
		public MainScene ()
		{
			
		}
		public override Scene Initialize()
		{
			scene.Camera.SetViewFromViewport();
			GameLog.DebugLog.Log("start");
			
			BaseSprite background = new BaseSprite();
			background.setTexture("background.png");
			background.setX(100);
			
			
			player = new PlayerEntity();
			
			scene.AddChild(background);
			scene.AddChild(player);

			return scene;
		}
		
		public void start()
		{
			
		}
		
		public void nextScene()
		{
		}
		
		protected long UpdateFrame()
		{
			return frame++ ;
		}
		
		public override void Update(){
			UpdateFrame();
		
			if(InputDevice.CircleButtonRepeat()){
				//GameLog.DebugLog.Log ("AAA" + frame);
				//player.Position = new Vector2(1000F, 10F);
				player.setTexture(1);
			} else {
				player.setTexture(0);
			}
			
		}//Update()
		public override void Terminate()
		{
		}
		
	}
}

