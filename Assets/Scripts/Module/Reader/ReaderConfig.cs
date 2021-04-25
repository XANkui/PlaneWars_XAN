/****************************************************
文件：ReaderConfig.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 15:33:04
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class ReaderConfig 
	{
		private static readonly Dictionary<string, Func<IReader>> mReadersDict = new Dictionary<string, Func<IReader>>() {
			{ ".json",()=>new JsonReader()}
		
		};

		public static IReader GetReader(string path) {
            foreach (KeyValuePair<string,Func<IReader>> pair in mReadersDict)
            {
                if (path.Contains(pair.Key))
                {
					return pair.Value();
                }
            }

			Debug.LogError("There is no one reader for path:"+path);

			return null;
		}
	}
}
