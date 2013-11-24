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

using System.Collections; //ArrayList
using System.Collections.Generic;

namespace ApmFw
{
	/// <summary>
	/// Sprite for touch list.
	/// 動く画像をまとめて扱うクラス。スタイルシートは使わない。
	/// </summary>
	public class SpriteForTouchList : SpriteForTouches
	{
		public List<SpriteForTouch> Sprites{get;set;}
		public bool TouchOn{get;set;}
		public byte NowIndex{get; private set;}
		
		public SpriteForTouchList (List<SpriteForTouch> spriteForTouchList, bool touchOn)
		{
			this.Sprites = new List<SpriteForTouch>();
			foreach (SpriteForTouch spriteForTouch in spriteForTouchList) {
				this.Sprites.Add(spriteForTouch);
			}
			this.SetUnVisible();
			this.TouchOn = touchOn;
		}
		
		public bool isHit(SpriteForTouch sprite)
		{
			float thisTX = this.Sprites[NowIndex].Sprite.Quad.T.X;
			float thisTY = this.Sprites[NowIndex].Sprite.Quad.T.Y;
			float thisSX = thisTX + this.Sprites[NowIndex].Sprite.Quad.S.X;
			float thisSY = thisTY + this.Sprites[NowIndex].Sprite.Quad.S.Y;
			
			float spriteTX = sprite.Sprite.Quad.T.X;
			float spriteTY = sprite.Sprite.Quad.T.Y;
			float spriteSX = spriteTX + sprite.Sprite.Quad.S.X;
			float spriteSY = spriteTY + sprite.Sprite.Quad.S.Y;
			
			if(isVisible() && sprite.Sprite.Visible)
			{
				if((thisTX <=  spriteSX && thisSX >=  spriteTX)
				   || (thisTX >=  spriteSX && thisSX <=  spriteTX) )
				{
//					if(thisTY <=  spriteSY &&
//				   thisSY >=  spriteSY  ||
//				   thisTY >=  spriteTY &&
//				   thisSY <=  spriteTY  )
//					{
								return true;
					}
//				}
			}
			return false;
		}
		
		/// <summary>
		/// Adds to scene.
		/// Scene にすべてのSpriteをAddする。
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public override void AddToScene(Scene scene) {
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				scene.AddChild(spriteForTouch.Sprite);
			}
			this.SetUnVisible();
		}
		
		/// <summary>
		/// Removes from scene.
		/// Scene からすべてのSpriteをremoveする。
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public override void RemoveFromScene(Scene scene) {
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				scene.RemoveChild(spriteForTouch.Sprite,true);
			}
		}
		
		/// <summary>
		/// Sets the visible.
		/// Spritesの渡されたindexのSpriteだけVisible = trueにする
		/// </summary>
		/// <returns>
		/// index
		/// </returns>
		/// <param name='index'>
		/// Index.
		/// </param>
		public override byte SetVisible(byte index) {
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				spriteForTouch.Sprite.Visible = false;
			}
			if(this.Sprites.Count <= index){
				index = this.NowIndex;
			}
			this.NowIndex = index;
			this.Sprites[index].Sprite.Visible = true;
			this.BeforeX = this.Sprites[index].Sprite.Quad.T.X;
			this.BeforeY = this.Sprites[index].Sprite.Quad.T.Y;
			return index;
		}
		
		/// <summary>
		/// Sets the visible.
		/// visible = true -> Spritesの渡されたindexのSpriteだけVisible = trueにする
		/// visible = false -> すべて非表示
		/// </summary>
		/// <returns>
		/// index
		/// </returns>
		/// <param name='index'>
		/// Index.
		/// </param>
		/// <param name='visible'>
		/// Visible.
		/// </param>
		public override byte SetVisible(byte index, bool visible) {
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				spriteForTouch.Sprite.Visible = false;
			}
			if(this.Sprites.Count <= index){
				index = this.NowIndex;
			}
			if (visible) {
				this.NowIndex = index;
				this.Sprites[index].Sprite.Visible = true;
			}
			return index;
		}
		
		/// <summary>
		/// Sets the un visible.
		/// </summary>
		public override void SetUnVisible() {
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				spriteForTouch.Sprite.Visible = false;
			}
		}
		
		
		//表示がされていなかったら
		public bool isVisible()
		{
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				if(spriteForTouch.Sprite.Visible != false)
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Gos to touch position.
		/// タッチ位置に移動する
		/// </summary>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		public override void GoToTouchPosition(TouchData touchData){
			float x = this.CalcTuchPositionToSpriteQTX(touchData);
			float y = this.CalcTuchPositionToSpriteQTY(touchData);
			foreach (SpriteForTouch spriteForTouch in this.Sprites) {
				spriteForTouch.Sprite.Quad.T.X = x;
				spriteForTouch.Sprite.Quad.T.X = y;
			}
		}
		
		/// <summary>
		/// Calculates the tuch position to sprite.Quad.T.X
		/// TouchData.XをspriteUV.Quad.T.Xに変換するメソッド
		/// </summary>
		/// <returns>
		/// The tuch position to sprite QTX
		/// </returns>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		private float CalcTuchPositionToSpriteQTX(TouchData touchData){
			//0.5はTouchData.Xが-0.5-0.5なので調整
			if(this.Sprites[this.NowIndex].IsStr){
				return(float)((touchData.X+0.5)*Const.DISPLAY_WIDTH - this.Sprites[this.NowIndex].Sprite.Quad.S.X - this.Sprites[this.NowIndex].PositionX);
			} else {
				return(float)((touchData.X+0.5)*Const.DISPLAY_WIDTH - this.Sprites[this.NowIndex].Sprite.Quad.S.X/2);
			}
		}
		
		/// <summary>
		/// Calculates the tuch position to sprite.Quad.T.Y
		/// TouchData.YをspriteUV.Quad.T.Yに変換するメソッド
		/// </summary>
		/// <returns>
		/// The tuch position to sprite QTY
		/// </returns>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		private float CalcTuchPositionToSpriteQTY(TouchData touchData){
			if(this.Sprites[this.NowIndex].IsStr) {
				return(float)((1.5-touchData.Y)*Const.DISPLAY_HEIGHT + this.Sprites[this.NowIndex].Sprite.Quad.S.Y/2 - this.Sprites[this.NowIndex].PositionY);
			} else {
				return(float)((0.5-touchData.Y)*Const.DISPLAY_HEIGHT - this.Sprites[this.NowIndex].Sprite.Quad.S.Y/2);
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
		public override bool TouchSprite(TouchData touchData){
			if (this.TouchOn) {
				if ((this.Sprites[this.NowIndex].Sprite.Quad.T.X - this.Sprites[this.NowIndex].Sprite.Quad.S.X/2 < this.CalcTuchPositionToSpriteQTX(touchData) && this.CalcTuchPositionToSpriteQTX(touchData) < this.Sprites[this.NowIndex].Sprite.Quad.T.X + this.Sprites[this.NowIndex].Sprite.Quad.S.X/2) &&
					    (this.Sprites[this.NowIndex].Sprite.Quad.T.Y - this.Sprites[this.NowIndex].Sprite.Quad.S.Y/2 < this.CalcTuchPositionToSpriteQTY(touchData) && this.CalcTuchPositionToSpriteQTY(touchData) < this.Sprites[this.NowIndex].Sprite.Quad.T.Y + this.Sprites[this.NowIndex].Sprite.Quad.S.Y/2)){
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

