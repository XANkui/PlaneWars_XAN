/****************************************************
文件：JsonMemory.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 10:22:27
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class JsonMemory : IDataMemory
	{
        public T Get<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            throw new System.NotImplementedException();
        }

        public void Clear(string key)
        {
            throw new System.NotImplementedException();
        }

        public void ClearAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(string key)
        {
            throw new System.NotImplementedException();
        }

        public object GetObject(string key)
        {
            throw new System.NotImplementedException();
        }

        public void SetObject(string key, object value)
        {
            throw new System.NotImplementedException();
        }
    }
}
