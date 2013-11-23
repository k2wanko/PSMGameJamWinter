// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using I18N.CJK; //shift_jis

namespace ApmFw
{
	/// <summary>
	/// Game log.
	/// </summary>
	public class GameLog
	{
//#if DEBUG
		public static StackFrame StackFrame{get; private set;}
		private static string log;
		private static DateTime dateTime = DateTime.Now;
		private static int logCounter = 0;
		private static bool createdDirectory = false;
		private static Stream stdout = System.Console.OpenStandardOutput();
		private static Encoding shiftJisEncoding = new CP932();
//#endif
		
		public GameLog ()
		{
		}
		
		/// <summary>
		/// Debug log.
		/// </summary>
		public class DebugLog {
			
			/// <summary>
			/// Logs start the method.
			/// </summary>
			/// <param name='message'>
			/// Message.
			/// </param>
			[Conditional ("DEBUG")]
			public static void StartMethod(string message = "") {
				//このメソッドの実行元の情報を拾う
				if(GameLog.StackFrame != null) {
					GameLog.StackFrame = null;
				}
				GameLog.StackFrame = new StackFrame(1);
				
				GameLog.log = GameLog.StackFrame.GetMethod().ReflectedType.FullName + 
				                " / " + GameLog.StackFrame.GetMethod().Name + 
				                " (M)Start : " + message;
				
				byte[] bytesLog = shiftJisEncoding.GetBytes(log + "\n");
				stdout.Write(bytesLog,0,bytesLog.Length);
				GameLog.DebugLog.WriteLogFile(log);
			}
			
			/// <summary>
			/// Logs end the method.
			/// </summary>
			/// <param name='message'>
			/// Message.
			/// </param>
			[Conditional ("DEBUG")]
			public static void EndMethod(string message = "") {
				//このメソッドの実行元の情報を拾う
				if(GameLog.StackFrame != null) {
					GameLog.StackFrame = null;
				}
				GameLog.StackFrame = new StackFrame(1);
				
				GameLog.log = GameLog.StackFrame.GetMethod().ReflectedType.FullName + 
				                " / " + GameLog.StackFrame.GetMethod().Name + 
				                " (M)  End : " + message;
				
				byte[] bytesLog = shiftJisEncoding.GetBytes(log + "\n");
				stdout.Write(bytesLog,0,bytesLog.Length);
				GameLog.DebugLog.WriteLogFile(log);
			}
			
			/// <summary>
			/// Log the specified message.
			/// </summary>
			/// <param name='message'>
			/// Message.
			/// </param>
			[Conditional ("DEBUG")]
			public static void Log(string message = "") {
				//このメソッドの実行元の情報を拾う
				if(GameLog.StackFrame != null) {
					GameLog.StackFrame = null;
				}
				GameLog.StackFrame = new StackFrame(1);
				
				GameLog.log = GameLog.StackFrame.GetMethod().ReflectedType.FullName + 
				                " / " + GameLog.StackFrame.GetMethod().Name + 
				                " (M) : " + message;
				
				byte[] bytesLog = shiftJisEncoding.GetBytes(log + "\n");
				stdout.Write(bytesLog,0,bytesLog.Length);
				GameLog.DebugLog.WriteLogFile(log);
			}
			
			/// <summary>
			/// Writes the log file.
			/// </summary>
			/// <param name='message'>
			/// Message.
			/// </param>
			[Conditional ("DEBUG")]
			public static void WriteLogFile(string message) {
				if(createdDirectory){
					using (System.IO.StreamWriter w
					       = System.IO.File.AppendText("/Documents/log/debug/" + dateTime.ToString("yyyyMMdd/") + logCounter + ".txt"))
					{
						w.WriteLine(message);
					}
				} else {
					initialize();
				}
			}
			
			[Conditional ("DEBUG")]
			private static void initialize(){
				if (!System.IO.Directory.Exists("/Documents/log/debug/" + dateTime.ToString("yyyyMMdd"))) {
					System.IO.Directory.CreateDirectory("/Documents/log/debug/" + dateTime.ToString("yyyyMMdd"));
				}
				while(true) {
					if (System.IO.File.Exists("/Documents/log/debug/" + dateTime.ToString("yyyyMMdd/") + logCounter + ".txt")) {
						//既にlog fileがあったら
						logCounter++;
					} else {
						break;
					}
				}
				createdDirectory = true;
			}
		}
	}
}
