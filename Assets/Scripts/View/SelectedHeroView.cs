/****************************************************
文件：SelectedHeroView.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 22:04:59
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 
	[BindPrefabPath(Paths.SELECTED_HERO_VIEW, Const.BIND_PREFAB_PRIORITY_VIEW)]
	public class SelectedHeroView : ViewBase
	{

        protected override void InitChild()
        {
            transform.Find("Heros").gameObject.AddComponent<SelectHero>();
            
        }
    }
}
