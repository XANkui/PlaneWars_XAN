/****************************************************
文件：IData.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 09:06:51
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public interface IDataMemory 
	{

		T Get<T>(string key);
		void Set<T>(string key, T value);

		void Clear(string key);

		void ClearAll();

		bool Contains(string key);

		object GetObject(string key);

		void SetObject(string key, object value);
	}
}
