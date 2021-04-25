/****************************************************
文件：ILoader.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 14:59:31
功能：资源加载接口
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public interface ILoader 
	{
		GameObject LoadPrefab(string path, Transform parent);

		void LoadConfig(string path, Action<object> complete);

		T Load<T>(string path) where T : UnityEngine.Object;

		T[] LoadAll<T>(string path) where T : UnityEngine.Object;
	}
}
