// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections; //ArrayList
//using System.Text;
using Sce.PlayStation.Core.Imaging; //font

namespace ApmFw
{
	public class VoiceSample2 : Voice
	{
		public VoiceSample2 ()
		{
		}
		
		/// <summary>
		/// Gets the voice.
		/// セリフの場合分け
		/// </summary>
		/// <returns>
		/// The voice.
		/// セリフやキャラの画像、背景画像などを返す
		/// </returns>
		/// <param name='id'>
		/// Identifier.
		/// 引数idでセリフを場合分ける
		/// </param>
		public override Voice getVoice(int id){
			switch(id){
			case 99999:
				str99999();
				break;
			}
			
			this.str = (string)this.strOrigin[0];//必ず書く
			this.fitStr(); //セリフをセットする
			this.strList.TrimExcess();
			this.strOrigin = null; //原稿を格納
			this.nameList.TrimExcess(); //しゃべってるキャラの名前
			this.background.TrimExcess(); //背景の画像url
			this.charaLeft.TrimExcess(); //左の人の画像url
			this.charaMid.TrimExcess(); //真ん中の画像url
			this.charaRight.TrimExcess(); //右の人の画像url
			this.charaLeftFlip.TrimExcess();
			this.charaMidFlip.TrimExcess();
			this.charaRightFlip.TrimExcess(); 
			this.charaChangeNum.TrimExcess(); //キャラ画像を切り替える番号を格納
			
			return this;
		} //getVoice(int id)
		

		
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// セリフの組み込み
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		

		/// <summary>
		/// Str99999 this instance.
		/// id = 99999 の台詞集
		/// </summary>
		private void str99999(){
			///////////////
			/// 台詞1
			///////////////
			this.background.Add("white.png");
			this.charaMid.Add("none.png");
			this.charaMidFlip.Add(false);
			this.nameList.Add("test");
			this.charaLeft.Add("red.png");
			this.charaLeftFlip.Add(true);
			this.charaRight.Add("black.png");
			this.charaRightFlip.Add(false);
			this.strOrigin.Add("esrdtfgyhujiｄｔｒぎゅじおｋｐｌｆｔぎゅひおｓｒｄｔｆｙぐｈじおdrtfgyuhjiokplkjiuhyrg"); //18 //ConstD.STRING_NUM_OF_LINE文字で一行
		}
	}//class sampleVoice
}

