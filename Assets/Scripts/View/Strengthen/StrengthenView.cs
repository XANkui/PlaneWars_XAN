/****************************************************
文件：StrengthenView.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 17:42:07
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 
	[BindPrefabPath(Paths.PREFAB_STRENGTHEN_VIEW, Const.BIND_PREFAB_PRIORITY_VIEW)]
	public class StrengthenView : ViewBase
	{

        protected override void InitChild()
        {
            UIUtil.Get("Switchplayer").Go.AddComponent<SwitchPlayer>();
            UIUtil.Get("Property").Go.AddComponent<PlaneProperty>();
            UIUtil.Get("Money").Go.AddComponent<Money>();

        }

        public override void UpdateFunc()
        {
            base.UpdateFunc();
            UpdateLevelView();
             
        }

        private void UpdateLevelView() {

            string key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES);
            string data = DataMgr.Instance.Get<string>(key);
            UIUtil.Get("Upgrades/Text").SetText(data) ;

            // 花费
            key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES + DataKeys.NAME);
            int level = DataMgr.Instance.Get<int>(DataKeys.LEVEL);
            key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES + level);            
            int cost = DataMgr.Instance.Get<int>(key);
            UIUtil.Get("Upgrades/Upgrades/Text").SetText(cost);
        }
    }
}
