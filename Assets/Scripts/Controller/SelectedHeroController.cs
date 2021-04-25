/****************************************************
文件：SelectedHeroController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 23:25:52
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

    [BindPrefabPath(Paths.SELECTED_HERO_VIEW, Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
	public class SelectedHeroController : ControllerBase
	{
        protected override void InitChild()
        {
           
           transform.Find("Heros").gameObject.AddComponent<SelectHeroController>();

            transform.ButtonAction("OK/Start", ()=> {
                Debug.Log(GetType() + "/AddListener()/ click StartBtn");

                // 切换到选择关卡界面
                UIMgr.Instance.Show(Paths.LEVELS_VIEW);
            });

            transform.ButtonAction("Exit", () => {
                Application.Quit();
            });

            transform.ButtonAction("Strengthen", () => {
                //  切换到强化界面
                UIMgr.Instance.Show(Paths.PREFAB_STRENGTHEN_VIEW);
            });

            


        }
    }
}
