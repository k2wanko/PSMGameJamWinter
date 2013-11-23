// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;


namespace ApmFw
{
	/// <summary>
	/// Scene sample2.
	/// </summary>
	public class TouchSample : GameScene
	{
		private SpriteUV description;
		private SpriteForTouch spriteForTouch = new SpriteForTouch();
		
		public TouchSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			//sceneはオブジェクトの追加や削除のためにも描画メソッドの外で作ったほうが良い
			
			scene.Camera.SetViewFromViewport();
			
			//文字の描画 960x544 //vita画面解像度 20x11.25(左上)
			description = WriteString.DrawSprite("Touch!をタッチ:戻る/Touch!以外をタッチ:文字を消す" +
				"/画面をドラッグ:Touch!が指を追いかける/Start:戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			spriteForTouch.DrawSprite("Touch!",
										14*Const.FIX,
										10*Const.FIX,
										40,
										new ImageColor(255,255,255,255),
										scene,
			                          true);
			
			//effect(効果音)もbgmも一つにつき一回newする。
			
			return scene;

		}//Initialize()
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		public override void Update(){
			
			
			
			//touchアクション
			if (InputDevice.TouchPanel(this.touchStatus)){
				if (this.spriteForTouch.TouchSprite(touchData)){
					ChangeScene( () => {return new MainMenuSample();} );
				} else {
					this.spriteForTouch.Sprite.Visible = !this.spriteForTouch.Sprite.Visible;
				}
			}
			
			//spriteをドラッグする
			if (InputDevice.TouchMove(this.touchStatus)){
				this.spriteForTouch.GoToTouchPosition(touchData);
			}
			
			this.touchStatus = (byte)InputDevice.TOUCH_STATUS.TOUCH_NOT; //touchが全部終わったら書く
			
			// X keyはStart
			//連射不可
			if(Input2.GamePad.GetData(0).Start.Release)
			{
				ChangeScene( () => {return new MainMenuSample();} );
			}
		}//Update()
		
		/// <summary>
		/// Terminate of Scene.
		/// </summary>
		public override void Terminate(){
			//GC.Collect();//強制的にすべてのジェネレーションのガベージ コレクションを行う
			this.scene.RemoveAllChildren(true);//必要 terminateの最初に
			scene = null;
			spriteForTouch = null;
		}//Terminate
		
	}//class SceneSample2
}//namespace ApmFw


