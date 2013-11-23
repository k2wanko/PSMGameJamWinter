
using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;

namespace PSMGameJamWinter2013
{
	//指定しした大きさに必ずテクスチャを拡縮して描画できるスプライト
	public class DrawRectSprite
	{
		public DrawRectSprite ()
		{
		}
		
		public static SpriteUV LoadSprite(String strPicture
		                                  ,float sizeX
		                                  ,float sizeY)
		{			
			//Texture作成
			Texture2D texture = new Texture2D(strPicture, false);
			
			//新しいTexture作るときはTextureInfoも作らないとね
			TextureInfo ti = new TextureInfo();
			ti.Texture = texture;
			
			//スプライト（イメージパターン）を作る。まぁ、テクスチャだし
			SpriteUV sprite = new SpriteUV();
			sprite.TextureInfo = ti;
			
			//テクスチャーの貼り付けられた長方形(quad.S)を作成。サイズはImage img = new Imageのとこ。たぶん
			if(sizeX == 0 || sizeY ==0){
				sprite.Quad.S = ti.TextureSizef; //画像のオリジナルサイズサイズ
			}else{
				sprite.Quad.S = new Vector2(sizeX,sizeY);
			}
			sprite.CenterSprite();
			sprite.Position = new Vector2(0,0);
		
			return sprite;
		}
	}
}

