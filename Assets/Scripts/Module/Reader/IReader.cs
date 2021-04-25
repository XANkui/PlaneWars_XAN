/****************************************************
文件：IReader.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 10:23:01
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public interface IReader 
	{
		IReader this[string key] { get; }
		IReader this[int key] { get; }
		void Count(Action<int> callback);
		void Get<T>(Action<T> callback);
		void SetData(object data);

		ICollection<string> Keys();
	}
}
