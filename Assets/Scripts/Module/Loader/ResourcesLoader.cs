/****************************************************
文件：ResourcesLoader.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 14:59:42
功能：Resources 方式加载资源
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class ResourcesLoader : ILoader
	{
		public GameObject LoadPrefab(string path, Transform parent) {
			GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab==null)
            {
				Debug.LogError(GetType()+ "/LoadPrefab()/ perfab loaded unsuccessfully , ptah : "+ path);
				return null;
            }
			GameObject tmp = GameObject.Instantiate(prefab, parent);
			return tmp;
		}

		public T Load<T>(string path) where T : UnityEngine.Object{
			T sprite = Resources.Load<T>(path);
            if (sprite==null)
            {
				Debug.LogError(GetType()+ "/LoadSprite()/ Dont Find asset ，path = "+path);
            }
			return sprite;
		}

		public T[] LoadAll<T>(string path) where T : UnityEngine.Object
		{
			T[] sprites = Resources.LoadAll<T>(path);
			if (sprites == null)
			{
				Debug.LogError(GetType() + "/LoadSprite()/ Dont Find asset ，path = " + path);
			}
			return sprites;
		}

		public void LoadConfig(string path, Action<object> complete)
        {
			CoruotineMgr.Instance.ExecuteOnce(Config(path, complete));
		}

		private IEnumerator Config(string path, Action<object> complete) {

            if (Application.platform != RuntimePlatform.Android)
            {
				path = "file://" + path;
			}
			
			WWW www = new WWW(path);
			yield return www;

            if (www.error != null)
            {
				Debug.LogError(GetType()+"/()/ load failly, path = "+path);
				yield break;
            }

			complete(www.text);
			Debug.Log(GetType()+"/()/ Load ok, path = "+path);
		}
    }
}
