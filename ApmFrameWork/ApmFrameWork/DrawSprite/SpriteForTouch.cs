// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace ApmFw
{
	/// <summary>
	/// Sprite for touch.
	/// 画像(sprite)をTouchできるように格納するクラス
	/// </summary>
	public class SpriteForTouch
	{
		public SpriteUV Sprite{get;set;}
		public bool TouchOn{get;set;} //defaultはTouch不可
		public float PositionX{get;set;}
		public float PositionY{get;set;}
		public bool IsStr{get; private set;} //defaultは画像に設定
		
		public SpriteForTouch ()
		{
			TouchOn = false;
		}
		
		/****************************************
		 * 描画も一緒に行う(画像)
		 ****************************************/
		/// <summary>
		/// Draws the sprite. able to touch. but default TouchOn is false.
		/// Touchできる画像のspriteを作成し、sceneに追加するメソッド。
		/// デフォルトではタッチは無効。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
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
		/// Size y. if(sizeY = 0) -> sizeY is real width of picture
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY,
		                       float sizeX, float sizeY, Scene scene) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY, sizeX, sizeY, scene),
			                       positionX,
			                       positionY,
			                       false);
		}
		
		/// <summary>
		/// Draws the sprite. able to touch. but default TouchOn is false.
		/// Touchできる画像のspriteを作成するメソッド
		/// デフォルトではタッチは無効。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
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
		/// Size y. if(sizeY = 0) -> sizeY is real width of picture
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY,
		                       float sizeX, float sizeY) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY, sizeX, sizeY),
			                       positionX,
			                       positionY,
			                       false);
		}
		
		/// <summary>
		/// Draws the sprite. able to touch. but default TouchOn is false.
		/// Touchできる画像のspriteを作成し、sceneに追加するメソッド
		/// デフォルトではタッチは無効。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
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
		public void DrawSprite(String strPicture, float positionX, float positionY, Scene scene) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY, scene),
			                       positionX,
			                       positionY,
			                       false);
		}
		
		/// <summary>
		/// Draws the sprite. able to touch. but default TouchOn is false.
		/// Touchできる画像のspriteを作成するメソッド
		/// デフォルトではタッチは無効。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY),
			                       positionX,
			                       positionY,
			                       false);
		}
		
		
		
		
		
		/// <summary>
		/// Draws the sprite. able to touch.
		/// Touchできる画像のspriteを作成し、sceneに追加するメソッド。
		/// Touch有効フラグを引数に持つ。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
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
		/// Size y. if(sizeY = 0) -> sizeY is real width of picture
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		/// <param name='touchOn'>
		/// Touch on.
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY,
		                       float sizeX, float sizeY, Scene scene, bool touchOn) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY, sizeX, sizeY, scene),
			                       positionX,
			                       positionY,
			                       false);
			this.TouchOn = touchOn;
		}
		
		/// <summary>
		/// Draws the sprite. able to touch.
		/// Touchできる画像のspriteを作成し、返すメソッド
		/// Touch有効フラグを引数に持つ。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
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
		/// Size y. if(sizeY = 0) -> sizeY is real width of picture
		/// </param>
		/// <param name='touchOn'>
		/// Touch on.
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY,
		                       float sizeX, float sizeY, bool touchOn) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY, sizeX, sizeY),
			                       positionX,
			                       positionY,
			                       false);
			this.TouchOn = touchOn;
		}
		
		/// <summary>
		/// Draws the sprite. able to touch.
		/// Touchできる画像のspriteを作成し、sceneに追加するメソッド。
		/// Touch有効フラグを引数に持つ。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
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
		/// <param name='touchOn'>
		/// Touch on.
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY, Scene scene, bool touchOn) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY, scene),
			                       positionX,
			                       positionY,
			                       false);
		}
		
		/// <summary>
		/// Draws the sprite. able to touch.
		/// Touchできる画像のspriteを作成し、返すメソッド
		/// Touch有効フラグを引数に持つ。
		/// </summary>
		/// <param name='strPicture'>
		/// String picture.
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='touchOn'>
		/// Touch on.
		/// </param>
		public void DrawSprite(String strPicture, float positionX, float positionY, bool touchOn) {
			this.SetSpriteForTouch(DrawPicture.DrawSprite(strPicture, positionX, positionY),
			                       positionX,
			                       positionY,
			                       false);
			this.TouchOn = touchOn;
		}
		
		
		/****************************************
		 * 描画も一緒に行う(文字)
		 ****************************************/
		/// <summary>
		/// Draws the sprite. able to touch. but default TouchOn is false.
		/// Touchできる画像のspriteを作成し、sceneに追加するメソッド。
		/// デフォルトではタッチは無効。
		/// </summary>
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
		public void DrawSprite(String drawStr,float positionX, float positionY,
		                       int fontSize,ImageColor fontColor, Scene scene) {
			this.SetSpriteForTouch(WriteString.DrawSprite(drawStr,positionX, positionY, fontSize,fontColor,scene),
			                       positionX,
			                       positionY,
			                       true);
		}
		
		/// <summary>
		/// Draws the sprite. able to touch. but default TouchOn is false.
		/// Touchできる画像のspriteを作成するメソッド。
		/// デフォルトではタッチは無効。
		/// </summary>
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
		public void DrawSprite(String drawStr,float positionX, float positionY, int fontSize,ImageColor fontColor) {
			this.SetSpriteForTouch(WriteString.DrawSprite(drawStr,positionX, positionY, fontSize,fontColor),
			                       positionX,
			                       positionY,
			                       true);
		}
		
		
		
		
		
		
		/// <summary>
		/// Draws the sprite. able to touch.
		/// Touchできる画像のspriteを作成し、sceneに追加するメソッド。
		/// Touch有効フラグを引数に持つ。
		/// </summary>
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
		/// <param name='touchOn'>
		/// Touch on.
		/// </param>
		public void DrawSprite(String drawStr,float positionX, float positionY,
		                       int fontSize,ImageColor fontColor, Scene scene, bool touchOn) {
			this.SetSpriteForTouch(WriteString.DrawSprite(drawStr,positionX, positionY, fontSize,fontColor,scene),
			                       positionX,
			                       positionY,
			                       true);
			this.TouchOn = touchOn;
		}
		
		/// <summary>
		/// Draws the sprite. able to touch.
		/// Touchできる画像のspriteを作成するメソッド。
		/// Touch有効フラグを引数に持つ。
		/// </summary>
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
		/// <param name='touchOn'>
		/// Touch on.
		/// </param>
		public void DrawSprite(String drawStr,float positionX, float positionY,
		                       int fontSize,ImageColor fontColor, bool touchOn) {
			this.SetSpriteForTouch(WriteString.DrawSprite(drawStr,positionX, positionY, fontSize,fontColor),
			                       positionX,
			                       positionY,
			                       true);
			this.TouchOn = touchOn;
		}
		
		
		
		
		/// <summary>
		/// Sets the sprite for touch.
		/// </summary>
		/// <param name='sprite'>
		/// Sprite.
		/// </param>
		/// <param name='positionX'>
		/// Position x.
		/// </param>
		/// <param name='positionY'>
		/// Position y.
		/// </param>
		/// <param name='imStr'>
		/// Im string. = not picture of photo
		/// </param>
		private void SetSpriteForTouch(SpriteUV sprite, float positionX, float positionY, Boolean imStr){
			this.Sprite = sprite;
			this.PositionX = Const.DISPLAY_WIDTH - Const.DISPLAY_WIDTH*(Const.GRID_NUM_X-positionX)/Const.GRID_NUM_X;
			this.PositionY = Const.DISPLAY_HEIGHT + Const.DISPLAY_HEIGHT*(Const.GRID_NUM_Y-positionY)/Const.GRID_NUM_Y;
			this.IsStr = imStr;
		}
		
		/// <summary>
		/// Gos to touch position.
		/// タッチ位置に移動する
		/// </summary>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		public void GoToTouchPosition(TouchData touchData){
			this.Sprite.Quad.T.X = this.CalcTuchPositionToSpriteQTX(touchData);
			this.Sprite.Quad.T.Y = this.CalcTuchPositionToSpriteQTY(touchData);
		}
		
		/// <summary>
		/// Calculates the tuch position to sprite.Quad.T.X
		/// TouchData.XをspriteUV.Quad.T.Xに変換するメソッド
		/// </summary>
		/// <returns>
		/// The tuch position to sprite QT.
		/// </returns>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		private float CalcTuchPositionToSpriteQTX(TouchData touchData){
			//0.5はTouchData.Xが-0.5-0.5なので調整
			if(this.IsStr) {
				return(float)((touchData.X+0.5)*Const.DISPLAY_WIDTH - this.Sprite.Quad.S.X - this.PositionX);
			} else {
				return(float)((touchData.X+0.5)*Const.DISPLAY_WIDTH - this.Sprite.Quad.S.X/2);
			}
		}
		
		/// <summary>
		/// Calculates the tuch position to sprite.Quad.T.Y
		/// TouchData.YをspriteUV.Quad.T.Yに変換するメソッド
		/// </summary>
		/// <returns>
		/// The tuch position to sprite QT.
		/// </returns>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		private float CalcTuchPositionToSpriteQTY(TouchData touchData){
			if(this.IsStr) {
				return(float)((1.5-touchData.Y)*Const.DISPLAY_HEIGHT + this.Sprite.Quad.S.Y/2 - this.PositionY);
			} else {
				return(float)((0.5-touchData.Y)*Const.DISPLAY_HEIGHT - this.Sprite.Quad.S.Y/2);
			}
		}
		
		/// <summary>
		/// Check Touchs the sprite. only touchOn = true.
		/// スプライトをタッチしたか確認する。(touchOn = trueの場合)
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='touchData'>
		/// If set to <c>true</c> touch data.
		/// </param>
		public bool TouchSprite(TouchData touchData){
			if (this.TouchOn) {
				if ((this.Sprite.Quad.T.X - this.Sprite.Quad.S.X/2 < this.CalcTuchPositionToSpriteQTX(touchData) && this.CalcTuchPositionToSpriteQTX(touchData) < this.Sprite.Quad.T.X + this.Sprite.Quad.S.X/2) &&
					    (this.Sprite.Quad.T.Y - this.Sprite.Quad.S.Y/2 < this.CalcTuchPositionToSpriteQTY(touchData) && this.CalcTuchPositionToSpriteQTY(touchData) < this.Sprite.Quad.T.Y + this.Sprite.Quad.S.Y/2)){
					return true;
				}else{
					return false;
				}
			} else {
				return false;
			}
		}
	}
}

