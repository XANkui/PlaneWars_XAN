/****************************************************
文件：ExtendUtil.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 08:41:03
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public static class ExtendUtil
	{
		public static RectTransform Rect(this Transform trans) {
			return trans.GetComponent<RectTransform>();
		}

		public static void ButtonAction(this Transform trans,string path, Action action, bool isDefaultAudio=true) {
			var target = trans.Find(path);

			if (target == null)
			{
				Debug.LogError("There is no target , ptah = " + path);
			}
			else {
				var btn = target.GetComponent<Button>();

				if (btn == null)
				{
					Debug.LogError("There is no Button , name = " + target.name);
				}
				else {
					btn.onClick.AddListener(()=> action());
					if(isDefaultAudio)
						AddButtonDefaultAudio();
				}
			}
		}

		private static void AddButtonDefaultAudio() {
			AudioMgr.Instance.PlayOnce(UIAudio.ClickButton.ToString());
		}
	}
}
