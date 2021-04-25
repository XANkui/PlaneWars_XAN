/****************************************************
文件：ConfigMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 08:57:31
功能：Nothing
*****************************************************/

using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class ConfigMgr : NormalSingleton<ConfigMgr>,IInit
	{
		public void Init() {
            InitPlaneConfig();

        }

		void InitPlaneConfig() {
            var config = ReadMgr.Instance.GetReader(Paths.CONFIG_INIT_PLANE_CONFIG);
            config["planes"].Get<JsonData>((data) => {
                foreach (JsonData item in data)
                {
                    foreach (string key in item.Keys)
                    {
                        if (key == "planeId")
                        {
                            continue;
                        }

                        string newKey = KeysUtil.GetPropertyKeys(int.Parse(item["planeId"].ToJson()), key);

                        if (DataMgr.Instance.Contains(newKey)==false)
                        {
                            DataMgr.Instance.SetJsonData(newKey, item[key]);
                        }
                    }
                }
            });
        }
	}
}
