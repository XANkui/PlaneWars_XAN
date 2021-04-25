/****************************************************
文件：ABLoader.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 15:03:10
功能：AB 包方式加载资源
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class ABLoader : ILoader
	{
        public GameObject LoadPrefab(string path, Transform parent)
        {
            throw new System.NotImplementedException();
        }

        public void LoadConfig(string path, Action<object> complete)
        {
            throw new NotImplementedException();
        }

        public T Load<T>(string path) where T : UnityEngine.Object
        {
            throw new NotImplementedException();
        }

        public T[] LoadAll<T>(string path) where T : UnityEngine.Object
        {
            throw new NotImplementedException();
        }
    }
}
