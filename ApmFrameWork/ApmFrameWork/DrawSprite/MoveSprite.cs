// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////


using Sce.PlayStation.HighLevel.GameEngine2D;

namespace ApmFw
{
	/// <summary>
	/// Move sprite.
	/// 画像(sprite)を移動させるクラス
	/// </summary>
	public class MoveSprite
	{
		public MoveSprite ()
		{
		}
		
		/***************************************
		 * Sprite
		 **************************************/
		public static void Up(SpriteUV sprite, float px) {
			sprite.Quad.T.Y += px;
		}
		
		public static void Down(SpriteUV sprite, float px) {
			sprite.Quad.T.Y -= px;
		}
		
		public static void Left(SpriteUV sprite, float px) {
			sprite.Quad.T.X -= px;
		}
		
		public static void Right(SpriteUV sprite, float px) {
			sprite.Quad.T.X += px;
		}
		
		/// <summary>
		/// Stretch the specified sprite, x and y.
		/// 拡大縮小。引数値だけ+=;
		/// </summary>
		/// <param name='sprite'>
		/// Sprite.
		/// </param>
		/// <param name='x'>
		/// X.
		/// </param>
		/// <param name='y'>
		/// Y.
		/// </param>
		public static void Stretch(SpriteUV sprite, float x, float y) {
			sprite.Quad.S.X += x;
			sprite.Quad.S.Y += y;
		}
		
		/// <summary>
		/// Sets the scale.
		/// 画像のサイズをセットする。
		/// </summary>
		/// <param name='sprite'>
		/// Sprite.
		/// </param>
		/// <param name='width'>
		/// Width.
		/// </param>
		/// <param name='height'>
		/// Height.
		/// </param>
		public static void SetScale(SpriteUV sprite, float width, float height) {
			sprite.Quad.S.X = width;
			sprite.Quad.S.Y = height;
		}
		
		/// <summary>
		/// Sets the sprite positon grid x.
		/// 左上を0、下をプラスとしてX軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Xに適切な値を返すメソッド
		/// </summary>
		/// <returns>
		/// The sprite positon grid d.
		/// </returns>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridX(SpriteUV sprite, float grindNum){
			sprite.Quad.T.X = Const.GRID_SIZE*grindNum;
		}
		
		/// <summary>
		/// Sets the sprite positon grid y.
		/// 左上を0、下をプラスとしてY軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Yに適切な値を返すメソッド
		/// </summary>
		/// <returns>
		/// The sprite positon grid y.
		/// </returns>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridY(SpriteUV sprite, float grindNum){
			sprite.Quad.T.Y =
				(Const.GRID_SIZE*((float)System.Math.Floor(Const.GRID_NUM_Y)-grindNum) + Const.GRID_Y_REST) - sprite.Quad.S.Y;
		}
		
		/***************************************
		 * SpriteForTouch
		 **************************************/
		public static void Up(SpriteForTouch spriteForTouch, float px) {
			spriteForTouch.Sprite.Quad.T.Y += px;
		}
		
		public static void Down(SpriteForTouch spriteForTouch, float px) {
			spriteForTouch.Sprite.Quad.T.Y -= px;
		}
		
		public static void Left(SpriteForTouch spriteForTouch, float px) {
			spriteForTouch.Sprite.Quad.T.X -= px;
		}
		
		public static void Right(SpriteForTouch spriteForTouch, float px) {
			spriteForTouch.Sprite.Quad.T.X += px;
		}
		
		/// <summary>
		/// Stretch the specified spriteForTouch, x and y.
		/// 拡大縮小。引数値だけ+=;
		/// </summary>
		/// <param name='spriteForTouch'>
		/// Sprite for touch.
		/// </param>
		/// <param name='x'>
		/// X.
		/// </param>
		/// <param name='y'>
		/// Y.
		/// </param>
		public static void Stretch(SpriteForTouch spriteForTouch, float x, float y) {
			spriteForTouch.Sprite.Quad.S.X += x;
			spriteForTouch.Sprite.Quad.S.Y += y;
		}
		
		/// <summary>
		/// Sets the scale.
		/// 画像のサイズをセットする。
		/// </summary>
		/// <param name='spriteForTouch'>
		/// Sprite for touch.
		/// </param>
		/// <param name='width'>
		/// Width.
		/// </param>
		/// <param name='height'>
		/// Height.
		/// </param>
		public static void SetScale(SpriteForTouch spriteForTouch, float width, float height) {
			spriteForTouch.Sprite.Quad.S.X = width;
			spriteForTouch.Sprite.Quad.S.Y = height;
		}
		
		/// <summary>
		/// Sets the sprite positon grid x.
		/// 左上を0、下をプラスとしてX軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Xに適切な値を返すメソッド
		/// </summary>
		/// <param name='spriteForTouch'>
		/// Sprite for touch.
		/// </param>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridX(SpriteForTouch spriteForTouch, float grindNum){
			spriteForTouch.Sprite.Quad.T.X = Const.GRID_SIZE*grindNum;
		}
		
		/// <summary>
		/// Sets the sprite positon grid y.
		/// 左上を0、下をプラスとしてY軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Yに適切な値を返すメソッド
		/// </summary>
		/// <param name='spriteForTouch'>
		/// Sprite for touch.
		/// </param>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridY(SpriteForTouch spriteForTouch, float grindNum){
			spriteForTouch.Sprite.Quad.T.Y = 
				(Const.GRID_SIZE*((float)System.Math.Floor(Const.GRID_NUM_Y)-grindNum) + Const.GRID_Y_REST) - spriteForTouch.Sprite.Quad.S.Y;
		}
		
		/***************************************
		 * SpriteForTouches
		 **************************************/
		public static void Up(SpriteForTouchList spriteForTouches, float px) {
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.T.Y += px;
			}
		}
		
		public static void Down(SpriteForTouchList spriteForTouches, float px) {
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.T.Y -= px;
			}
		}
		
		public static void Left(SpriteForTouchList spriteForTouches, float px) {
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.T.X -= px;
			}
		}
		
		public static void Right(SpriteForTouchList spriteForTouches, float px) {
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.T.X += px;
			}
		}
		
		/// <summary>
		/// Stretch the specified spriteForTouches, x and y.
		/// 拡大縮小。引数値だけ+=;
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='x'>
		/// X.
		/// </param>
		/// <param name='y'>
		/// Y.
		/// </param>
		public static void Stretch(SpriteForTouchList spriteForTouches, float x, float y) {
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.S.X += x;
				spriteForTouch.Sprite.Quad.S.Y += y;
			}
		}
		
		/// <summary>
		/// Sets the scale.
		/// 画像のサイズをセットする。
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='width'>
		/// Width.
		/// </param>
		/// <param name='height'>
		/// Height.
		/// </param>
		public static void SetScale(SpriteForTouchList spriteForTouches, float width, float height) {
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.S.X = width;
				spriteForTouch.Sprite.Quad.S.Y = height;
			}
		}
		
		/// <summary>
		/// Sets the sprite positon grid x.
		/// 左上を0、下をプラスとしてX軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Xに適切な値を返すメソッド
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridX(SpriteForTouchList spriteForTouches, float grindNum){
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.T.X = Const.GRID_SIZE*grindNum;
			}
		}
		
		/// <summary>
		/// Sets the sprite positon grid y.
		/// 左上を0、下をプラスとしてY軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Yに適切な値を返すメソッド
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridY(SpriteForTouchList spriteForTouches, float grindNum){
			foreach (SpriteForTouch spriteForTouch in spriteForTouches.Sprites) {
				spriteForTouch.Sprite.Quad.T.Y = 
					(Const.GRID_SIZE*((float)System.Math.Floor(Const.GRID_NUM_Y)-grindNum) + Const.GRID_Y_REST) - spriteForTouch.Sprite.Quad.S.Y;
			}
		}
		
		public static void Up(SpriteForTouchDictionary spriteForTouches, float px) {
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.T.Y += px;
			}
		}
		
		public static void Down(SpriteForTouchDictionary spriteForTouches, float px) {
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.T.Y -= px;
			}
		}
		
		public static void Left(SpriteForTouchDictionary spriteForTouches, float px) {
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.T.X -= px;
			}
		}
		
		public static void Right(SpriteForTouchDictionary spriteForTouches, float px) {
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.T.X += px;
			}
		}
		
		/// <summary>
		/// Stretch the specified spriteForTouches, x and y.
		/// 拡大縮小。引数値だけ+=;
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='x'>
		/// X.
		/// </param>
		/// <param name='y'>
		/// Y.
		/// </param>
		public static void Stretch(SpriteForTouchDictionary spriteForTouches, float x, float y) {
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.S.X += x;
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.S.Y += y;
			}
		}
		
		/// <summary>
		/// Sets the scale.
		/// 画像のサイズをセットする。
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='width'>
		/// Width.
		/// </param>
		/// <param name='height'>
		/// Height.
		/// </param>
		public static void SetScale(SpriteForTouchDictionary spriteForTouches, float width, float height) {
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.S.X = width;
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.S.Y = height;
			}
		}
		
		/// <summary>
		/// Sets the sprite positon grid x.
		/// 左上を0、下をプラスとしてX軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Xに適切な値を返すメソッド
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridX(SpriteForTouchDictionary spriteForTouches, float grindNum){
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.T.X = Const.GRID_SIZE*grindNum;
			}
		}
		
		/// <summary>
		/// Sets the sprite positon grid y.
		/// 左上を0、下をプラスとしてY軸を作った時にグリッドの番号で
		/// sprite.Quad.T.Yに適切な値を返すメソッド
		/// </summary>
		/// <param name='spriteForTouches'>
		/// Sprite for touches.
		/// </param>
		/// <param name='grindNum'>
		/// Grind number.
		/// </param>
		public static void SetPositonGridY(SpriteForTouchDictionary spriteForTouches, float grindNum){
			foreach (string keyTemp in spriteForTouches.Sprites.Keys) {
				spriteForTouches.Sprites[keyTemp].Sprite.Quad.T.Y = 
					(Const.GRID_SIZE*((float)System.Math.Floor(Const.GRID_NUM_Y)-grindNum) + Const.GRID_Y_REST)
						- spriteForTouches.Sprites[keyTemp].Sprite.Quad.S.Y;
			}
		}
		
	}
}

