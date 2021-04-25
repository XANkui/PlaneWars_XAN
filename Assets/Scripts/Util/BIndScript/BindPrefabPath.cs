/****************************************************
文件：BindPrefabPath.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 21:32:05
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN {

	// 限制特性适用范围 为 类 class
	[AttributeUsage(AttributeTargets.Class)]
	public class BindPrefabPath : Attribute
	{
		public BindPrefabPath(string path,int priority)
		{
			Path = path;
			Priority = priority;
		}

		public string Path { get; private set; }
		public int Priority { get; private set; }
	}
}
