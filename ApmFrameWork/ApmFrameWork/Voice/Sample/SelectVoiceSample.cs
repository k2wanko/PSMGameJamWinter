// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections; //ArrayList

namespace ApmFw
{
	public class SelectVoiceSample
	{
		private Random random = new System.Random();// Random クラスの新しいインスタンスを生成する
		
		//String str;
		//ArrayList strList = new ArrayList();
		private Voice voice;
		
		public SelectVoiceSample ()
		{
		}
		
		public Voice getString(int id, byte leftChara, byte rightChara){
			switch(leftChara){
			case Const.testVoice:
				switch(rightChara){
				case Const.testVoice:
					this.voice = new VoiceSample();
					//this.voice = voice.getVoice(id);
					break;
				}
				break;
				
//			case "test2":
//				switch(rightChara){
//				case "test2":
//					this.voice = new TestVoice2();
//					this.voice = voice.getVoice(id);
//					break;
//				}
//				break;
			}
			//100下二桁が00で終わってたら00-09までランダムにセリフを選ぶ(idが合わない場合はデフォルトのセリフを選ぶ)
			if(id%100 == 0){
				id += this.random.Next(0,10);//0-9
			}
			this.voice = voice.getVoice(id);
			return this.voice;
		}
		
		
	}
}

