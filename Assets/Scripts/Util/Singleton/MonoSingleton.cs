/****************************************************
文件：MonoSingleton.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 14:42:00
功能：mono 单例类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T mInstance;

		public static T Instance {
			get {
                if (mInstance==null)
                {
					mInstance = FindObjectOfType<T>();
                    if (mInstance==null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        mInstance = go.AddComponent<T>();
                        DontDestroyOnLoad(go);
                    }
                }

				return mInstance;
			}
		}

        protected virtual void Awake()
        {
            // 避免过场切回原场景，多存在
            if (mInstance == null)
            {
                DontDestroyOnLoad(this);
            }
            else {
                Destroy(this.gameObject);
            }
        }
    }
}
