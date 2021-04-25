/****************************************************
文件：NormalSingleton.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 14:42:00
功能：mono 单例类
*****************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN
{ 

	public class NormalSingleton <T>  where T : class, new()
	{
		private static T mInstance;

		public static T Instance {
			get {
                if (mInstance==null)
                {
					T t = new T();
                    if (t is MonoBehaviour)
                    {
						Debug.LogError("Mono class need use Monosingleton");
						return null;
                    }

					mInstance = t;
                }

				return mInstance;
			}
		}

	}
}
