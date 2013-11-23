using System;
using Sce.PlayStation.Core;

using ApmFw;

namespace PSMGameJamWinter2013
{
	public class PlayerEntity : Entity
	{
		public Vector2 defaultPos = new Vector2(542, 160);
		private int move = 130;
		//private int sec = 8;
		
		public PlayerEntity ()
		{
			
			setTextureArray(new string[]{"maou.png", "maou2.png"});
			Quad.S = new Vector2(180f,180f);
			Position = defaultPos;
			
		}
		
		private bool isPush = false;
		private float cFrame = -1;
		
		
		public void Update(float f)
		{
			if(InputDevice.CircleButtonRepeat()) {
				isPush = true;
				Position = new Vector2(defaultPos.X + move, defaultPos.Y);
			} else if (InputDevice.CrossButtonRepeat()) {
				isPush = true;
				Position = new Vector2(defaultPos.X, defaultPos.Y - move);
			} else if (InputDevice.SquareButtonRepeat()) {
				isPush = true;
				Position = new Vector2(defaultPos.X - move, defaultPos.Y);
			} else if (InputDevice.TriangleButtonRepeat()) {
				isPush = true;
				Position = new Vector2(defaultPos.X, defaultPos.Y + move);
			} else {
				isPush = false;
				Position = defaultPos;
			}
			/*
			if(InputDevice.CircleButtonRepeat() && !isPush){
				Position = new Vector2(Position.X + move, Position.Y);
				cFrame = f;
				//isPush = true;
			} else if(InputDevice.CrossButtonRepeat() && !isPush) {
				Position = new Vector2(Position.X, Position.Y - move);
				cFrame = f;
				//isPush = true;
			} else if(InputDevice.SquareButtonRepeat() && !isPush) {
				Position = new Vector2(Position.X - move, Position.Y);
				cFrame = f;
				//isPush = true;
			} else if(InputDevice.TriangleButtonRepeat() && !isPush) {
				Position = new Vector2(Position.X, Position.Y + move);
				cFrame = f;
				//isPush = true;
			} else {
				if(cFrame > 0){
					Position = defaultPos;
					//isPush = false;
					cFrame = -1;
					/*if(f > cFrame + sec){
						Position = defaultPos;
						cFrame = -1;
						isPush = false;
					}	
				} else {
					
				}
			}*/
			
		}
		
	}
}

