/****************************************************
文件：TestJsonReader.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 14:59:44
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class TestJsonReader : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			Test();
			Test2();
		}

		void Test() {
			JsonReader reader = new JsonReader();
			reader["planes"][0]["level"].Get<float>((value) => Debug.Log(value)) ;
			reader["planes"][0]["planeId"].Get<int>((value) => Debug.Log(value)) ;
			reader.SetData(mTestJsonStr);
		}

		void Test2() {
			IReader reader = ReadMgr.Instance.GetReader(Paths.CONFIG_INIT_PLANE_CONFIG);
			reader["planes"][0]["planeId"].Get<int>((value) => Debug.Log(value));
		}

		private string mTestJsonStr = "{'planes':[{'planeId':0,'level':1.1}]}";
	}
}
