using System;
using Sce.PlayStation.Core;

using ApmFw;


namespace PSMGameJamWinter2013
{
	public class EnemyEntity : Entity
	{
		public EnemyEntity ()
		{
			setTextureArray(new string[]{"maou.png", "maou2.png"});
			Quad.S = new Vector2(180f,180f);
			Position = defaultPos;
		}
		
		public void Update (float f)
		{	
		}
	}
}

