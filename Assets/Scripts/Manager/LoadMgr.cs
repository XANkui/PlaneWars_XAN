/****************************************************
文件：LoadMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 15:05:51
功能：管理资源加载
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LoadMgr : NormalSingleton<LoadMgr>, ILoader // 继承接口类，方便对应对应函数
	{
		private ILoader mLoader;

		public LoadMgr() {
			mLoader = new ResourcesLoader();
		}

        public GameObject LoadPrefab(string path, Transform parent)
        {
			return mLoader.LoadPrefab(path,parent);

		}

        public void LoadConfig(string path, Action<object> complete)
        {
			mLoader.LoadConfig(path, complete);

		}

        public T Load<T>(string path) where T : UnityEngine.Object
        {
            return mLoader.Load<T>(path);
        }

        public T[] LoadAll<T>(string path) where T : UnityEngine.Object
        {
            return mLoader.LoadAll<T>(path);
        }
    }
}
