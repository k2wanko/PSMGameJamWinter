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
		public MainScene ()
		{
		}
		public override Scene Initialize()
		{
			scene.Camera.SetViewFromViewport();
			GameLog.DebugLog.Log("start");
			
			message.DrawSprite("DrawSpriteSample",
										120f,
										120f,
										30,
										new ImageColor(255,255,255,255),
										scene,
			                             true);
			return scene;
		}
		
		public override void Update(){
		
		if(InputDevice.CircleButton()){
				ChangeScene( () => {return new AudioSample();} );
			}
			
		}//Update()
		public override void Terminate()
		{
		}
		
	}
}

