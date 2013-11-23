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

namespace ApmFw{

	public class AppMain{

		public static void Main (string[] args){
			
			Director.Initialize();
			Scene scene = new Scene();
			scene.Camera.SetViewFromViewport();
			Director.Instance.RunWithScene(scene);
			
		}
	//Main
	}//class AppMain
}//namespace ApmFw



