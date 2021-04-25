/****************************************************
文件：LevelsView.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 12:11:00
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	[BindPrefabPath(Paths.LEVELS_VIEW,Const.BIND_PREFAB_PRIORITY_VIEW)]
	public class LevelsView : ViewBase
	{
	

        protected override void InitChild()
        {
            UIUtil.Get("Levels").Go.AddComponent<LevelsRoot>();
        }
    }
}
