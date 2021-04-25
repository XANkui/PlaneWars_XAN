/****************************************************
文件：InitCustomAttribute.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 16:04:02
功能：初始化特性
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Stduy_XAN { 

	public class InitCustomAttributes 
	{
		public void Init() {
			Assembly assembly = Assembly.GetAssembly(typeof(BindPrefab));
			Type[] types = assembly.GetExportedTypes();

            foreach (Type type in types)
            {
                foreach (Attribute attribute in Attribute.GetCustomAttributes(type,true))
                {
                    if (attribute is BindPrefab)
                    {
                        BindPrefab data = attribute as BindPrefab;
                        BindPrefabPathAndScriptUtil.Bind(data.Path, type);
                    }
                }
            }
		}
	}
}
