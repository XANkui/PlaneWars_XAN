/****************************************************
文件：KeyUtil.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 09:08:04
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class KeysUtil 
	{
		public static string GetPropertyKeys( string name) {
			int id = GameStateModel.Instance.SelectedPlaneID;
			return id + name;
		}

		public static string GetPropertyKeys(int id, string name)
		{
			return id + name;
		}

		public static string GetNewKey(PropertyItem.ItemKey key, string propertyName) {
			
			return GetPropertyKeys( propertyName + key);
		}
	}
}
