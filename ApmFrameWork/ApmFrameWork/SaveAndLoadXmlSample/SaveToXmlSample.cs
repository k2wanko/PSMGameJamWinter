// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ApmFw
{
	/// <summary>
	/// Save to xml sample.
	/// </summary>
	public class SaveToXmlSample
	{
		public SaveToXmlSample ()
		{
		}//SaveToXml()
		
		//TODO セーブする内容を考えといて
		public static void SaveGameData(String saveTestStr){
			var xml = new XDocument(
				new XDeclaration( "1.0" , "utf-8" , "true" ) ,
				new XComment( "LINQ to XML Sample http://keicode.com/" ) ,
				new XElement( "SaveData" ,
						new XElement( "ButtonData" ,
							new XElement( "Button", saveTestStr )
						)
					)
			);
		
			//saveフォルダが\bin\Debug\hoge-unsigned\saveにあったので多分ここに保存で合ってると思う
			if (!System.IO.Directory.Exists("/Documents/sample")) {
				System.IO.Directory.CreateDirectory("/Documents/sample"); //これがないと初回エラー
			}
			xml.Save("/Documents/sample/saveData.dat");
		}//SaveGameData()
	}//class SaveToXml
}//NsSaveToXml

