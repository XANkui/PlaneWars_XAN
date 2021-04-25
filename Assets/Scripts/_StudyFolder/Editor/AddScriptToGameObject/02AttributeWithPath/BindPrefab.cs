/****************************************************
文件：BindPrefab.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 15:54:59
功能：特性加载基本的，用于绑定脚本与预制体的关系
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stduy_XAN { 

	// 限制特性适用范围 为 类 class
	[AttributeUsage(AttributeTargets.Class)]
	public class BindPrefab : Attribute
	{
        public BindPrefab(string path)
        {
            Path = path;
        }

        public string Path { get; private set; }

	}
}
