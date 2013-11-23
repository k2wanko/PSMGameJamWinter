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
			
			player = new PlayerEntity();
			//player.Position = scene.Camera.CalcBounds().Center;
			scene.AddChild(player);

			return scene;
		}
		
		protected long UpdateFrame()
		{
			return frame++ ;
		}
		
		public override void Update(){
			UpdateFrame();
		
			if(InputDevice.CircleButton()){
				//GameLog.DebugLog.Log ("AAA" + frame);
				//player.Position = new Vector2(1000F, 10F);
				player.setTexture(1);
			}
			
		}//Update()
		public override void Terminate()
		{
		}
		
	}
}

