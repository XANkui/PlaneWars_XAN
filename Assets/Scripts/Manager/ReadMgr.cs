/****************************************************
文件：ReadMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 15:26:11
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class ReadMgr : NormalSingleton<ReadMgr>
	{
		private Dictionary<string, IReader> mReadersDict = new Dictionary<string, IReader>();

		public IReader GetReader(string path) {
			IReader reader = null;

			if (mReadersDict.ContainsKey(path))
			{
				reader = mReadersDict[path];
			}
			else {
				//获取一个新的Reader，并读取数据
				reader = ReaderConfig.GetReader(path);
				LoadMgr.Instance.LoadConfig(path,(data)=> {
					reader.SetData(data);
				});

				if (reader != null)
				{
					mReadersDict[path] = reader;

				}
				else {
					Debug.LogError(GetType()+ "/GetReader()/" + "There is no one reader for path:" + path);
				}
			}

			return reader;
		}
	}
}
