/****************************************************
文件：NameMgrWindow.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 21:26:53
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace PlaneWars_XAN { 

	public class NameMgrWindow : EditorWindow
	{
        private Dictionary<string, string> mNamesDict = new Dictionary<string, string>();

		public static void ShowWindow() {
			EditorWindow.GetWindow<NameMgrWindow>();
		}

        private void OnGUI()
        {
            GUILayout.Label("资源名称管理器");

            NameMgrWindowData.UpdateData();

           

            foreach (KeyValuePair<FolderData, List<string>> pair in NameMgrWindowData.SpriteDict)
            {

                GUILayout.BeginHorizontal();
                GUILayout.Label("路径：", GUILayout.MaxWidth(50));
                GUILayout.Label(pair.Key.FolderPath, GUILayout.MaxWidth(150));
                GUILayout.Label("范例：", GUILayout.MaxWidth(50));
                GUILayout.Label(pair.Key.NameTip, GUILayout.MaxWidth(150));

                GUILayout.EndHorizontal();


                GUILayout.BeginHorizontal();

                foreach (string path in pair.Value)
                {
                    GUILayout.BeginVertical();
                    Texture2D texture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                    GUILayout.Box(texture2D, GUILayout.Height(100), GUILayout.Width(120));
                    string originName = Path.GetFileNameWithoutExtension(path);
                    if (mNamesDict.ContainsKey(originName)==false)
                    {
                        mNamesDict[originName] = originName;
                    }

                    GUILayout.BeginHorizontal();
                    mNamesDict[originName] = GUILayout.TextArea(originName,GUILayout.Width(60));
                    if (GUILayout.Button("确认修改", GUILayout.Width(60)))
                    {
                        if (originName != mNamesDict[originName])
                        {
                            ChangeFileName(originName,mNamesDict[originName],path);
                            mNamesDict.Remove(originName);
                        }

                        AssetDatabase.Refresh();
                    }
                    

                    GUILayout.BeginHorizontal();

                    GUILayout.EndVertical();

                }

                GUILayout.EndHorizontal();
            }

           

        }

        private void ChangeFileName(string sourceName, string destName, string path)
        {
            string destPath = path.Replace(sourceName,destName);

            if (File.Exists(destPath))
            {
                Debug.LogError(GetType() + "/()/ The name is Existed, Please Rename");
            }
            else { 
                File.Move(path,destPath);

            }

        }
    }

    

    public class NameMgrWindowData {
        public static Dictionary<FolderData, List<string>> SpriteDict = new Dictionary<FolderData, List<string>>();

        public static void Add(FolderData key, string value) {
            if (SpriteDict.ContainsKey(key)==false)
            {
                SpriteDict[key] = new List<string>();
            }

            SpriteDict[key].Add(value);
        }

        public static void UpdateData() {
            foreach (KeyValuePair<FolderData, List<string>> pair in SpriteDict)
            {
                int count = pair.Value.Count;
                for (int i = 0; i < count; i++)
                {
                    if (File.Exists(pair.Value[i])==false)
                    {
                        pair.Value.Remove(pair.Value[i]);
                        i--;
                    }
                }
            }
        }
    }

    public class FolderData {
        public string FolderPath;
        public string NameTip;
    }
}
