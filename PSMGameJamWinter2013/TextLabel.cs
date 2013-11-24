using System;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Graphics;

namespace PSMGameJamWinter2013
{
	public class TextLabel : BaseSprite
	{
		
		
		
		public TextLabel (string text)
		{
			   //var width = Director.Instance.GL.Context.GetViewport().Width;
			   //var height = Director.Instance.GL.Context.GetViewport().Height;
			
			   //this.TextureInfo = ti;
		}
		
		public void setText(string text) {
			var width = 200;
			var height = 60;
			Image img = new Image(ImageMode.Rgba, new ImageSize(width,height),
			                         new ImageColor(255,0,0,0));
			   img.DrawText("" + text, 
			                new ImageColor(255,0,0,255),
			                new Font(FontAlias.System,170,FontStyle.Regular),
			                new ImagePosition(0,150));
			  
			   texture2d = new Texture2D(width,height,false,
			                                     PixelFormat.Rgba);
			   texture2d.SetPixels(0,img.ToBuffer());
			   img.Dispose();
				Sce.PlayStation.HighLevel.GameEngine2D.Base.TextureInfo ti = new Sce.PlayStation.HighLevel.GameEngine2D.Base.TextureInfo(texture2d);
			   this.TextureInfo = ti;
		}
	}
}

