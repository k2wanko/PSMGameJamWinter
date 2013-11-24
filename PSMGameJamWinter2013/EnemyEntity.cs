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
		public int pos = 0;
		public int type = 0;
		
		public EnemyEntity ()
		{
			
			setTextureArray(new string[]{"maou.png", "maou2.png", "maou.png", "wood.png"});
			Quad.S = new Vector2(80f,130f);
			Position = defaultPos;
			int i;
			for(i = 0; i < vec.Length; i++){
				vec[i] = new Vector2(defaultPos.X + ( move * i), defaultPos.Y);
			}
			setPos (pos);
			
		}
		
		public EnemyEntity (EnemyEntity ee){
			this.TextureInfo = ee.TextureInfo;
			this.Quad.S = ee.Quad.S;
			this.Position = ee.Position;
			this.vec = ee.vec;
			this.textureInfoArray = ee.textureInfoArray;
			
			pos = 0;
		}
		
		public bool Next()
		{
			pos++;
			if(pos > 4){
				pos = 0;
				return false;
			}else {
				setPos (pos);
			}
			return true;
		}
		
		public Vector2 setPos(int i)
		{	
			return Position = vec[i];
		}
		
		public void setType(int i)
		{
			this.type = i;
			this.setTexture(i);
		}
		
		public void Update (float f)
		{	
		}
	}
}

