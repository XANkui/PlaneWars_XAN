/****************************************************
文件：JsonDataTool.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/24 17:07:48
功能：Nothing
*****************************************************/

using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class JsonDataTool 
	{
		[MenuItem("Assets/CreateJson")]
		private static void CreateJson() {
			// 获得 Assets 资源文件夹鼠标选中的资源，路径
			var ids = Selection.assetGUIDs;
			string path = AssetDatabase.GUIDToAssetPath(ids[0]);
			AudioJson(path);
		}

        private static void AudioJson(string selectedPath)
        {
			// 判断当前文件夹时候是 Audio 文件夹
            if (selectedPath.EndsWith(Paths.AUDIO_FOLDER)==false)
            {
				return;
            }

			DirectoryInfo info = new DirectoryInfo(selectedPath);
			FileInfo[] fileInfos = info.GetFiles("*", SearchOption.AllDirectories);


            List<AudioVolume> volumes = new List<AudioVolume>();
            foreach (FileInfo fileInfo in fileInfos)
            {
                // 排除 .meta文件 （如果是 mac ，可能还有 mac 自己生成的后缀文件）
                if (fileInfo.Name.EndsWith(".meta"))
                {
                    continue;
                }

                // 获得文件名（不带后缀）
                string name = Path.GetFileNameWithoutExtension(fileInfo.Name);
                var temp = new AudioVolume() { 
                    Name = name,
                    Volume = 0.5
                };
                volumes.Add(temp);
                
            }

            string json = JsonMapper.ToJson(volumes);
            string path = Paths.CONFIG_AUDIO_VOULME_CONFIG;

            if (File.Exists(path) == true)
            {
                if (EditorUtility.DisplayDialog("警告", "是否覆盖AudioVolume配置文件", "确定", "取消") == false)
                {
                    return;
                }
            }

            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
            Debug.Log("成功生成 AudioVolume 配置文件");
        }

        public class AudioVolume { 
            public string Name { get; set; }
            public double Volume { get; set; }
        }
    }
}
