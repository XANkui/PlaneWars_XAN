/****************************************************
文件：PropertyItem.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 08:14:15
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public class PropertyItem : MonoBehaviour,IViewUpdate,IViewShow
	{
		// 枚举名称同配置表的对应名称一致
		public enum ItemKey { 
			name,
			value,
			cost,
			grouth,
			maxVaue	
		}

		private static int mItemID = -1;

		private string mKey;

        public void Init(string key)
        {
			mKey = key;
			mItemID++;
			UpdatePos(mItemID);

		}

		private void UpdatePos(int itemId) {
			RectTransform rect = transform.Rect();
			float offset = rect.rect.height * itemId;
			rect.anchoredPosition -= offset * Vector2.up;
		}

		public void UpdatePlaneId(int planeId) { 
			//var config = ReadMgr.Instance.GetReader(Paths.CONFIG_INIT_PLANE_CONFIG);
			//mConfig = config["planes"][planeId][mKey];

			UpdateData(planeId);
			UpdateSlider();
		}

		private void UpdateData(int planeId) {
            for (ItemKey i = 0; i < ItemKey.grouth; i++)
            {
				string prefabName = ConvertName(i);
				Transform trans = transform.Find(prefabName);
				if (trans == null)
				{
					Debug.LogError(GetType() + "/()/Did not find the Prefab, name = " + prefabName);
				}
				else {
					string key = KeysUtil.GetPropertyKeys(planeId,mKey+i);

					trans.GetComponent<Text>().text = DataMgr.Instance.GetObject(key).ToString() ;

					//Debug.Log(GetType()+ "/UpdateData()/ key = " + key);
					//Debug.Log(GetType()+ "/UpdateData()/ keyValue = " + DataMgr.Instance.Get<string>(key));
				}
            }
		}

		private void UpdateSlider() {
			Slider slider = transform.Find("Slider").GetComponent<Slider>();
			slider.minValue = 0;
			slider.maxValue = DataMgr.Instance.Get<int>(KeysUtil.GetNewKey(ItemKey.maxVaue,mKey));
			slider.value = DataMgr.Instance.Get<int>(KeysUtil.GetNewKey(ItemKey.value, mKey));
		}

		private string ConvertName(ItemKey key) {
			string first = key.ToString().Substring(0,1).ToUpper();
			string other = key.ToString().Substring(1);
			return first + other;
		}

        public void UpdateFunc()
        {
			UpdatePlaneId(GameStateModel.Instance.SelectedPlaneID);
        }

        public void Show()
        {
			int id = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
			UpdatePlaneId(id);
		}
    }
}
