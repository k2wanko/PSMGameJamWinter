using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using System.IO;
using ApmFw;

namespace PSMGameJamWinter2013
{
	public class BaseSprite : SpriteUV
	{
		
		Texture2D texture2d = null;
		TextureInfo[] textureInfoArray = new TextureInfo[10];
		int texture_num = 0;
		
		public BaseSprite ()
		{
			
		}
		
		public void setTexture(int i)
		{
			this.texture_num = i;
			this.TextureInfo = textureInfoArray[texture_num];
			//sQuad.S = this.TextureInfo.TextureSizef;
		}
		
		public void setTexture(string path)
		{
			this.TextureInfo = new TextureInfo( new Texture2D("/Application/resources/" + path, false) );
		}
		
		public void setTextureArray(string[] array)
		{
			int i;
			for(i = 0; i < array.Length; i++)
			{	
				GameLog.DebugLog.Log("" + i);
				string path = array[i];
				
				textureInfoArray[i] = new TextureInfo( new Texture2D("/Application/resources/" + path, false) );
			}
			
			this.TextureInfo = textureInfoArray[texture_num];
			
		}
		
		public void setS(int i)
		{
				
		}
		
		public float setX(float x)
		{
			return Quad.T.X = x;
		}
		
		public float setY(float y)
		{
			return Quad.T.Y = y;
		}
		
		public void moveX(float x)
		{
			Quad.T.X += x;
		}
		
		public void moveY(float y)
		{
			Quad.T.X += y;
		}
	}
}

