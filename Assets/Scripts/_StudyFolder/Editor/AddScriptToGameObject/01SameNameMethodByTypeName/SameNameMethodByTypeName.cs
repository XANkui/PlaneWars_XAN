/****************************************************
文件：SameNameMethodByTypeName.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 15:20:33
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stduy_XAN { 

	public class SameNameMethodByTypeName : MonoBehaviour
	{
		public Transform parent;
		public string path;

		// Start is called before the first frame update
		void Start()
		{
			TestSameNameMethodByTypeName();
		}

		void TestSameNameMethodByTypeName() {
			GameObject prefab = Resources.Load<GameObject>(path);
			GameObject tmp = GameObject.Instantiate(prefab,parent);
			SameNameTypeNameTOAddScript(tmp);

		}

		void SameNameTypeNameTOAddScript(GameObject go) {
			string typeName = go.name.Substring(0, go.name.Length - 7); // 移除生成后自动生成的（clone）
			Debug.Log(GetType()+ "/SameNameTypeNameTOAddScript()/ typeName = " + typeName);
			Debug.Log(GetType()+ "/SameNameTypeNameTOAddScript()/ GetType() = " + GetType());

			// 如果你的 类在同名命名空间里面（如果不是同名命名空间，可能需要其他方式），注意添加
			// 没有命名空间可忽略
			typeName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + typeName; 
			
			Type type = Type.GetType(typeName);
			go.AddComponent(type);

		}
	}
}
