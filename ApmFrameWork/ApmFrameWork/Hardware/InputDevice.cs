// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic; //List

//save
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using System.Timers; //timer

using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace ApmFw
{
	public class InputDevice
	{
		public InputDevice ()
		{
		}
		
		/*************************************
		 * 十字キー
		 ************************************/
		/// <summary>
		/// Ups the key repeat.
		/// 十字キー上(リピート可)
		/// </summary>
		/// <returns>
		/// The key repeat.
		/// </returns>
		public static bool UpKeyRepeat() {
			//UPボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Up) == GamePadButtons.Up)
				? true: false;
		}
		
		/// <summary>
		/// Downs the key repeat.
		/// 十字キー下(リピート可)
		/// </summary>
		/// <returns>
		/// The key repeat.
		/// </returns>
		public static bool DownKeyRepeat() {
			//Downボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Down) == GamePadButtons.Down)
				? true: false;
		}
		
		/// <summary>
		/// Lefts the key repeat.
		/// 十字キー左(リピート可)
		/// </summary>
		/// <returns>
		/// The key repeat.
		/// </returns>
		public static bool LeftKeyRepeat() {
			//Leftボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Left) == GamePadButtons.Left)
				? true: false;
		}
		
		/// <summary>
		/// Rights the key repeat.
		/// 十字キー右(リピート可)
		/// </summary>
		/// <returns>
		/// The key repeat.
		/// </returns>
		public static bool RightKeyRepeat() {
			//Rightボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Right) == GamePadButtons.Right)
				? true: false;
		}
		
		/// <summary>
		/// Ups the key.
		/// 十字キー上(リピート不可)
		/// </summary>
		/// <returns>
		/// The key.
		/// </returns>
		public static bool UpKey() {
			//UPボタン
			return (Input2.GamePad0.Up.Press);
		}
		
		/// <summary>
		/// Downs the key.
		/// 十字キー下(リピート不可)
		/// </summary>
		/// <returns>
		/// The key.
		/// </returns>
		public static bool DownKey() {
			//Downボタン
			return (Input2.GamePad0.Down.Press);
		}
		
		/// <summary>
		/// Lefts the key.
		/// 十字キー左(リピート不可)
		/// </summary>
		/// <returns>
		/// The key.
		/// </returns>
		public static bool LeftKey() {
			//Leftボタン
			return (Input2.GamePad0.Left.Press);
		}
		
		/// <summary>
		/// Rights the key.
		/// 十字キー右(リピート不可)
		/// </summary>
		/// <returns>
		/// The key.
		/// </returns>
		public static bool RightKey() {
			//Rightボタン
			return (Input2.GamePad0.Right.Press);
		}
		
		/*************************************
		 * AnalogPad
		 ************************************/
		//TODO
		
		/*************************************
		 * Buttons
		 ************************************/
		/// <summary>
		/// Triangles the button repeat.
		/// 三角ボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool TriangleButtonRepeat() {
			//Triangleボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Triangle) == GamePadButtons.Triangle)
				? true: false;
		}
		
		/// <summary>
		/// Crosses the button repeat.
		/// バツボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool CrossButtonRepeat() {
			//Crossボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Cross) == GamePadButtons.Cross)
				? true: false;
		}
		
		/// <summary>
		/// Squares the button repeat.
		/// 四角ボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool SquareButtonRepeat() {
			//Squareボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Square) == GamePadButtons.Square)
				? true: false;
		}
		
		/// <summary>
		/// Circles the button repeat.
		/// 丸ボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool CircleButtonRepeat() {
			//Rightボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Circle) == GamePadButtons.Circle)
				? true: false;
		}
		
		/// <summary>
		/// Ls the button repeat.
		/// Lボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool LButtonRepeat() {
			//Lボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.L) == GamePadButtons.L)
				? true: false;
		}
		
		/// <summary>
		/// Rs the button repeat.
		/// Rボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool RButtonRepeat() {
			//Rボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.R) == GamePadButtons.R)
				? true: false;
		}
		
		/// <summary>
		/// Selects the button repeat.
		/// セレクトボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool SelectButtonRepeat() {
			//Selectボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Select) == GamePadButtons.Select)
				? true: false;
		}
		
		/// <summary>
		/// Starts the button repeat.
		/// スタートボタン(リピート可)
		/// </summary>
		/// <returns>
		/// The button repeat.
		/// </returns>
		public static bool StartButtonRepeat() {
			//Startボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Start) == GamePadButtons.Start)
				? true: false;
		}
		
		/// <summary>
		/// Triangles the button.
		/// 三角ボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool TriangleButton() {
			//Triangleボタン
			return (Input2.GamePad0.Triangle.Press);
		}
		
		/// <summary>
		/// Crosses the button.
		/// バツボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool CrossButton() {
			//Crossボタン
			return (Input2.GamePad0.Cross.Press);
		}
		
		/// <summary>
		/// Squares the button.
		/// 四角ボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool SquareButton() {
			//Squareボタン
			return (Input2.GamePad0.Square.Press);
		}
		
		/// <summary>
		/// Circles the button.
		/// 丸ボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool CircleButton() {
			//Circleボタン
			return (Input2.GamePad0.Circle.Press);
		}
		
		/// <summary>
		/// Ls the button.
		/// Lボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool LButton() {
			//Lボタン
			return (Input2.GamePad0.L.Press);
		}
		
		/// <summary>
		/// Rs the button.
		/// Rボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool RButton() {
			//Rボタン
			return (Input2.GamePad0.R.Press);
		}
		
		/// <summary>
		/// Selects the button.
		/// セレクトボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool SelectButton() {
			//Selectボタン
			return (Input2.GamePad0.Select.Press);
		}
		
		/// <summary>
		/// Starts the button.
		/// スタートボタン(リピート不可)
		/// </summary>
		/// <returns>
		/// The button.
		/// </returns>
		public static bool StartButton() {
			//Startボタン
			return (Input2.GamePad0.Start.Press);
		}
		
		/*************************************
		 * Touch
		 ************************************/
		/// <summary>
		/// TOUCH_ STATU.
		/// TOUCH_NOT ,TOUCH_DOWN, TOUCH_MOVE, TOUCH_KEEP, TOUCH_UP, TOUCH
		/// </summary>
		public enum TOUCH_STATUS : byte{
			TOUCH_NOT ,TOUCH_DOWN, TOUCH_MOVE, TOUCH_KEEP, TOUCH_UP, TOUCH
		}
		
		
		private static float touchPositionX;
		private static float touchPositionY;
		private static long moveFinishCount;
		private static bool swiped = false;
		
		/// <summary>
		/// Touchs the not.
		/// タッチしてない
		/// </summary>
		/// <returns>
		/// The not.
		/// </returns>
		/// <param name='touchStatus'>
		/// If set to <c>true</c> touch status.
		/// </param>
		public static bool TouchNot(byte touchStatus){
			return (touchStatus == (byte)TOUCH_STATUS.TOUCH_NOT) ? true : false;
		}
		
		/// <summary>
		/// Touchs down.
		/// タッチダウンしている(画面に触れた瞬間)
		/// </summary>
		/// <returns>
		/// The down.
		/// </returns>
		/// <param name='touchStatus'>
		/// If set to <c>true</c> touch status.
		/// </param>
		public static bool TouchDown(byte touchStatus){
			return (touchStatus == (byte)TOUCH_STATUS.TOUCH_DOWN) ? true : false;
		}
		
		/// <summary>
		/// Touchs the move.
		/// タッチダウンしたまま指を動かしている
		/// </summary>
		/// <returns>
		/// The move.
		/// </returns>
		/// <param name='touchStatus'>
		/// If set to <c>true</c> touch status.
		/// </param>
		public static bool TouchMove(byte touchStatus){
			return (touchStatus == (byte)TOUCH_STATUS.TOUCH_MOVE) ? true : false;
		}
		
		/// <summary>
		/// Touchs the keep.
		/// タッチダウンしてその位置をkeepしている
		/// </summary>
		/// <returns>
		/// The keep.
		/// </returns>
		/// <param name='touchStatus'>
		/// If set to <c>true</c> touch status.
		/// </param>
		public static bool TouchKeep(byte touchStatus){
			return (touchStatus == (byte)TOUCH_STATUS.TOUCH_KEEP) ? true : false;
		}
		
		/// <summary>
		/// Touchs up.
		/// タッチアップ(画面から指を離した)
		/// </summary>
		/// <returns>
		/// The up.
		/// </returns>
		/// <param name='touchStatus'>
		/// If set to <c>true</c> touch status.
		/// </param>
		public static bool TouchUp(byte touchStatus){
			return (touchStatus == (byte)TOUCH_STATUS.TOUCH_UP) ? true : false;
		}
		
		/// <summary>
		/// Touchs the panel.
		/// タッチ(タッチダウンしてすぐタッチアップ)した
		/// </summary>
		/// <returns>
		/// The panel.
		/// </returns>
		/// <param name='touchStatus'>
		/// If set to <c>true</c> touch status.
		/// </param>
		public static bool TouchPanel(byte touchStatus){
			return (touchStatus == (byte)TOUCH_STATUS.TOUCH) ? true : false;
		}
		
		//file:///C:/Documents%20and%20Settings/All%20Users/Documents/PSM/doc/ja/structSce_1_1PlayStation_1_1Core_1_1Input_1_1TouchData.html
		/// <summary>
		/// Touchs the panel UI.
		/// FrameWorkで使う。タッチ状態取得。
		/// </summary>
		/// <param name='sceneClass'>
		/// Scene class.
		/// </param>
		/// <param name='gameCounter'>
		/// Game counter.
		/// </param>
		public static void TouchPanelUI(GameScene sceneClass, long gameCounter){
			foreach (var touchData in Touch.GetData(0)) {
				byte touchStatus = (byte)TOUCH_STATUS.TOUCH_NOT;
				//タッチダウン
				if (touchData.Status == TouchStatus.Down){
					//Console.WriteLine("Touch"+ touchData.ID +":(x,y)=("+ touchData.X +","+ touchData.Y +")");
					touchStatus = (byte)TOUCH_STATUS.TOUCH_DOWN;
					touchPositionX = touchData.X;
					touchPositionY = touchData.Y;
					moveFinishCount = gameCounter;
					swiped = false;
				}
				
				//ドラッグ
				if ((touchData.Status != TouchStatus.Down) && 
					(touchData.Status == TouchStatus.Move) &&
					(touchPositionX != touchData.X && touchPositionY != touchData.Y)){
					//Console.WriteLine("TouchMove"+ touchData.ID +":(x,y)=("+ touchData.X +","+ touchData.Y +")");
					touchStatus = (byte)TOUCH_STATUS.TOUCH_MOVE;
					touchPositionX = touchData.X;
					touchPositionY = touchData.Y;
					swiped = true;
					moveFinishCount = gameCounter;
				}
				//キープ（同じ場所を押しっぱなし）
				else if((touchData.Status != TouchStatus.Down) && 
						(touchData.Status == TouchStatus.Move) &&
						(moveFinishCount + 10 < gameCounter)){
					//Console.WriteLine("TouchKeep"+ touchData.ID +":(x,y)=("+ touchData.X +","+ touchData.Y +")");
					touchStatus = (byte)TOUCH_STATUS.TOUCH_KEEP;
				}
				
				//タッチアップ(タッチをやめたとき) -> スワイプしてない時はタッチになる
				if (touchData.Status == TouchStatus.Up){
					//Console.WriteLine("TouchUp"+ touchData.ID +":(x,y)=("+ touchData.X +","+ touchData.Y +")");
					touchStatus = (byte)TOUCH_STATUS.TOUCH_UP;
					if (!swiped){
						touchStatus = (byte)TOUCH_STATUS.TOUCH;
					}
				}
				sceneClass.SetTouchData(touchData , touchStatus);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		/*************************************
		 * Androidキー
		 ************************************/
		/// <summary>
		/// Backs the key repeat.(Android)
		/// Backキー(リピート可)(Android)
		/// </summary>
		/// <returns>
		/// The key repeat.
		/// </returns>
		public static bool BackKeyRepeat() {
			//Backボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Back) == GamePadButtons.Back)
				? true: false;
		}
		
		/// <summary>
		/// Enters the key repeat.(Android)
		/// Enterキー(リピート可)(Android)
		/// </summary>
		/// <returns>
		/// The key repeat.
		/// </returns>
		public static bool EnterKeyRepeat() {
			//Enterボタン
			return ((Sce.PlayStation.Core.Input.GamePad.GetData(0).Buttons & GamePadButtons.Enter) == GamePadButtons.Enter)
				? true: false;
		}
		
		
	}
}

