// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;

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
	/// Scene sample.
	/// </summary>
	public class SingletonDrawSpriteInitializeSample : SingletonBaseSample
	{
		
		
		public SingletonDrawSpriteInitializeSample ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		public override Scene Initialize(){
			scene.Camera.SetViewFromViewport();
			
			//画像の描画 960x544 //vita画面解像度 20x11.25(左上)
			SS.Description = WriteString.DrawSprite("十字キー:移動/○・□:拡大縮小/△:サイズのリセット/" +
				"x:画面から消す/Start:戻る",
										0.5f*Const.FIX,
										0.5f*Const.FIX,
										20,
										new ImageColor(255,255,255,255),
										scene);
			SS.SpritePicture = DrawPicture.DrawSprite("Player.png", 10f*Const.FIX, 5f*Const.FIX,scene);
			
			return scene;

		}//Initialize()
		
	}//class SceneSample0
}//namespace ApmFw

