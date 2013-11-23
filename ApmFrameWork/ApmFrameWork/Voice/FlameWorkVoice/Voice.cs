// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections; //ArrayList
using System.Collections.Generic; //List
using Sce.PlayStation.Core.Imaging; //font

using ApmFw;

namespace ApmFw
{
	/// <summary>
	/// Voice.
	/// 
	/// changeScene(ConstD.NOVELSCENE);の前に呼び出して左右のキャラと、そのシーン番号を登録する（これで振り分ける）
	/// この例では左右キャラに99番、ノベルIDに99999を登録
	/// Const.LEFTCHARACTER = 99;
	/// Const.RIGHTCHARACTER = 99;
	/// Const.NOVELID = 99999;
	/// </summary>
	public class Voice
	{
		//Font font = new Font(FontAlias.System, Const.FONT_SIZE_MESSAGE, FontStyle.Regular);
		public int pageNum = 0; //ページ数(0page~)（一ページ4行）（一行全角Const.STRING_NUM_OF_LINE文字)
		public int lineNum =0;
		public int strOriginNum = 0;
		public string str = "";
		public List<string> strOrigin = new List<string>(); //原稿を格納
		public List<string> nameList = new List<string>(); //しゃべってるキャラの名前
		public List<string> background = new List<string>(); //背景の画像url
		public List<string> charaLeft = new List<string>(); //左の人の画像url
		public List<bool> charaLeftFlip = new List<bool>();//左の画像を左右反転するフラグ true で反転
		public List<string> charaMid = new List<string>(); //真ん中の画像url
		public List<bool> charaMidFlip = new List<bool>();//真ん中の画像を左右反転するフラグ true で反転
		public List<string> charaRight = new List<string>(); //右の人の画像url
		public List<bool> charaRightFlip = new List<bool>();//右の画像を左右反転するフラグ true で反転
		public List<int> charaChangeNum = new List<int>(); //キャラ画像を切り替える番号を格納
		//private List<string> backgroundChangeNum = new List<int>(); //背景画像を切り替える番号を格納
		
		public List<string> strList = new List<string>(); //原稿を改行、改ページしてから格納
		public string str86 = ""; //半角が86文字で改行　（全角は43文字で改行）
		public int strPlusNum = 0;
		public Font font = new Font(Const.DEFAULT_FONT, Const.FONT_SIZE_MESSAGE, FontStyle.Regular); //日本語使う
		public bool NoVoice{get;set;}

		public Voice ()
		{
			this.NoVoice = false;
		}
		
		/// <summary>
		/// Gets the voice.
		/// セリフを選択する。これをオーバーライドして左キャラごとにクラスを作る
		/// </summary>
		/// <returns>
		/// The voice.
		/// </returns>
		/// <param name='id'>
		/// Identifier.
		/// idで場合分け
		/// </param>
		virtual public Voice getVoice(int id){
			switch(id){
			case 99999:
				//ここでセリフを組み込ん無メソッドを呼び出す
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
		}
		
		/// <summary>
		/// Fits the string.
		/// セリフのセット
		/// </summary>
		public void fitStr(){
			int stringNumOfLine = 0;
			//Boolean shortStr = false;
			for(int i = 1;;i++){

				//初期化
				//this.strTemp = this.str.Substring(0,this.str.Length);
				if (Const.STRING_NUM_OF_LINE <= this.str.Length) this.str86 = this.str.Substring(0,Const.STRING_NUM_OF_LINE);
				this.strPlusNum = 0;
				
				//if (font.GetTextWidth(this.str) < (Const.FONT_SIZE_MESSAGE -1)*Const.STRING_NUM_OF_LINE){
				//	shortStr = true;
				//	this.strPlusNum = this.str.Length - Const.STRING_NUM_OF_LINE+1;
				//}
				
				while(true){
					if ((Const.FONT_SIZE_MESSAGE -1)*Const.STRING_NUM_OF_LINE <= font.GetTextWidth(this.str86)){ //1文字（全角）の長さ*行の文字数（全角）
						break;
					}else if (font.GetTextWidth(this.str86) < (Const.FONT_SIZE_MESSAGE -1)*Const.STRING_NUM_OF_LINE){ //半角が混じってたら文字を位置文字追加する
						if (font.GetTextWidth(this.str) < (Const.FONT_SIZE_MESSAGE -1)*Const.STRING_NUM_OF_LINE){
							this.strPlusNum = this.str.Length - Const.STRING_NUM_OF_LINE+1;
							break;
						}
						this.strPlusNum++;
						this.str86 = this.str.Substring(0,Const.STRING_NUM_OF_LINE+this.strPlusNum);
					}
				}
				stringNumOfLine = Const.STRING_NUM_OF_LINE+this.strPlusNum; //実際の一行に含まれる文字数
				
				//if (Const.STRING_NUM_OF_LINE <= str.Length){ //0行目オーバー
				if ((stringNumOfLine < str.Length && stringNumOfLine < this.str.IndexOf("\r") && stringNumOfLine < this.str.IndexOf("\n")) || 
				    (stringNumOfLine < str.Length && this.str.IndexOf("\r") < 0 && this.str.IndexOf("\n") < 0) ||
				    (stringNumOfLine < str.Length && stringNumOfLine < this.str.IndexOf("\r") && this.str.IndexOf("\n") < 0) ||
				    (stringNumOfLine < str.Length && stringNumOfLine < this.str.IndexOf("\n") && this.str.IndexOf("\r") < 0)){ //0行目オーバー
					//Console.WriteLine("Const.STRING_NUM_OF_LINE < line");
					this.strList.Add(str.Substring(0,stringNumOfLine)); //Const.STRING_NUM_OF_LINE文字で一行
					this.str = this.str.Substring(stringNumOfLine,str.Length-stringNumOfLine);
					this.lineNum++; //改行した
					if(this.lineNum%4==0){
						this.pageNum++;
					}
				}else if ((0 <= this.str.IndexOf("\r") && this.str.IndexOf("\r") < this.str.IndexOf("\n")) || 
				          (0 <= this.str.IndexOf("\r") && this.str.IndexOf("\n") < 0)){ //r
					//Console.WriteLine("r");
					//if ((0 < this.str.IndexOf("\r") && this.str.IndexOf("\n") < 0)) rOnly++;
					this.strList.Add(this.str.Substring(0,this.str.IndexOf("\r")));
					this.str = this.str.Substring(this.str.IndexOf("\r")+1,this.str.Length-(this.str.IndexOf("\r")+1));
					this.lineNum++; //改行した
					this.pageNum++; //改ページした
					//一番下の行まで足す
					for(int j = this.lineNum%4; j < 4; j++){
						if (j == 0) break;
						this.strList.Add(" ");
						this.lineNum++;
					}
				}
				//if (0 < this.str.IndexOf("\n")){
				else if ((0 <= this.str.IndexOf("\n") && this.str.IndexOf("\n") < this.str.IndexOf("\r")) || 
				         (0 <= this.str.IndexOf("\n") && this.str.IndexOf("\r") < 0)){ //n
					//Console.WriteLine("n");
					this.strList.Add(this.str.Substring(0,this.str.IndexOf("\n")));
					this.str = this.str.Substring(this.str.IndexOf("\n")+1,this.str.Length-(this.str.IndexOf("\n")+1));
					this.lineNum++; //改行した
				}else 
				if (0 < str.Length){ //一つのセリフが終わったら
					//Console.WriteLine("0 < page <Const.STRING_NUM_OF_LINE");
					this.strList.Add(str.Substring(0,str.Length)); //のこり
					this.str = ""; //残りを削除
					this.lineNum++; //改行した
					this.pageNum++; //改ページした
					//一番下の行まで足す
					for(int j = this.lineNum%4; j < 4; j++){
						if (j == 0) break;
						this.strList.Add(" ");
						this.lineNum++;
					}
					this.charaChangeNum.Add(this.pageNum);
				}else if (i%4 == 0 && str.Length == 0){
					this.strOriginNum++; //しゃべり終わった台詞数
					if (this.strOriginNum == this.strOrigin.Count) break; //ここでbreak
					this.str = (string)this.strOrigin[this.strOriginNum];
				}
			} //for(int i = 1;;i++)
		} //fitStr()
		
		public int getStrOriginNum(){
			return strOriginNum;
		}
		
		public void plusPageNum(int plus){
			this.pageNum += plus;
		}
		
		public int getPageNum(){
			return this.pageNum;
		}
		
		public int getLineNum(){
			return this.lineNum;
		}
		
		public List<int> getCharaChangeNum(){
			return this.charaChangeNum;
		}
		
		public List<string> getBackground(){
			return this.background;
		}
		
		public List<string> getCharaLeft(){
			return this.charaLeft;
		}
		
		public List<string> getCharaMid(){
			return this.charaMid;
		}
		
		public List<string> getCharaRight(){
			return this.charaRight;
		}
		
		public List<bool> getCharaLeftFlip(){
			return this.charaLeftFlip;
		}
		
		public List<bool> getCharaMidFlip(){
			return this.charaMidFlip;
		}
		
		public List<bool> getCharaRightFlip(){
			return this.charaRightFlip;
		}
		
		public List<string> getNameList(){
			return this.nameList;
		}
		
		public List<string> getStrList(){
			return this.strList;
		}
		
	}//class Voice
}

