// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;


namespace ApmFw
{
	public class SingletonSceneSample: SingletonBaseSample
	{
		
		public SingletonSceneSample ()
		{}
		
		
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initialize SS.instance.
		/// </summary>
		public override Scene Initialize(){
			return SS.Initialize();
		}//Initialize()
		
		
				/// <summary>
		/// Update SS.instance.
		/// </summary>
		public override void Update(){
			SS.Update();
		}//Update()
		
		
		public override void SetTouchData(TouchData touchData, byte touchStatus){
			base.SetTouchData(touchData, touchStatus);
		}

		//シーン終了時に呼び出す
		public override void Terminate(){
			base.Terminate();
		}//Terminate
		
	}
}

