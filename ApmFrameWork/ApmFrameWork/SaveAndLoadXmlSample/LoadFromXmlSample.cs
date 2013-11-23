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
	/// Load from xml.
	/// saveデータをxmlから読み込みサンプル
	/// </summary>
	public class LoadFromXmlSample
	{
		
		public LoadFromXmlSample ()
		{
		}
		
		/// <summary>
		/// Loads the game data.
		/// </summary>
		/// <returns>
		/// The game data.
		/// </returns>
		public static String LoadGameData(bool newGame){
			String firstGame = "";//初めてのときは既存のセーブデータ
			String testStr = "";//テスト用

			//var xelm = XElement.Load("/Application/save/saveData.xml" );
			if (!newGame && System.IO.File.Exists("/Documents/sample/saveData.dat")) {
			// filePathのファイルは存在する
				firstGame = "/Documents/sample/saveData.dat";
			} else if (newGame) {
			// filePathのファイルは存在しない
				firstGame = "/Application/saveSample/saveData.xml";
			}
			var xelm = XElement.Load(firstGame);
			var loadedData = (
				from p in xelm.Elements( "ButtonData" )
				//orderby int.Parse( p.Attribute( "Age" ).Value ) //ソートしないのでコメントアウト
				select new
				{
					Description = p.Element("Button").Value
				}
			);

			foreach ( var temp in loadedData ) {
				//MessageBox.Show( emp.Description );
				testStr = temp.Description;
			}
			
			return testStr;
		}//LoadGameData()
	}//Class LoadFromXml
}//NsSaveAndLoadXml

