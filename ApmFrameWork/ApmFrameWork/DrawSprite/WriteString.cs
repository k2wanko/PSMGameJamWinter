// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////



using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;

namespace ApmFw
{
	/// <summary>
	/// Write string.
	/// 文字列(のsprite)を作成するクラス
	/// </summary>
	public class WriteString
	{
		
		//private static GraphicsContext graphics;
		
		public WriteString ()
		{
		}
	
		
		/// <summary>
		/// Draws the sprite. and Add the scene.
		/// 文字列(のsprite)を作成し、sceneに追加するメソッド
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='drawStr'>
		/// Draw string.
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='fontSize'>
		/// Font size.
		/// </param>
		/// <param name='fontColor'>
		/// Font color.
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public static SpriteUV DrawSprite (String drawStr,float positionX, float positionY,
		                                   int fontSize,ImageColor fontColor, Scene scene){
			SpriteUV sprite = DrawSprite(drawStr,positionX, positionY, fontSize, fontColor);
			//sceneにspriteを追加
			scene.AddChild(sprite);
			
			return sprite;
		}//spriteUV drawString
		
		
		/// <summary>
		/// Draws the sprite. and Add the scene.
		/// 文字列(のsprite)を作成するメソッド
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='drawStr'>
		/// Draw string.
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='fontSize'>
		/// Font size.
		/// </param>
		/// <param name='fontColor'>
		/// Font color.
		/// </param>
		public static SpriteUV DrawSprite (String drawStr,float positionX, float positionY,
		                                   int fontSize,ImageColor fontColor){
			//Director.Initialize(); //重要なんで最初にinitializeしようね。GameEngine2Dのために必要（たぶんほかにも）
			//Scene  //Sce.Pss.HighLevel.GameEngine2DのScene()
			//scene.Camera.SetViewFromViewport(); //CameraをDisplayで使う たぶん画面サイズ -> 3DCGソフトでいうところのカメラ。それの移してる範囲=画面サイズ
			positionX = Const.DISPLAY_WIDTH - Const.DISPLAY_WIDTH*(Const.GRID_NUM_X-positionX)/Const.GRID_NUM_X;
			positionY = Const.DISPLAY_HEIGHT - Const.DISPLAY_HEIGHT*(Const.GRID_NUM_Y-positionY)/Const.GRID_NUM_Y;
			//the Director's OpenGL context　たぶん画面サイズの幅
			//var width = (int)Const.getVITA_DISPLAY_WIDTH();
			//var height = (int)Const.getVITA_DISPLAY_HEIGHT();
			
			//Font font = new Font(FontAlias.System, fontSize, FontStyle.Regular);
			Font font = new Font(Const.DEFAULT_FONT, fontSize, FontStyle.Regular); //日本語使う
			var width = font.GetTextWidth(drawStr);
			var height = font.GetTextWidth("oo");
			//Console.WriteLine(width + " : " + height);
			
			//Image classはimageデータを保つよ～。　PNG or JPGなど
			//今回はblankのnew Image でも、これ作らないと img.DrawTextが使えない
			Image img = new Image(ImageMode.Rgba,
			                      new ImageSize(width,height), //固定で。たぶん描画範囲
			                      new ImageColor(255,0,0,0));//blankなので変更しても意味なし
			//ここで文字を作ってる
			img.DrawText(drawStr,
			             fontColor,
			             font,
			             new ImagePosition(0, 0)); //画面の位置
			
			//textureを作る
			Texture2D texture = new Texture2D(width,
			                                  height,
			                                  false,
			                                  PixelFormat.Rgba);
			
			//Texture2D を使うためにimageからpixelデータに変換(img.ToBuffer())
			//それをtexture.SetPixelsでtextureにPixcelデータを貼り付け
			texture.SetPixels(0, img.ToBuffer());
			//で一覧のimgの処理を実行
			img.Dispose();
			
			//新しいTexture作るときはTextureInfoも作らないとね
			TextureInfo ti = new TextureInfo();
			ti.Texture = texture;
			
			//スプライト（イメージパターン）を作る。まぁ、テクスチャだし
			SpriteUV sprite = new SpriteUV();
			sprite.TextureInfo = ti;
			
			//テクスチャーの貼り付けられた長方形(quad.S)を作成。サイズはImage img = new Imageのとこ。たぶん
			sprite.Quad.S = ti.TextureSizef;
			sprite.CenterSprite();
			//sprite.Position = scene.Camera.CalcBounds().Center;
			
			positionX = positionX + sprite.Quad.S.X/2;
			positionY = Const.DISPLAY_HEIGHT- positionY - sprite.Quad.S.Y;
			
			sprite.Position = new Vector2(positionX,positionY);
			
			return sprite;
		}//spriteUV DrawSprite
	}
}



