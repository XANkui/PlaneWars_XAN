/****************************************************
文件：AudioImportAutoSetting.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/24 16:15:19
功能：音频文件导入自动设置一些属性
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PlaneWars_XAN { 

	public class AudioImportAutoSetting : AssetPostprocessor
	{
		private void OnPostprocessAudio(AudioClip clip) {
			var audio = (AudioImporter)assetImporter;
			AudioImporterSampleSettings settings = new AudioImporterSampleSettings();
			// 音频时间长度小于 3 秒
			if (clip.length < 3)
			{
				settings.loadType = AudioClipLoadType.DecompressOnLoad;
			}
			else { 
				settings.loadType = AudioClipLoadType.Streaming;

			}

			audio.preloadAudioData = false;
			audio.defaultSampleSettings = settings;
		}
	}
}
