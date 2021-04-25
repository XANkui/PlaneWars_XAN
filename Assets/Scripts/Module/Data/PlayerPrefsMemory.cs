/****************************************************
文件：PlayerPrefsMemory.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 09:13:08
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class PlayerPrefsMemory : IDataMemory
	{
        private Dictionary<Type, Func<string, object>> mDataGetter = new Dictionary<Type, Func<string, object>>() {
            { typeof(int), (key)=>PlayerPrefs.GetInt(key, (int)mDefaultValues[typeof(int)]) },
            { typeof(float), (key)=>PlayerPrefs.GetFloat(key, (float)mDefaultValues[typeof(float)]) },
            { typeof(string), (key)=>PlayerPrefs.GetString(key, (string)mDefaultValues[typeof(string)]) }
        };

        private Dictionary<Type, Action<string, object>> mDataSetter = new Dictionary<Type, Action<string, object>>() {
            { typeof(int), (key,value)=>PlayerPrefs.SetInt(key, (int)value) },
            { typeof(float), (key,value)=>PlayerPrefs.SetFloat(key, (float)value) },
            { typeof(string), (key,value)=>PlayerPrefs.SetString(key, (string)value) }
        };

        private static Dictionary<Type, object> mDefaultValues = new Dictionary<Type, object>() {
            { typeof(int), default(int) },
            { typeof(string), "" }, // default(string) = null，而不是“”
            { typeof(float), default(float) }
        };

        public T Get<T>(string key)
        {
            Type type = typeof(T);
            var converter = TypeDescriptor.GetConverter(type);

            if (mDataGetter.ContainsKey(type))
            {
                return (T)converter.ConvertTo(mDataGetter[type](key), type);
            }
            else {
                Debug.LogError(GetType()+"/()/ There is not the type data :"+typeof(T).Name);
                return default(T);
            }
        }

        public void Set<T>(string key, T value)
        {
            Type type = typeof(T);

            if (mDataSetter.ContainsKey(type))
            {
                mDataSetter[type](key,value);
            }
            else
            {
                Debug.LogError(GetType() + "/()/ There is not the type data, key = " + key + " , value = "+value);
            }
        }

        public void SetObject(string key, object value)
        {
            bool success = false;
            foreach (KeyValuePair<Type,Action<string,object>> pair in mDataSetter)
            {
                if (value.GetType() == pair.Key)
                {
                    pair.Value(key,value);
                    success = true;
                }
            }

            if (success == false)
            {
                Debug.LogError("Did not find the value in Data, value = "+value);
            }
        }

        public object GetObject(string key) {
            if (Contains(key))
            {
                foreach (KeyValuePair<Type, Func<string, object>> pair in mDataGetter)
                {
                    object value = pair.Value(key);
                    if (value.Equals(mDefaultValues[pair.Key]) == false)
                    {
                        return value;
                    }
                }
            }
            else {
                Debug.LogError(GetType()+ "/GetString()/There is no value of key, key = "+key);
            }

            return null;
        }

        public void Clear(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public void ClearAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public bool Contains(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

       
    }
}
