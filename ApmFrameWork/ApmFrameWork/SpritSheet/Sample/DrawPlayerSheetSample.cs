// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Imaging;

namespace ApmFw
{
	/// <summary>
	/// Draw player sheet.
	/// スタイルシートから描画するサンプル
	/// </summary>
	public class DrawPlayerSheetSample
	{
		private static PlayerSheetSample playerSheet = null; //このSpriteSheetを呼ぶ
		private SpriteTile spritePlayer = null; //最初に表示されるpngイラスト
		
		private int spriteOffset;
		private String spriteName;
	
		/**
		 *@param float positionX 描画する位置（画面の分割率）
		 *@param float positionY 描画する位置（画面の分割率）
		 *@param Scene scene 描画するscene
		 *ファイル名等は今クラス内に埋め込み。読み込むSpriteSheetごとにCallクラスが一つ必要
		 */
		public DrawPlayerSheetSample (float positionX,float positionY,float sizeX,float sizeY, string img, string xml, Scene scene)
		{
			playerSheet = new PlayerSheetSample(img,xml);//このSpriteSheetを呼ぶ
			spritePlayer = playerSheet.Get("Walk_left00"); //最初に表示されるpngイラスト
			//positionX = Director.Instance.GL.Context.GetViewport().Width/positionX;
			//positionY = Director.Instance.GL.Context.GetViewport().Height/positionY;
			positionX = Const.DISPLAY_WIDTH - Const.DISPLAY_WIDTH*(Const.GRID_NUM_X-positionX)/Const.GRID_NUM_X;
			positionY = Const.DISPLAY_HEIGHT - Const.DISPLAY_HEIGHT*positionY/Const.GRID_NUM_Y;
			
			spriteOffset = 0;
			spriteName = "Walk_left" + spriteOffset.ToString("00");
			
			
			//var 
			//scene.Camera.SetViewFromViewport();
			//var spriteWalker = walker.Get("Walk_left00");
			
			//spriteWalker.Position = scene.Camera.CalcBounds().Center;
			//spriteWalker.Position = new Vector2(positionX,positionY); //オブジェクトの位置
			spritePlayer.CenterSprite();
			spritePlayer.Scale = new Vector2(sizeX,sizeY); //サイズの変更
			//spriteWalker.Position = new Vector2(positionX+spriteWalker.Quad.S.X/2,positionY-spriteWalker.Quad.S.Y/2);
			spritePlayer.Position = new Vector2(0,0);
			spritePlayer.Quad.T.X = positionX;
			spritePlayer.Quad.T.Y = positionY - spritePlayer.Quad.S.Y;
			
			//sceneに追加
			scene.AddChild(spritePlayer);
			
		}// DrawPlayerSheet
		
		
		/**
		 * @param String status (initで初期化) left, right, top, bottom
		 * @return spriteWalker 位置の移動やオブジェクトの削除に必要なspriteを返す
		 */
		public SpriteTile DrawPlayer(String status){
			//Director.Instance.RunWithScene(scene,true);
			
			//受け取ったステータスで方向転換
			switch(status){
			case "init":
				spriteName = "Walk_left" + spriteOffset.ToString("00");
				//walkLeft = true;
				//spriteWalker = walker.Get("Walk_left00"); //最初に表示されるpngイラスト
				break;
			case "left":
				//walkLeft = true;
				spriteName= "Walk_left" + spriteOffset.ToString("00");
				break;
			case "right":
				//walkLeft = false;
				spriteName= "Walk_right" + spriteOffset.ToString("00");
				break;
			default:
				break;
			}
			
			spritePlayer.TileIndex2D = playerSheet.Get (spriteName).TileIndex2D;
			
			
			return spritePlayer;
		}//DrawPlayerSheet(Scene scene)
		
		/**
		 * setter
		 * @param int spriteOffset (スプライトシートのナンバリング?)
		 */
		public void SetSpriteOffset(int spriteOffset){
			this.spriteOffset = spriteOffset;
		}
		
		/**
		 * getter
		 * @return int spriteOffset
		 */ 
		public int GetSpriteOffset(){
			return this.spriteOffset;
		}
		
		public void CountSpriteOffset(){
			this.spriteOffset++;
			if(this.spriteOffset >= 18){
					this.spriteOffset = 0;
			}
		}
		
	}// class DrawPlayer(String status)
	
	
}
