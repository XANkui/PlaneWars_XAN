/****************************************************
文件：JsonReader.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 10:43:24
功能：Nothing
*****************************************************/

using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace PlaneWars_XAN { 

    // 数据访问方式
    // json["xx"][2]["xxxx"].Get<T>(action<T>)
	public class JsonReader : IReader
	{
        private JsonData mData;
        private JsonData mTmpData;

        private KeyQueue mKeyQueue;
        private Queue<KeyQueue> mKeyQueues =new Queue<KeyQueue>();

        public IReader this[string key] { 
            get {
                if (SetKey(key)==false)
                {
                    try
                    {
                        mTmpData = mTmpData[key];
                    }
                    catch (Exception)
                    {

                        Debug.LogError(GetType()+"/()/ Dont find value of key :" + mTmpData.ToJson());
                    }
                    
                }

                return this; 
            } 
        }

        public IReader this[int key] { 
            get {
                if (SetKey(key) == false)
                {
                    try
                    {
                        mTmpData = mTmpData[key];
                    }
                    catch (Exception)
                    {

                        Debug.LogError(GetType() + "/()/ Dont find value of key :" + mTmpData.ToJson());
                    }
                }
                return this; 
            } 
        }

        private bool SetKey<T>(T key) {
            if (mData == null || mKeyQueue != null)
            {
                if (mKeyQueue==null)
                {
                    mKeyQueue = new KeyQueue();

                }

                IKey keyData = new Key();
                keyData.Set(key);
                mKeyQueue.Enqueue(keyData);

                return true;
            }

            return false;
        }

        private void ResetData() {
            mTmpData = mData;
        }

        public void Get<T>(Action<T> callback)
        {
            if (mKeyQueue !=null)
            {
                mKeyQueue.OnComplete((tmpData)=> {
                    T value = GetValue<T>(tmpData);
                    ResetData();
                    callback(value);
                    
                });

                mKeyQueues.Enqueue(mKeyQueue);
                mKeyQueue = null;
                ExecuteKeysQueue();
                return;
            }

            if (callback == null)
            {
                Debug.LogWarning(GetType()+ "/Get()/callback is null, Don't return data");
                ResetData();

                return;
            }
            T data = GetValue<T>(mTmpData);
            ResetData();
            callback(data);
            
        }

        private void ExecuteKeysQueue() {
            if (mData==null)
            {
                return;
            }

            IReader reader = null;

            foreach (KeyQueue keyQueue in mKeyQueues)
            {
                foreach (object value in keyQueue)
                {
                    if (value is string)
                    {
                        reader = this[(string)value];
                    }
                    else if (value is int)
                    {
                        reader = this[(int)value];
                    }
                    else if (value is Action)
                    {
                        ((Action)value)();
                    }
                    else {
                        Debug.LogError(GetType()+ "/ExecuteKeysQueue()/ the type of key is error");
                    }

                    
                }

                keyQueue.Complete(mTmpData);
            }
        }

        private T GetValue<T>(JsonData data) {
            var convert = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                if (convert.CanConvertTo(typeof(T)))
                {
                    return (T)convert.ConvertTo(data.ToJson(), typeof(T));

                }
                else {
                    return (T)(object)data;
                }
            }
            catch (Exception)
            {

                Debug.LogError(GetType()+ "/GetValue()/ There is a problem with data conversion, The Type = " + typeof(T).Name);
                return default(T);
            }
        }

        public void SetData(object data) {
            if (data is string)
            {
                mData = JsonMapper.ToObject(data as string);
                ResetData();
                ExecuteKeysQueue();
            }
            else {
                Debug.LogError(GetType()+ "/SetData()/ type of data is error. this needs json type.");
            }           
        }

        public ICollection<string> Keys()
        {
            if (mTmpData==null)
            {
                return new string[0];
            }

            return mTmpData.Keys;
        }

        public void Count(Action<int> callback)
        {
            bool isSuccess =  SetKey<Action>(()=> {
                if (callback!=null)
                {
                    callback.Invoke(GetCount());
                }
               
            });

            if (isSuccess == false)
            {
                if (callback != null)
                {
                    callback.Invoke(GetCount());
                }
            }
            else {
                mKeyQueues.Enqueue(mKeyQueue);
                mKeyQueue = null;
            }

        }

        private int GetCount() {
            return mTmpData.IsArray ? mTmpData.Count : 0;
        }
    }

    public class KeyQueue :IEnumerable{
        private Queue<IKey> mKeys = new Queue<IKey>();

        private Action<JsonData> mOnCompelte;

        public void Enqueue(IKey key) {
            mKeys.Enqueue(key);
        }

        public void Dequeue()
        {
            mKeys.Dequeue();
        }

        public void Clear()
        {
            mKeys.Clear();
        }

        public void Complete(JsonData jsonData) {
            if (mOnCompelte != null)
            {
                mOnCompelte.Invoke(jsonData);
            }
        }

        public void OnComplete(Action<JsonData> onComplete) {
            mOnCompelte = onComplete;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (IKey key in mKeys)
            {
                yield return key.Get();
            }
        }
    }

    public interface IKey {
        void Set<T>(T key);
        object Get();
        Type KeyType { get; }
    }

    public class Key: IKey
    {

        private object mKey;
        public Type KeyType { get; private set; }
        public void Set<T1>(T1 key) 
        {
            mKey = key;
        }

        public object Get() 
        {
            return mKey;
        }

        
    }
}
