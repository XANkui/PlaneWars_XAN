/****************************************************
文件：StartController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 18:11:15
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	[BindPrefabPath(Paths.START_VIEW,Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
	public class StartController : ControllerBase
	{

        protected override void InitChild()
        {

            transform.ButtonAction("Start",()=>{
                UIMgr.Instance.Show(Paths.SELECTED_HERO_VIEW);
                AudioMgr.Instance.PlayOnce(UIAudio.StartGame.ToString());
            },false);

            //AudioMgr.Instance.PlayBG(BGAudio.Game_BG);
        }

        
    }
}
