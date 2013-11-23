using System;
using Sce.PlayStation.Core;

using ApmFw;


namespace PSMGameJamWinter2013
{
	public class EnemyEntity : Entity
	{
		
		
		public Vector2 defaultPos = new Vector2(-50, 280);
		
		
		public int move = 120;
		public Vector2[] vec = new Vector2[5];
		
		public EnemyEntity ()
		{
			
			setTextureArray(new string[]{"maou.png", "maou2.png", "maou.png", "maou2.png"});
			Quad.S = new Vector2(80f,130f);
			Position = defaultPos;
			int i;
			for(i = 0; i < vec.Length; i++){
				vec[i] = new Vector2(defaultPos.X + ( move * i), defaultPos.Y);
			}
		}
		
		public Vector2 setPos(int i)
		{	
			return Position = vec[i];
		}
		
		public void setType(int i)
		{
			this.setTexture(i);
		}
		
		public void Update (float f)
		{	
		}
	}
}

