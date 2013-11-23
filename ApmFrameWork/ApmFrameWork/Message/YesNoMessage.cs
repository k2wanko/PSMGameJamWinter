// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using Sce.PlayStation.Core.Imaging;//color //font
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


using ApmFw;

namespace ApmFw
{
	/// <summary>
	/// Yes No Message.
	/// Yes Noメッセージウィンドウとその文字を表示するクラス
	/// </summary>
	public class YesNoMessage
	{
		private bool firstDraw = true;
		public SpriteForTouch YesNoCursor{get; private set;}
		public byte CursorPosition{get; private set;}
		private SpriteForTouch choseBox;
		private SpriteForTouch yesNoMessage;
		public SpriteForTouch YesTouch{get; private set;}
		public SpriteForTouch NoTouch{get; private set;}
		private const float gridSize = 48;
		
		private Font font = new Font(Const.DEFAULT_FONT, Const.FONT_SIZE_MESSAGE, FontStyle.Regular); //日本語使う
		
		public YesNoMessage ()
		{
			this.CursorPosition = 0;
		}
		
		/// <summary>
		/// Add Yes No Window on scene.
		/// Yes No ウィンドウをシーンに追加
		/// </summary>
		/// <param name='str'>
		/// String.
		/// </param>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public void YesNo(String str,Scene scene){
			//just do the first time
			if (this.firstDraw){
				this.choseBox = new SpriteForTouch();
				this.yesNoMessage = new SpriteForTouch();
				this.YesNoCursor  = new SpriteForTouch();
				this.YesTouch = new SpriteForTouch();
				this.NoTouch = new SpriteForTouch();
				this.choseBox.DrawSprite("choseBox.png",6,3,Const.GRID_SIZE*8, Const.GRID_SIZE*3,scene);
				this.yesNoMessage.DrawSprite(str,
										//strPositionX,
										(10f-font.GetTextWidth(str)*Const.GRID_NUM_X/(Const.DISPLAY_WIDTH*2))*Const.FIX,
										3.5f*Const.FIX,
										Const.FONT_SIZE_MESSAGE,
										new ImageColor(255,255,255,255),
										scene);
				this.YesNoCursor.DrawSprite("cursorRight.png",6.5f*Const.FIX,4.67f*Const.FIX,Const.GRID_SIZE*Const.FIX/2, Const.GRID_SIZE*Const.FIX/2,scene);
				this.YesTouch.DrawSprite("yesBtn.png",7*Const.FIX,4.5f*Const.FIX,Const.GRID_SIZE*2*Const.FIX, Const.GRID_SIZE*Const.FIX,scene);
				this.YesTouch.TouchOn = true;
				this.NoTouch.DrawSprite("noBtn.png",11*Const.FIX,4.5f*Const.FIX,Const.GRID_SIZE*2*Const.FIX, Const.GRID_SIZE*Const.FIX,scene);
				this.NoTouch.TouchOn = true;
				this.firstDraw = false; //done the first time
			}else{
				//何もしない
			}
		}
		
		/// <summary>
		/// Changes the yes only.
		/// Yes だけのメッセージウィンドウに作り変えます。
		/// </summary>
		/// <param name='cursorPosition'>
		/// Cursor position.
		/// デフォルトが(内部的に)Yesなら -> 0, Noなら -> 1
		/// </param>
		public void ChangeYesOnly(byte cursorPosition) {
			this.NoTouch.Sprite.Visible = false;
			this.YesTouch.Sprite.Quad.T.X = Const.GRID_SIZE*8.75f*Const.FIX;
			this.MoveCursorTo(cursorPosition);
		}
		
		/// <summary>
		/// Moves the cursor to.
		/// trueを渡すとYes. falseでNoにカーソルが移動します。
		/// </summary>
		/// <param name='toYes'>
		/// To yes.
		/// </param>
		public void MoveCursorTo(bool toYes) {
			if (toYes) {
				this.YesNoCursor.Sprite.Quad.T.X = 6.5f*Const.GRID_SIZE*Const.FIX;
				this.CursorPosition = 0;
			} else {
				this.YesNoCursor.Sprite.Quad.T.X = 10.5f*Const.GRID_SIZE*Const.FIX;
				this.CursorPosition = 1;
			}
		}
		
		/// <summary>
		/// Moves the cursor to Yes when yes only mode.
		/// ボタンがYes1つだけの時にカーソルを移動させる
		/// </summary>
		/// <param name='cursorPosition'>
		/// Cursor position.
		/// </param>
		public void MoveCursorTo(byte cursorPosition) {
			this.YesNoCursor.Sprite.Quad.T.X = Const.GRID_SIZE*7.85f*Const.FIX;
			this.CursorPosition = cursorPosition;
		}
		
		/// <summary>
		/// Cursors the position is yes.
		/// カーソルがYesに合ってたらtrue. Noならfalse.
		/// </summary>
		/// <returns>
		/// The position is yes.
		/// </returns>
		public bool IsYes(){
			return (this.CursorPosition == 0) ? true : false;
		}
		
		/// <summary>
		/// Removes the yes no message.
		/// メッセージを削除するときに呼び出す。
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public void RemoveYesNoMessage(Scene scene){
			this.YesNoCursor.Sprite.Quad.T.X = 6.5f*gridSize*Const.FIX;
			this.YesNoCursor.Sprite.Quad.T.Y = (279.84f + Const.GRID_Y_REST)*Const.FIX;
			scene.RemoveChild(this.NoTouch.Sprite,true);
			scene.RemoveChild(this.YesTouch.Sprite,true);
			scene.RemoveChild(this.yesNoMessage.Sprite,true);
			scene.RemoveChild(this.choseBox.Sprite,true);
			scene.RemoveChild(this.YesNoCursor.Sprite,true);
			this.CursorPosition = 0;
			this.choseBox = null;
			this.yesNoMessage = null;
			this.YesNoCursor = null;
			this.YesTouch = null;
			this.NoTouch = null;
			this.firstDraw = true;
			GC.Collect();//強制的にすべてのジェネレーションのガベージ コレクションを行う
		}
	}//class Message
}//namespace ApmFw

