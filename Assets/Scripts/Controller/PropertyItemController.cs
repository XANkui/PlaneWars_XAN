using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class PropertyItemController : ControllerBase
	{
		private string mKey;

		protected override void InitChild()
        {
			InitButtonAction();

		}

        public void Init(string key)
        {
			mKey = key;

		}

		private void InitButtonAction()
		{
			transform.ButtonAction("Add", AddAction);
		}

		private void AddAction()
		{
			string key = KeysUtil.GetPropertyKeys(mKey+DataKeys.COST_UNIT);
			string unit = DataMgr.Instance.Get<string>(key);
			int money = GameStateModel.Instance.GetMoney(unit);

			key = KeysUtil.GetNewKey(PropertyItem.ItemKey.cost, mKey);
			int cost = DataMgr.Instance.Get<int>(key);

			if (money >= cost)
			{
				ChangeData();

			}
			else {
				UIMgr.Instance.ShowDialog("Your Star is not enough");

			}

		}

		private void ChangeData() {
			string valueKey = KeysUtil.GetNewKey(PropertyItem.ItemKey.value, mKey);
			int value = GetValue(valueKey);

			string grouthKey = KeysUtil.GetNewKey(PropertyItem.ItemKey.grouth, mKey);
			int grouth = GetValue(grouthKey);

			value += grouth;

			DataMgr.Instance.SetObject(valueKey, value);
		}

		private int GetValue(string key)
		{
			return DataMgr.Instance.Get<int>(key);
		}

		
	}
}
