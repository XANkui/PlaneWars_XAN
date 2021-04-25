/****************************************************
文件：BIndUtil.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 18:14:28
功能：根据特性绑定脚本
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class BindUtil : NormalSingleton<BindUtil>
	{
		private static Dictionary<string, List<Type>> mPrefabPathAndScriptMap = new Dictionary<string, List<Type>>();
		private static Dictionary<Type, int> mPriorityMap = new Dictionary<Type, int>();
		public static void Bind(BindPrefabPath data, Type type)
		{
			string path = data.Path;

			if (mPrefabPathAndScriptMap.ContainsKey(path) == false)
			{
				mPrefabPathAndScriptMap.Add(path, new List<Type>());
			}

            if (mPrefabPathAndScriptMap[path].Contains(type) ==false)
            {
				mPrefabPathAndScriptMap[path].Add(type);
				mPriorityMap.Add(type, data.Priority);
				mPrefabPathAndScriptMap[path].Sort(new BindPriorityCompare());
			}
		}

		public static List<Type> GetType(string path)
		{
			if (mPrefabPathAndScriptMap.ContainsKey(path) == true)
			{
				return mPrefabPathAndScriptMap[path];
			}
			else
			{
				Debug.LogError("mPrefabPathAndScriptMap.ContainsKey(path) is false, path = " + path);
				return null;
			}
		}

		public class BindPriorityCompare : IComparer<Type>
		{
			public int Compare(Type x ,Type y)
			{
                if (x==null)
                {
					return 1;
                }
                if (y==null)
                {
					return -1;
                }

				return mPriorityMap[x] - mPriorityMap[y];
			}
		}
	}

	
}
