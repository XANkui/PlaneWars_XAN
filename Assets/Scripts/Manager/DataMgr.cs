/****************************************************
文件：DataMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 09:06:10
功能：数据管理类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class DataMgr : NormalSingleton<DataMgr>,IDataMemory
	{
        private IDataMemory mDataMemory;

        public DataMgr() {
            mDataMemory = new PlayerPrefsMemory();
        }

        public T Get<T>(string key)
        {
            return mDataMemory.Get<T>(key);
        }

        public void Set<T>(string key, T value)
        {
            mDataMemory.Set<T>(key,value);
        }

        public void Clear(string key)
        {
            mDataMemory.Clear(key);
        }

        public void ClearAll()
        {
            mDataMemory.ClearAll();
        }

        public bool Contains(string key)
        {
            return mDataMemory.Contains(key);
        }

        public object GetObject(string key)
        {
            return mDataMemory.GetObject(key);
        }

        public void SetObject(string key, object value)
        {
            mDataMemory.SetObject(key, value);
        }
    }
}
