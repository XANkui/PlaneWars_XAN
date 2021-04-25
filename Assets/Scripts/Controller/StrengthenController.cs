/****************************************************
文件：StrengthenController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 23:34:37
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 
    [BindPrefabPath(Paths.PREFAB_STRENGTHEN_VIEW,Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
	public class StrengthenController : ControllerBase
	{
        protected override void InitChild()
        {
            transform.Find("Switchplayer").gameObject.AddComponent<SwitchPlayerController>();
            transform.Find("Property").gameObject.AddComponent<PlanePropertyController>();

            transform.ButtonAction("Upgrades/Upgrades",Upgrades);
            transform.ButtonAction("Back",UIMgr.Instance.Back);
        }

        private void Upgrades() {
            // Todo:
            // 判断是否能够升级
            // 话费是否足够，当前等级是否超限

            string key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES + DataKeys.COST_UNIT);
            string value = DataMgr.Instance.Get<string>(key);

            int level = GameStateModel.Instance.Level;
            key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES + level);
            int cost = DataMgr.Instance.Get<int>(key);

            int money = GameStateModel.Instance.GetMoney(value);
            

            int levelMax = DataMgr.Instance.Get<int>(DataKeys.LEVEL_MAX);

            if (money >= cost && level < levelMax)
            {
                ChangeMoney(value, cost);
                ChangeData();

            }
            else {
                UIMgr.Instance.ShowDialog("Your Diamond is not enough");
            }

        }

        private void ChangeMoney(string costUnit,int cost) {
            int money = GameStateModel.Instance.GetMoney(costUnit);
            GameStateModel.Instance.SetMoney(costUnit,money - cost);
        }

        private void ChangeLevel() {
            string key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES_RATIO);
            int level = GameStateModel.Instance.Level;
            level++;
            DataMgr.Instance.Set<int>(key, level);
        }

        private void ChangeData() {
            // 获取升级系数，修改升级数据
            string key = KeysUtil.GetPropertyKeys(DataKeys.UPGRADES_RATIO);
            int ratio = DataMgr.Instance.Get<int>(key);

            ChangeData(ratio, PropertyItem.ItemKey.value, PlaneProperty.Property.attack);
            ChangeData(ratio, PropertyItem.ItemKey.maxVaue, PlaneProperty.Property.attack);
            ChangeData(ratio, PropertyItem.ItemKey.grouth, PlaneProperty.Property.attack);

            ChangeData(ratio, PropertyItem.ItemKey.value, PlaneProperty.Property.life);
            ChangeData(ratio, PropertyItem.ItemKey.maxVaue, PlaneProperty.Property.life);
            ChangeData(ratio, PropertyItem.ItemKey.grouth, PlaneProperty.Property.life);
        }

        private void ChangeData(int ratio, PropertyItem.ItemKey itemKey, PlaneProperty.Property property) {
            string key = KeysUtil.GetNewKey(itemKey, property.ToString());
            int value = DataMgr.Instance.Get<int>(key);
            value *= ratio;
            DataMgr.Instance.Set(key,value);
        }
    }
}
