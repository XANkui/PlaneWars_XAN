/****************************************************
文件：LevelsController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 12:12:44
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN {
    [BindPrefabPath(Paths.LEVELS_VIEW, Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
    public class LevelsController : ControllerBase
	{
        protected override void InitChild()
        {
            transform.ButtonAction("Back",UIMgr.Instance.Back);
            transform.Find("Levels").gameObject.AddComponent<LevelsRootController>();
        }
    }
}
