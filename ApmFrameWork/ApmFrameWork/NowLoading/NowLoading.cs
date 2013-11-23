// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;

using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace ApmFw
{
	/// <summary>
	/// Now loading.
	/// NowLodingを表示するクラス
	/// </summary>
	public class NowLoading
	{
		public static bool NowLoadingFlag{get;set;}
		public static SpriteUV NowLoadingSprite{get;set;}
		public static SpriteUV[] NowLoadingDotSprite{get;set;}
		public static SpriteUV BackGround{get;set;}
		private static Scene sceneLowding = new Scene();
		
		/// <summary>
		/// Nows the loading inisialize.
		/// FlameWork最初に呼び出し
		/// </summary>
		public static void NowLoadingInisialize ()
		{
			//NowLoading
			NowLoadingSprite = WriteString.DrawSprite("Now Loading",
									12*Const.FIX,
									10*Const.FIX,
									41,
									new ImageColor(255,255,255,255));
			
			NowLoadingDotSprite = new SpriteUV[3];
			for(byte i = 0; i < 3; i++){
				NowLoadingDotSprite[i] =  WriteString.DrawSprite(".",
									(17 + i)*Const.FIX,
									10*Const.FIX,
									41,
									new ImageColor(255,255,255,255));
			}
			
		}
		
		
		/// <summary>
		/// Add NOW LOADING.
		/// NOW LOADINGの描画
		/// </summary>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		public static void NOW_LOADING(Sce.PlayStation.HighLevel.GameEngine2D.Scene scene){
			sceneLowding = scene;
			//背景
			BackGround = DrawPicture.DrawSprite("black.png",0,0,Const.DISPLAY_WIDTH,Const.DISPLAY_HEIGHT,sceneLowding);
			sceneLowding.AddChild(NowLoadingSprite);
			for(byte i = 0; i < 3; i++){
				sceneLowding.AddChild(NowLoadingDotSprite[i]);
			}
			NowLoadingFlag = true;
			
		}
		
		/// <summary>
		/// Moves the dot.
		/// FlameWorkで使用
		/// </summary>
		public static void MoveDot(){
			//Updateだけ最初(残りの必要な実行は最後)
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Update();
			
			switch(Const.TIME_COUNT%4){
			case 0:
				NowLoadingDotSprite[0].Visible = true;
				NowLoadingDotSprite[1].Visible = true;
				NowLoadingDotSprite[2].Visible = true;
				break;
			case 1:
				NowLoadingDotSprite[0].Visible = false;
				NowLoadingDotSprite[1].Visible = true;
				NowLoadingDotSprite[2].Visible = true;
				break;
			case 2:
				NowLoadingDotSprite[0].Visible = true;
				NowLoadingDotSprite[1].Visible = false;
				NowLoadingDotSprite[2].Visible = true;
				break;
			case 3:
				NowLoadingDotSprite[0].Visible = true;
				NowLoadingDotSprite[1].Visible = true;
				NowLoadingDotSprite[2].Visible = false;
				break;
			default:
				NowLoadingDotSprite[0].Visible = true;
				NowLoadingDotSprite[1].Visible = true;
				NowLoadingDotSprite[2].Visible = true;
				break;
			}
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Render();
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.SwapBuffers();
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.PostSwap();
		}
		
		/// <summary>
		/// Removes the now loading.
		/// NowLoadingを消す。
		/// </summary>
		public static void RemoveNowLoading(){
			sceneLowding.RemoveChild(BackGround,true);
			sceneLowding.RemoveChild(NowLoadingSprite,true);
			sceneLowding.RemoveChild(NowLoadingDotSprite[0],true);
			sceneLowding.RemoveChild(NowLoadingDotSprite[1],true);
			sceneLowding.RemoveChild(NowLoadingDotSprite[2],true);
			BackGround = null;
			sceneLowding = null;
			NowLoadingFlag = false;
		}
	}
}

