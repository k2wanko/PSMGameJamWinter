// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;

namespace ApmFw
{
	/// <summary>
	/// Next scene.
	/// ゲームシーンの選択。格納。
	/// </summary>
	public delegate GameScene NextScene();
	
	/// <summary>
	/// Game scene.
	/// ゲームシーンの親クラス
	/// </summary>
	abstract public class GameScene
	{
		public Scene scene = new Scene();
		protected TouchData touchData{get;set;}
		protected byte touchStatus{get;set;}
		
		/// <summary>
		/// Scenes the wrapper.
		/// </summary>
		/// <returns>
		/// The wrapper.
		/// </returns>
		/// <typeparam name='Type'>
		/// The 1st type parameter.
		/// </typeparam>
		public static NextScene SceneWrapper<Type>()
		  where Type : GameScene, new()
		{
			return () => { return new Type();};
		}
		
		
		public GameScene ()
		{
		}
		
		/// <summary>
		/// Initialize of Scene.
		/// </summary>
		abstract public Scene Initialize();
		
		/// <summary>
		/// Update of Scene.
		/// </summary>
		abstract public void Update();
		
		/// <summary>
		/// Render of Scene.
		/// </summary>
		public virtual void Render(){
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Render();
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.SwapBuffers();
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.PostSwap();
		}
		
		/// <summary>
		/// Terminate of Scene.
		/// シーン終了時に呼び出す
		/// </summary>
		abstract public void Terminate();
		
		/// <summary>
		/// Sets the touch data.
		/// タッチデータをSceneで扱うために使用。
		/// </summary>
		/// <param name='touchData'>
		/// Touch data.
		/// </param>
		/// <param name='touchStatus'>
		/// Touch status.
		/// </param>
		public virtual void SetTouchData(TouchData touchData, byte touchStatus){
			this.touchData = touchData;
			this.touchStatus = touchStatus;
		}
		
		/// <summary>
		/// Changes the scene.
		/// </summary>
		/// <param name='next'>
		/// Next.
		/// </param>
		public virtual void ChangeScene(NextScene next){
			Const.ChangeScene = true;
			Const.Nextscene = next;
			NowLoading.NOW_LOADING(this.scene);
		}
	}//class GameScene
}//namespace DiceGame_01
