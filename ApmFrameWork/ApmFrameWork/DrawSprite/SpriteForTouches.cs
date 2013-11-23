// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////


using System.Collections.Generic;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;


namespace ApmFw
{
	/// <summary>
	/// Sprite for touches.
	/// 動く画像をまとめて扱うクラス。スタイルシートは使わない。
	/// </summary>
	abstract public class SpriteForTouches
	{
		public float BeforeX{get; protected set;}
		public float BeforeY{get; protected set;}
		
		/// <summary>
		/// Adds to scene.
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		abstract public void AddToScene(Scene scene);
			
		/// <summary>
		/// Removes from scene.
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		abstract public void RemoveFromScene(Scene scene);
		
		/// <summary>
		/// Sets the visible.
		/// 表示するSpriteを選ぶ
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		virtual public void SetVisible(string key){}
		
		/// <summary>
		/// Sets the visible.
		/// 表示するSpriteを選ぶ(visible = false ですべて表示しない)
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='visible'>
		/// Visible.
		/// </param>
		virtual public void SetVisible(string key, bool visible){}
		
		/// <summary>
		/// Sets the visible.
		/// 表示するSpriteを選ぶ
		/// </summary>
		/// <returns>
		/// index
		/// </returns>
		/// <param name='index'>
		/// Index.
		/// </param>
		virtual public byte SetVisible(byte index){return index;}
		
		/// <summary>
		/// Sets the visible.
		/// 表示するSpriteを選ぶ(visible = false ですべて表示しない)
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
		virtual public byte SetVisible(byte index, bool visible){return index;}
		
		/// <summary>
		/// Sets the un visible.
		/// </summary>
		virtual public void SetUnVisible(){}
	
		/// <summary>
		/// Gos to touch position.
		/// タッチ位置に移動する
		/// </summary>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		abstract public void GoToTouchPosition(TouchData touchData);
	
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
		abstract public bool TouchSprite(TouchData touchData);
		
		virtual public void SetBeforePosition(float x,float y){
			this.BeforeX = x;
			this.BeforeY = y;
		}
		
	}
}

