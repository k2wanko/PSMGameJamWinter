// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;//List
using System.Diagnostics;
using System.Collections; //ArrayList
using System.Timers;//timer

//save
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;

namespace ApmFw
{
	public class SingletonBaseSample: GameScene
	{
		protected SingletonSample SS;
		
		public SingletonBaseSample ()
		{
			SS = SingletonSample.getInstance();
			
			//singletonで作るから明示的に潰す
			scene = SS.scene;
			touchData = SS.touchData;
			touchStatus = SS.touchStatus;
		}
		
		public override Scene Initialize(){
			return null;
		}
		
		public override void Update(){}
		
		public override void SetTouchData(TouchData touchData, byte touchStatus){
			SS.setTouchData(touchData, touchStatus);
		}
		
		//シーン終了時に呼び出す
		public override void Terminate(){
			SS.scene.RemoveAllChildren(true);//必要 terminateの最初に
			SS.Terminate();
			SS = null;
			
			GC.Collect();//強制的にすべてのジェネレーションのガベージ コレクションを行う
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}
		
		public override void ChangeScene(NextScene next){
			Const.ChangeScene = true;
			Const.Nextscene = next;
			NowLoading.NOW_LOADING(this.scene);
		}
		
	}
}

