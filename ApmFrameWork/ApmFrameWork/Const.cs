// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Text;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using I18N.CJK;   // s-jis用
 


/// <summary>
/// Const. LibやFrameWorkに必要な定数
/// </summary>
namespace ApmFw
{
	public class Const
	{
		//static System.Text.Encoding sjisEnc 
		//string str0 = System.Text.Encoding.GetEncoding(932).GetString(System.Text.Encoding.GetEncoding(932).GetBytes("aaあ"));
		//static System.IO.StreamReader reader = new System.IO.StreamReader("/Application/save/saveData.xml",new CP932());
		//static System.Text.Encoding sjisEnc = System.Text.Encoding.GetEncoding(932);
		
		//グローバル変数の代わり
		/// <summary>
		/// The NEW_ GAME_ FLAG.
		/// ロード時に利用する
		/// </summary>
		public static bool NEW_GAME_FLAG{get;set;}
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ApmFw.Const"/> GLOBAL_O_ BTN.
		/// いろんな用途に使う
		/// </summary>
		/// <value>
		/// <c>true</c> if GLOBA l_ o_ BT; otherwise, <c>false</c>.
		/// </value>
		public static bool GLOBAL_O_BTN{get;set;}
		//VOICE
		/// <summary>
		/// The VOICE_ AUTO.
		/// </summary>
		public static bool VOICE_AUTO{get;set;}
		/// <summary>
		/// The LEFTCHARACTER.
		/// ノベルシーンの左キャラクターを決める変数
		/// </summary>
		public static byte LEFTCHARACTER{get;set;}
		/// <summary>
		/// The RIGHTCHARACTER.
		/// ノベルシーンの右キャラクターを決める変数
		/// </summary>
		public static byte RIGHTCHARACTER{get;set;}
		/// <summary>
		/// The NOVELID.
		/// ノベルid 五桁
		/// </summary>
		public static int NOVELID{get;set;}
		/// <summary>
		/// The nextscene.
		/// シーン切り替えで次のシーンを格納
		/// </summary>
		public static NextScene Nextscene{get;set;}
		/// <summary>
		/// The change scene.
		/// シーンを切り替えるフラグ
		/// </summary>
		public static Boolean ChangeScene{get;set;}
		/// <summary>
		/// The DISPLAY_ WIDTH.
		/// 画面幅
		/// </summary>
		public static float DISPLAY_WIDTH{get; private set;} //960(VITA)
		/// <summary>
		/// The DISPLAY_ HEIGH.
		/// 画面の高さ
		/// </summary>
		public static float DISPLAY_HEIGHT{get; private set;} //544
		/// <summary>
		/// The GRID_ Y_ REST.
		/// グリッドサイズのY方向にはみ出た分
		/// </summary>
		public static float GRID_Y_REST{get;set;}
		/// <summary>
		/// The GAME of TIME_COUNT.
		/// </summary>
		public static int TIME_COUNT{get;set;}
		/// <summary>
		/// The GRID_NUM_Y.
		/// Displayの分割数(高さ)
		/// </summary>
		public static float GRID_NUM_Y{get; private set;}
		/// <summary>
		/// FONT_ SIZE_ TOUCH.
		/// VITA -> 41
		/// Touchできる文字のサイズ
		/// </summary>
		public static int FONT_SIZE_TOUCH{get; private set;}
		/// <summary>
		/// FONT_ SIZE_ MESSAGE.
		/// VITA -> 21
		/// メッセージ内の文字サイズ
		/// </summary>
		public static int FONT_SIZE_MESSAGE{get; private set;}//文字(等幅)+1
		/// <summary>
		/// Gets or sets the GRID_SIZE.
		/// VITA -> 48
		/// </summary>
		/// <value>
		/// The GRI d_ SIZ.
		/// </value>
		public static float GRID_SIZE{get; private set;}
		
		public static float FIX{get;set;}
		
		//定数
		/// <summary>
		/// The GRID_ NUM_X.
		/// Displayの分割数(幅)
		/// </summary>
//		public const float GRID_NUM_X = 20;
		public const float GRID_NUM_X = 960;
		/// <summary>
		/// STRING_ NUM_ Of_ LINE.
		/// VITA -> 43
		/// </summary>
		public const int STRING_NUM_OF_LINE = 43; //文字列一行の長さ（全角の数）　//ipam.ttf
		/// <summary>
		/// Constant DEFAULT_ FONT.
		/// IPA Font 利用規約。ダウンロードサイト
		/// http://ipafont.ipa.go.jp/ipafont/download.html
		/// </summary>
		public const string DEFAULT_FONT = "/Application/FONT/ipam.ttf";
		/// <summary>
		/// Constant SLEEP_ TIME.
		/// ボタン連打押しさせないとかのWait timeのこと
		/// </summary>
		public const int SLEEP_TIME = 150;
		/// <summary>
		/// Constant PNG.
		/// </summary>
		public const string PNG = ".png";
		/// <summary>
		/// Constant NONE.
		/// </summary>
		public const string NONE = "none";
		
		
		public Const ()
		{
			ChangeScene = false;
			VOICE_AUTO = false;
		}
		
		/// <summary>
		/// Set the DISPLAY_SIZE.
		/// </summary>
		public static void Set_DISPLAY(){
			DISPLAY_WIDTH = Director.Instance.GL.Context.GetViewport().Width;
			DISPLAY_HEIGHT = Director.Instance.GL.Context.GetViewport().Height;
			
			GRID_SIZE = DISPLAY_WIDTH/GRID_NUM_X;
			GRID_NUM_Y = DISPLAY_HEIGHT/GRID_SIZE;
			
			Set_GRID_Y_REST();
			
			FIX = 48/GRID_SIZE;
			
			//メッセージの文字の長さを修正
			FONT_SIZE_MESSAGE = (int)System.Math.Floor(21*DISPLAY_WIDTH/960); //Vita(960)で21
			FONT_SIZE_TOUCH = (int)System.Math.Floor(41*DISPLAY_WIDTH/960); //Vita(960)で41
		}

		/// <summary>
		/// Set the GRID_ Y_REST.
		/// 分割したグリッドの半端部分(高さ)のpixel
		/// </summary>
		public static void Set_GRID_Y_REST(){
			GRID_Y_REST = DISPLAY_HEIGHT-(GRID_SIZE*(float)System.Math.Floor(GRID_NUM_Y));
		}

//		public int GetByteCount(string str){
//			str = "シフトJISでは何byte？";
//		
//			//string str0 = System.Text.Encoding.GetEncoding(932).GetString(System.Text.Encoding.GetEncoding(932).GetBytes("aaあ"));
//			
//			int num = System.Text.Encoding.GetEncoding(932).GetByteCount(str);
//		
//			Console.WriteLine(num);
//			// 出力：21
//		
//			Console.WriteLine(str.Length);
//			// 出力：14
//			
//			return num;
//		}
		
		/// <summary>
		/// To the round down.
		/// dValueをiDigitsの有効桁数で表示(切り捨て)
		/// </summary>
		/// <returns>
		/// The round down.
		/// </returns>
		/// <param name='dValue'>
		/// D value.
		/// </param>
		/// <param name='iDigits'>
		/// I digits.
		/// </param>
		public static double ToRoundDown(double dValue, int iDigits) {
			double dCoef = System.Math.Pow(10, iDigits);
			return dValue > 0 ? System.Math.Floor  (dValue * dCoef) / dCoef:
								System.Math.Ceiling(dValue * dCoef) / dCoef;
		}
		
		/// <summary>
		/// X the button.
		/// タッチパネル用Xボタンを右下に配置
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		/// <param name='scene'>
		/// Scene.
		/// </param>
		//public static SpriteForTouch xBtn(Sce.PlayStation.HighLevel.GameEngine2D.Scene scene){
		public static SpriteForTouch XBtn(Sce.PlayStation.HighLevel.GameEngine2D.Scene scene){
			SpriteForTouch spriteForTouch = new SpriteForTouch();
			spriteForTouch.DrawSprite("backBtn.png", 19*Const.FIX, 10.333f*Const.FIX,48f,48f,scene,true);
			return spriteForTouch;
		}
		
//#if DEBUG
	public const byte testVoice = 255;
//#endif
	}
}

