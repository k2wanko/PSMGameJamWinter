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
	public class VoiceSample : Voice
	{
		/*
		//Font font = new Font(FontAlias.System, Const.FONT_SIZE_MESSAGE, FontStyle.Regular);
		private int pageNum = 0; //ページ数(0page~)（一ページ4行）（一行全角ConstD.STRING_NUM_OF_LINE文字)
		private int lineNum =0;
		private int strOriginNum = 0;
		private string str = "";
		private ArrayList strOrigin = new ArrayList(); //原稿を格納
		private ArrayList nameList = new ArrayList(); //しゃべってるキャラの名前
		private ArrayList background = new ArrayList(); //背景の画像url
		private ArrayList charaLeft = new ArrayList(); //左の人の画像url
		private ArrayList charaMid = new ArrayList(); //真ん中の画像url
		private ArrayList charaRight = new ArrayList(); //右の人の画像url
		private ArrayList charaChangeNum = new ArrayList(); //キャラ画像を切り替える番号を格納
		
		private ArrayList strList = new ArrayList(); //原稿を改行、改ページしてから格納
		private string str86 = ""; //半角が86文字で改行　（全角は43文字で改行）
		private int strPlusNum = 0;
		private Font font = new Font(Const.DEFAULT_FONT, Const.FONT_SIZE_MESSAGE, FontStyle.Regular); //日本語使う
		 */
		public VoiceSample ()
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
			//セリフない場合はメソッドを作らなくていいdefaultでbreakでOK
			switch(id){
			case 99997:
				this.str99997();
				break;
			case 99998:
				this.str99998();
				break;
			case 99999:
				str99999();
				break;
			default:
				break;
			}
			
			if(this.strOrigin.Count != 0){
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
			}else{
				this.NoVoice = true;
			}
			
			return this;
		} //getVoice(int id)
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// セリフの組み込み
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		private void str99997(){
			///////////////
			/// 台詞1
			///////////////
			//無し
		}
		
		private void str99998(){
			///////////////
			/// 台詞1
			///////////////
			this.background.Add("none.png");
			this.charaMid.Add("none.png");
			this.charaMidFlip.Add(false);
			this.nameList.Add("test");
			this.charaLeft.Add("blue.png");
			this.charaLeftFlip.Add(true);
			this.charaRight.Add("green.png");
			this.charaRightFlip.Add(false);
			this.strOrigin.Add("this is test."); //ConstD.STRING_NUM_OF_LINE文字で一行
		}

		/// <summary>
		/// Str99999 this instance.
		/// id = 99999 の台詞集
		/// </summary>
		private void str99999(){
			///////////////
			/// 台詞1
			///////////////
			this.background.Add("black.png");
			this.charaMid.Add("none.png");
			this.charaMidFlip.Add(false);
			this.nameList.Add("test");
			//ハカセ
			//this.charaLeft.Add("blue.png");
			this.charaLeft.Add("red"+Const.PNG);
			this.charaLeftFlip.Add(true);
			this.charaRight.Add("blue"+Const.PNG);
			this.charaRightFlip.Add(false);
			this.strOrigin.Add("Ｔｈｉｓ　ｉｓ　ａ　ｔｅｓｔ　ｓｔｒｉｎｇ．"); //18 //ConstD.STRING_NUM_OF_LINE文字で一行
			///////////////
			/// 台詞2
			///////////////
			this.background.Add("black.png");
			this.charaMid.Add("none.png");
			this.charaMidFlip.Add(false);
			this.nameList.Add("sample");
			this.charaLeft.Add("white"+Const.PNG);
			this.charaLeftFlip.Add(true);
			this.charaRight.Add("green"+Const.PNG);
			this.charaRightFlip.Add(false);
			this.strOrigin.Add("全角と半角を混ぜてみるテスト:     aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
				"aaaaaaaいいい　　　　　aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n" +
				"ああああああああjああああああああああkkkあああああああああああj;j;lj;ljああああああああああああああ");
			///////////////
			/// 台詞3
			///////////////
			this.background.Add("black.png");
			this.charaMid.Add("none.png");
			this.charaMidFlip.Add(false);
			this.nameList.Add("テスト");
			this.charaLeft.Add("red"+Const.PNG);
			this.charaLeftFlip.Add(true);
			this.charaRight.Add("blue"+Const.PNG);
			this.charaRightFlip.Add(false);
			this.strOrigin.Add("記号を試すテスト:◎●◯○△▼▲▽⊿∴∵▶▷◀◁◆□◇■×♭♪♫♬♥♡〠…‥∉∩\n漢字も試してみるテスト:普通の漢字\nエンコードで失敗しやすい文字:" +
				" ーソЫⅨ噂浬欺圭構蚕十申曾箪貼能表暴予禄兔喀媾彌拿杤歃濬畚秉綵臀藹觸軆鐔饅鷭偆砡纊犾\n" +
				" －ポл榎掛弓芸鋼旨楯酢掃竹倒培怖翻慾處嘶斈忿掟桍毫烟痞窩縹艚蛞諫轎閖驂黥埈蒴僴礰" +
				"ー,―,‐,／,＼,＋,±,×,Ａ,ァ,ゼ,ソ,ゾ,タ,ダ,チ,ボ,ポ,マ,ミ,А,Ъ,Ы,Ь,Э,Ю,Я,к,л,м,н," +
				"院,閏,噂,云,運,雲,荏,閲,榎,厭,円,魁,骸,浬,馨,蛙,垣,柿,顎,掛,笠,樫,機,擬,欺,犠,疑," +
				"祇,義,宮,弓,急,救,掘,啓,圭,珪,型,契,形,鶏,芸,迎,鯨,后,梗,構,江,洪,浩,港,砿,鋼,閤,降," +
				"察,纂,蚕,讃,賛,酸,餐,施,旨,枝,止,宗,充,十,従,戎,柔,汁,旬,楯,殉,淳,拭,深,申,疹,真,神," +
				"秦,須,酢,図,厨,繊,措,曾,曽,楚,狙,疏,捜,掃,挿,掻,叩,端,箪,綻,耽,胆,蛋,畜,竹,筑,蓄,邸," +
				"甜,貼,転,顛,点,伝,怒,倒,党,冬,如,納,能,脳,膿,農,覗,倍,培,媒,梅,鼻,票,表,評,豹,廟,描," +
				"府,怖,扶,敷,法,房,暴,望,某,棒,冒,本,翻,凡,盆,諭,夕,予,余,与,誉,輿,養,慾,抑,欲,蓮,麓,禄,肋,録,論,倭");
			///////////////
			/// 台詞4
			///////////////
			this.background.Add("black.png");
			this.charaMid.Add("none.png");
			this.charaMidFlip.Add(false);
			this.nameList.Add("神");
			this.charaLeft.Add("white"+Const.PNG);
			this.charaLeftFlip.Add(true);
			this.charaRight.Add("green"+Const.PNG);
			this.charaRightFlip.Add(false);
			// \nや\rが離れてるとバグる
			this.strOrigin.Add("あああああああああああああああああああああああああああああああああああああああああああああああい\rい" +
				"ああああああああああああああああああああああああああああ\nああああああああああああああああああああああああああああああ" +
				"あああああああああああああああああああああああああああああ\rあああああああああああああああああああああああああああああ" +
				"いいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいいい" +
				"ううううううううううううううううううううううううううううううううううううううううううううう" +
				"あああああああああああああああああああああああああああああああああああああああああああああああああ" +
				"ああああああああああああああああああ\n \nああああああああああああああああああああああああああああああああああああああああ" +
				"あああああああああああああああああああああああああああ" +
				"いいいいいいいいいいいいいいいいいいいいいいいいいいいいいい\r \rいいいいいいいいいいいいいいいいいいいいいいいいいいいい" +
				"ううううううううううううううううううううううううううううううううううううううううううううう。"); //18 //ConstD.STRING_NUM_OF_LINE文字で一行
		}
	}//class VoiceSample
}

