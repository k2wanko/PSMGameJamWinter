using System;
using Sce.PlayStation.Core;


namespace PSMGameJamWinter2013
{
	public class PlayerEntity : Entity
	{
		public PlayerEntity ()
		{
			
			setTextureArray(new string[]{"maou.png", "maou2.png"});
			Quad.S = new Vector2(100f,100f);
			//Position.X = 100L;
			
		}
	}
}

