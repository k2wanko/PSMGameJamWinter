// ///////////////////////////////////////////////////////
// /// Author aioia
// /// APM FrameWork
// /// http://aioia-lab.sakura.ne.jp/index.html
// /// Copyright (C) 2012- aioia
// ///////////////////////////////////////////////////////


using System;
using Sce.PlayStation.Core.Audio;

using System.Diagnostics; //[Conditional ("DEBUG")]

namespace ApmFw
{
	/// <summary>
	/// Audio.
	/// Bgmや効果音を制御するクラス
	/// </summary>
	public class Audio
	{
		/// <summary>
		/// Gets or sets the bgm.
		/// BGM本体。これに音源をセットする
		/// </summary>
		/// <value>
		/// The bgm.
		/// </value>
		private static Bgm Bgm{get; set;}
		
		/// <summary>
		/// Gets or sets the bgm player.
		/// BgmのPlayer。セットした音源を再生など制御する
		/// </summary>
		/// <value>
		/// The bgm player.
		/// </value>
		private static BgmPlayer BgmPlayer{get;set;}
		
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ApmFw.Audio"/> bgm on.
		/// これにfalseをセットするとミュートになる。
		/// defaultはtrue
		/// </summary>
		/// <value>
		/// <c>true</c> if bgm on; otherwise, <c>false</c>.
		/// </value>
		private static bool BgmOn{get;set;}
		
		/// <summary>
		/// Sets the effect.
		/// 効果音のプレイヤーをセットする。
		/// 一つの効果音に一つ必要。
		/// 同じPlayerを同時に鳴らすことはできない
		/// </summary>
		/// <returns>
		/// The effect.
		/// 効果音セット済のPlayerを返す。
		/// </returns>
		/// <param name='effectStr'>
		/// Effect string.
		/// 効果音音源のファイル名
		/// </param>
		public static SoundPlayer SetEffect(String effectStr){
			//効果音の初期化。
			//右クリックビルドアクション->コンテンツをwavファイルに。
			return(new Sound(effectStr)).CreatePlayer();
		}
		
		/// <summary>
		/// Sets the bgm.
		/// BGMをPlayerにセットする。
		/// BGMプレイヤーは同時に2つ以上存在できない
		/// </summary>
		/// <param name='bgmStr'>
		/// Bgm string.
		/// </param>
		public static void SetBgm(String bgmStr){
			//BGMの初期化。
			EndBgm();
			Bgm = new Bgm(bgmStr);
			BgmPlayer = Bgm.CreatePlayer();
			Bgm.Dispose();
			Bgm=null;
			BgmPlayer.Loop = true;
			BgmOn = true;
			
			SetBgmMute();
			
		}
		
		/// <summary>
		/// Starts the bgm.
		/// </summary>
		public static void StartBgm(){
			if(BgmOn) BgmPlayer.Play();
		}
		
		/// <summary>
		/// Stops the bgm.
		/// </summary>
		public static void StopBgm(){
			BgmPlayer.Stop();
		}
		
		/// <summary>
		/// Pitchs the change bgm.
		/// </summary>
		/// <param name='pitch'>
		/// Pitch.
		/// </param>
		public static void PitchChangeBgm(float pitch) {
			if(4.0f < BgmPlayer.PlaybackRate + pitch) {
				BgmPlayer.PlaybackRate = 4.0f;
			} else if(BgmPlayer.PlaybackRate + pitch < 0.25f){
				BgmPlayer.PlaybackRate = 0.25f;
			} else {
				BgmPlayer.PlaybackRate += pitch;
			}
		}
		
		/// <summary>
		/// Sets the pitch bgm.
		/// 0.25-4.0
		/// </summary>
		public static void SetPitchBgm(float pitch) {
			if(pitch < 0.25f){
				pitch = 0.25f;
			} else if(4.0f < pitch) {
				pitch = 4.0f;
			}
			BgmPlayer.PlaybackRate = pitch;
		}
		
		/// <summary>
		/// Resets the pitch bgm.
		/// </summary>
		public static void ResetPitchBgm(){
			BgmPlayer.PlaybackRate = 1.0f;
		}
		
		/// <summary>
		/// Sets the volume bgm.
		/// 0.0-1.0
		/// </summary>
		/// <param name='volume'>
		/// Volume.
		/// </param>
		public static void SetVolumeBgm(float volume) {
			if(volume < 0){
				volume = 0;
			} else if(1.0f < volume) {
				volume = 1.0f;
			}
			BgmPlayer.Volume = volume;
		}
		
		/// <summary>
		/// Volumes the change bgm.
		/// </summary>
		/// <param name='volume'>
		/// Volume.
		/// </param>
		public static void VolumeChangeBgm(float volume) {
			if(1.0f < BgmPlayer.Volume + volume) {
				BgmPlayer.Volume = 1.0f;
			} else if(BgmPlayer.Volume + volume < 0){
				BgmPlayer.Volume = 0;
			} else {
				BgmPlayer.Volume += volume;
			}
		}
		
		/// <summary>
		/// Ends the bgm.
		/// </summary>
		private static void EndBgm(){
			if(BgmPlayer != null) {
				BgmPlayer.Dispose();
				BgmPlayer = null;
			}
		}
		
		/// <summary>
		/// Effect player dispose.
		/// </summary>
		/// <param name='soundEffectPlayer'>
		/// Sound effect player.
		/// </param>
		public static void SoundEffectPlayerDispose(SoundPlayer soundEffectPlayer){
			soundEffectPlayer.Dispose();
			soundEffectPlayer = null;
		}
		
		/// <summary>
		/// Sets the bgm mute.
		/// </summary>
		[Conditional("DEBUG")]
		private static void SetBgmMute() {
			//テスト（音を消せる）
//			BgmOn = false;
		}
	}
}

