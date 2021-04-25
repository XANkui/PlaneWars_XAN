/****************************************************
文件：SwitchPlayer.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 17:44:13
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class SwitchPlayer : ViewBase
	{


        protected override void InitChild()
        {
           
        }


        public override void Show()
        {
            base.Show();
            // 更新数据显示使用
            UpdateSprite();
        }


        public override void UpdateFunc()
        {
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            int id = GameStateModel.Instance.SelectedPlaneID;

            string key = KeysUtil.GetPropertyKeys(DataKeys.LEVEL);
            int level = DataMgr.Instance.Get<int>(key);
            Debug.Log("--------- id = "+id + " , Level = "+level);
            UIUtil.Get("Icon").SetSprite(PlaneSpriteModel.Instance[id,level]) ;
        }
    }
}
