
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Timers;//timer

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Audio;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using ApmFw;


namespace PSMGameJamWinter2013
{
	public class PSMGJW2013Manager : APMGameFramework
	{
		public PSMGJW2013Manager ()
		{
			
		}
		
		protected override void SetFirstScene() {
			sceneClass = new TitleScene();
		}
	}
}

