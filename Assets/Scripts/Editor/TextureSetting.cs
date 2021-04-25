/****************************************************
文件：TextureSetting.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 14:42:00
功能：图片导入设置类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

namespace PlaneWars_XAN {

	/// <summary>
	/// 图片导入自动处理成精灵图片
	/// AssetPostprocessor 接口官网
	/// https://docs.unity3d.com/cn/current/ScriptReference/AssetPostprocessor.html
	/// </summary>
	public class TextureSetting : AssetPostprocessor
	{
		private static FolderData mFolderData;

		private void OnPreprocessTexture() {           

			NamingConvertions();
			SetTexturePara();
		}

		private void NamingConvertions() {
			PlayerNaming();
		}

		private void PlayerNaming() {
            if (assetPath.Contains(Paths.PLAYER_PICTURE_FOLDER))
            {
				string name = Path.GetFileNameWithoutExtension(assetPath);

				// 匹配格式为：1_2 形式
				string pattern = "^[0-9]+_[0-9]+$";
				Match result = Regex.Match(name, pattern);
                if (result.Value == "")
                {
                    if (mFolderData == null)
                    {
						mFolderData = new FolderData();
						mFolderData.FolderPath = Paths.PLAYER_PICTURE_FOLDER;
						mFolderData.NameTip = "命名格式应为：1_5";
                    }

					Debug.LogError(GetType()+ "/PlayerNaming()/ The Curretn AssetName is Error, Please check it");
					NameMgrWindowData.Add(mFolderData, assetPath);

					NameMgrWindow.ShowWindow();

					

				}
            }
		}

		private void SetTexturePara() {
			TextureImporter textureImporter = (TextureImporter)assetImporter;
			textureImporter.textureType = TextureImporterType.Sprite;
			textureImporter.mipmapEnabled = false;
		}
	}
}
