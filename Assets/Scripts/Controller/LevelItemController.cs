/****************************************************
文件：LevelItemController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 18:12:27
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LevelItemController : ControllerBase
	{
        private int mID;
        protected override void InitChild()
        {
            mID = transform.GetSiblingIndex();

            // 跳转到Loading界面
            transform.ButtonAction("Enter", () => { 
                GameStateModel.Instance.TargetScene = SceneName.Game;
                UIMgr.Instance.Show(Paths.LOADING_VIEW);
            });
            transform.ButtonAction("Mask",()=> { UIMgr.Instance.ShowDialog("The Level is Not Opened!!"); });
        }

        
    }
}
