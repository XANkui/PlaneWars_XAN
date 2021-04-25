/****************************************************
文件：Money.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/22 15:45:35
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class Money : ViewBase
	{
        protected override void InitChild()
        {
        }

        public override void UpdateFunc()
        {
            UIUtil.Get("Star/BG/Text").SetText(DataMgr.Instance.Get<int>(DataKeys.STAR).ToString()); 
            UIUtil.Get("Diamond/BG/Text").SetText(DataMgr.Instance.Get<int>(DataKeys.DIAMOND).ToString()); 
        }
    }
}
