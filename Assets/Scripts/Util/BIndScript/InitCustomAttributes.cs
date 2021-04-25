/****************************************************
文件：InitCustomAttributes.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 21:33:25
功能：初始化自定义特性
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class InitCustomAttributes : IInit
	{
        public void Init()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(BindPrefabPath));
            Type[] types = assembly.GetExportedTypes();

            foreach (Type type in types)
            {
                foreach (Attribute attribute in Attribute.GetCustomAttributes(type, true))
                {
                    if (attribute is BindPrefabPath)
                    {
                        BindPrefabPath data = attribute as BindPrefabPath;
                        BindUtil.Bind(data, type);
                    }
                }
            }
        }
    }
}
