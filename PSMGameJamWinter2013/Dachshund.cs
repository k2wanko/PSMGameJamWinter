using System;
using ApmFw;

namespace PSMGameJamWinter2013
{
	public class Dachshund : APMGameFramework
	{
		public Dachshund ()
		{
			
		}
		
		protected override void SetFirstScene(){
			new MainScene();
		}
	}
}

