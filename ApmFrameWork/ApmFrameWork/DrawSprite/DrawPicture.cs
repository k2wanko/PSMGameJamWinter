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


namespace ApmFw{
	/// <summary>
	/// Draw picture. Make sprite from picture or photo
	/// 画像を描画するクラス(画像をspriteに変換するクラス)
	/// </summary>
	public class DrawPicture
	{
		
		/// <summary>
		/// Draws the sprite. and Add the sprite on scene.
		/// 画像のspriteを作成し、sceneに追加するメソッド
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='strPicture'>
		/// String picture. e.g.)"hoge.jpg"
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='sizeX'>
		/// Size x. if(sizeX = 0) -> sizeX is real width of picture
		/// </param>
		/// <param name='sizeY'>
		/// Size y. if(sizeY = 0) -> sizeY is real hight of picture
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public static SpriteUV DrawSprite (String strPicture, float positionX, float positionY,
		                                   float sizeX, float sizeY, Scene scene){
			SpriteUV sprite = DrawSprite(strPicture,positionX,positionY,sizeX,sizeY);
			//sceneにspriteを追加
			scene.AddChild(sprite);
			
			return sprite;
		}
		
		/// <summary>
		/// Draws the sprite. and Add the sprite on scene.
		/// 画像のspriteを作成して返すメソッド
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='strPicture'>
		/// String picture. e.g.)"hoge.jpg"
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='sizeX'>
		/// Size x. if(sizeX = 0) -> sizeX is real width of picture
		/// </param>
		/// <param name='sizeY'>
		/// Size y. if(sizeY = 0) -> sizeY is real hight of picture
		/// </param>
		public static SpriteUV DrawSprite (String strPicture, float positionX, float positionY,
		                                   float sizeX, float sizeY){
			//Director.Initialize(); //重要なんで最初にinitializeしようね。GameEngine2Dのために必要（たぶんほかにも）
			//Scene  //Sce.Pss.HighLevel.GameEngine2DのScene()
			//scene.Camera.SetViewFromViewport(); //CameraをDisplayで使う たぶん画面サイズ -> 3DCGソフトでいうところのカメラ。それの移してる範囲=画面サイズ
			
			positionX = Const.DISPLAY_WIDTH - Const.DISPLAY_WIDTH*(Const.GRID_NUM_X-positionX)/Const.GRID_NUM_X;
			positionY = Const.DISPLAY_HEIGHT - Const.DISPLAY_HEIGHT*positionY/Const.GRID_NUM_Y;
			
			//Texture作成
			Texture2D texture = new Texture2D("/Application/resources/" + strPicture, false);
			
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
			//sprite.Position = new Vector2(positionX+sprite.Quad.S.X/2,positionY-sprite.Quad.S.Y/2); //オブジェクトの位置
			sprite.Quad.T.X = positionX;
			sprite.Quad.T.Y = positionY - sprite.Quad.S.Y;
		
			return sprite;
		}
		
		/// <summary>
		/// Draws the sprite. and Add the sprite on scene.
		/// 画像のspriteを作成し、sceneに追加するメソッド
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='strPicture'>
		/// String picture. e.g.)"hoge.jpg"
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public static SpriteUV DrawSprite (String strPicture, float positionX, float positionY, Scene scene){
			SpriteUV sprite = DrawSprite(strPicture,positionX,positionY,0,0);
			//sceneにspriteを追加
			scene.AddChild(sprite);
			
			return sprite;
		}
		
		/// <summary>
		/// Draws the sprite. and Add the sprite on scene.
		/// 画像のspriteを作成し返すメソッド
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='strPicture'>
		/// String picture. e.g.)"hoge.jpg"
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		public static SpriteUV DrawSprite (String strPicture, float positionX, float positionY){
			return DrawSprite(strPicture,positionX,positionY,0,0);
		}
		
		/// <summary>
		/// Flips the horizontal.
		/// 左右反転メソッド
		/// </summary>
		/// <param name='sprite'>
		/// Sprite.
		/// </param>
		public static void FlipHorizontal(SpriteUV sprite){
			sprite.Quad.T.X += sprite.Quad.S.X;
			sprite.Quad.S.X = -1*sprite.Quad.S.X;
		}
		
		/// <summary>
		/// Flips the vertical.
		/// 上下反転反転メソッド
		/// </summary>
		/// <param name='sprite'>
		/// Sprite.
		/// </param>
		public static void FlipVertical(SpriteUV sprite){
			sprite.Quad.T.Y += sprite.Quad.S.Y;
			sprite.Quad.S.Y = -1*sprite.Quad.S.Y;
		}
	}
}
