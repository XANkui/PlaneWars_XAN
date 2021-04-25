/****************************************************
文件：AttributeWithPathToAddPrefabScript.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 16:18:39
功能：测试使用特性自动添加脚本
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stduy_XAN { 

	public class AttributeWithPathToAddPrefabScript : MonoBehaviour
	{
		public Transform parent;
		public string path;

		// Start is called before the first frame update
		void Start()
		{
			TestAttributeWithPathToAddPrefabScript();
		}

        void TestAttributeWithPathToAddPrefabScript() {

			InitAttribute();

			GameObject prefab = Resources.Load<GameObject>(path);
			GameObject tmp = GameObject.Instantiate(prefab, parent);
			Type type = BindPrefabPathAndScriptUtil.GetType(path);
			tmp.AddComponent(type);
		}

		private void InitAttribute()
		{
			InitCustomAttributes attributes = new InitCustomAttributes();
			attributes.Init();
		}
	}
}
