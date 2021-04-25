/****************************************************
文件：DataUtil.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 10:20:33
功能：Nothing
*****************************************************/

using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public static class DataUtil 
	{
		public static void SetJsonData(this DataMgr dataMgr, string key, JsonData data) {
            IJsonWrapper jsonWrapper = data;
            
            switch (data.GetJsonType())
            {
                case JsonType.None:
                    Debug.Log("jsondata is empty");
                    break;
                case JsonType.Object:
                    SetObjectData(key, data);
                    break;

                case JsonType.String:
                    DataMgr.Instance.Set(key, jsonWrapper.GetString()) ;
                    break;
                case JsonType.Int:
                    DataMgr.Instance.Set(key, jsonWrapper.GetInt());

                    break;
                case JsonType.Long:
                    DataMgr.Instance.Set(key, (int)jsonWrapper.GetLong());

                    break;
                case JsonType.Double:
                    DataMgr.Instance.Set(key, (float)jsonWrapper.GetDouble());

                    break;

            }
        }

        private static void SetObjectData(string oldKey, JsonData data) {
            foreach (string key in data.Keys)
            {
                string newKey = oldKey + key;
                if (DataMgr.Instance.Contains(newKey)==false)
                {
                    DataMgr.Instance.SetJsonData(newKey, data[key]);
                }
            }
        }
	}
}
