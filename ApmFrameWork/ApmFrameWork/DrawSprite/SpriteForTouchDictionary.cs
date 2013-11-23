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
	/// Sprite for touch dictionary.
	/// 動く画像をまとめて扱うクラス。スタイルシートは使わない。
	/// </summary>
	public class SpriteForTouchDictionary : SpriteForTouches
	{
		public Dictionary<string,SpriteForTouch> Sprites{get;set;}
		public bool TouchOn{get;set;}
		public string NowKey{get; private set;}
		
		public SpriteForTouchDictionary (List<string> keyList, List<SpriteForTouch> spriteForTouchList, bool touchOn)
		{
			this.Sprites = new Dictionary<string, SpriteForTouch>();
			//keyListの数でチェックする。keyListとspriteForTouchListの数が違うとバグる(わざとバグらせる=nullを入れる)
			if (keyList.Count == spriteForTouchList.Count) {
				for (int i = 0; i < keyList.Count; i++) {
					this.Sprites.Add(keyList[i],spriteForTouchList[i]);
				}
			}
			this.SetUnVisible();
			this.TouchOn = touchOn;
		}
		
		/// <summary>
		/// Adds to scene.
		/// Scene にすべてのSpriteをAddする。
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public override void AddToScene(Scene scene) {
			foreach (string keyTemp in this.Sprites.Keys) {
				scene.AddChild(this.Sprites[keyTemp].Sprite);
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
			foreach (string keyTemp in this.Sprites.Keys) {
				scene.RemoveChild(this.Sprites[keyTemp].Sprite,true);
			}
		}
		
		/// <summary>
		/// Sets the visible.
		/// Spritesの渡されたkeyのSpriteだけVisible = trueにする
		/// </summary>
		/// <param name='key'>
		/// Key -> string
		/// </param>
		public override void SetVisible(string key) {
			if (this.Sprites.ContainsKey(key)) {
				foreach (string keyTemp in this.Sprites.Keys) {
					this.Sprites[keyTemp].Sprite.Visible = false;
				}
				this.NowKey = key;
				this.Sprites[key].Sprite.Visible = true;
				this.BeforeX = this.Sprites[key].Sprite.Quad.T.X;
				this.BeforeY = this.Sprites[key].Sprite.Quad.T.Y;
			}
		}
		
		/// <summary>
		/// Sets the visible.
		/// visible = true -> Spritesの渡されたindexのSpriteだけVisible = trueにする
		/// visible = false -> すべて非表示
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='visible'>
		/// Visible.
		/// </param>
		public override void SetVisible(string key,bool visible) {
			if (this.Sprites.ContainsKey(key)) {
				foreach (string keyTemp in this.Sprites.Keys) {
					this.Sprites[keyTemp].Sprite.Visible = false;
				}
				if (visible) {
					this.NowKey = key;
					this.Sprites[key].Sprite.Visible = true;
				}
			}
		}
		
		/// <summary>
		/// Sets the un visible.
		/// </summary>
		public override void SetUnVisible() {
			foreach (string keyTemp in this.Sprites.Keys) {
				this.Sprites[keyTemp].Sprite.Visible = false;
			}
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
			foreach (string keyTemp in this.Sprites.Keys) {
				this.Sprites[keyTemp].Sprite.Quad.T.X = x;
				this.Sprites[keyTemp].Sprite.Quad.T.X = y;
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
			if(this.Sprites[this.NowKey].IsStr){
				return(float)((touchData.X+0.5)*Const.DISPLAY_WIDTH - this.Sprites[this.NowKey].Sprite.Quad.S.X - this.Sprites[this.NowKey].PositionX);
			} else {
				return(float)((touchData.X+0.5)*Const.DISPLAY_WIDTH - this.Sprites[this.NowKey].Sprite.Quad.S.X/2);
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
			if(this.Sprites[this.NowKey].IsStr) {
				return(float)((1.5-touchData.Y)*Const.DISPLAY_HEIGHT + this.Sprites[this.NowKey].Sprite.Quad.S.Y/2 - this.Sprites[this.NowKey].PositionY);
			} else {
				return(float)((0.5-touchData.Y)*Const.DISPLAY_HEIGHT - this.Sprites[this.NowKey].Sprite.Quad.S.Y/2);
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
				if ((this.Sprites[this.NowKey].Sprite.Quad.T.X - this.Sprites[this.NowKey].Sprite.Quad.S.X/2 < this.CalcTuchPositionToSpriteQTX(touchData) && this.CalcTuchPositionToSpriteQTX(touchData) < this.Sprites[this.NowKey].Sprite.Quad.T.X + this.Sprites[this.NowKey].Sprite.Quad.S.X/2) &&
					    (this.Sprites[this.NowKey].Sprite.Quad.T.Y - this.Sprites[this.NowKey].Sprite.Quad.S.Y/2 < this.CalcTuchPositionToSpriteQTY(touchData) && this.CalcTuchPositionToSpriteQTY(touchData) < this.Sprites[this.NowKey].Sprite.Quad.T.Y + this.Sprites[this.NowKey].Sprite.Quad.S.Y/2)){
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

