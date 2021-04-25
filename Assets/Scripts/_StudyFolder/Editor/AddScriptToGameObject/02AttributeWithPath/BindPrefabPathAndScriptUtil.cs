/****************************************************
文件：BindPrefabPathAndScript.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 16:13:21
功能：绑定预制体路径与脚本的关系
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stduy_XAN { 

	public class BindPrefabPathAndScriptUtil
	{
		private static Dictionary<string, Type> mPrefabPathAndScriptMap = new Dictionary<string, Type>();

		public static void Bind(string path, Type type) {
			if (mPrefabPathAndScriptMap.ContainsKey(path) == false)
			{
				mPrefabPathAndScriptMap.Add(path, type);
			}
			else {
				Debug.LogError("mPrefabPathAndScriptMap.ContainsKey(path) is true, path = "+path);
			}
		}

		public static Type GetType(string path) {
			if (mPrefabPathAndScriptMap.ContainsKey(path) == true)
			{
				return mPrefabPathAndScriptMap[path];
			}
			else {
				Debug.LogError("mPrefabPathAndScriptMap.ContainsKey(path) is false, path = " + path);
				return null;
			}
		}
	}
}
