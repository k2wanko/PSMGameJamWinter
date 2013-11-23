using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace PSMGameJamWinter2013
{
	public class BaseSprite : SpriteUV
	{
		
		Texture2D texture2d = null;
		
		public BaseSprite ()
		{
			
		}
		
		public void setTexture(string path)
		{
			texture2d = new Texture2D("/Application/resources/" + path, false);
			this.TextureInfo = new TextureInfo(texture2d);
			
		}
		
		public void moveX()
		{
		}
		
		public void moveY()
		{
		}
	}
}

