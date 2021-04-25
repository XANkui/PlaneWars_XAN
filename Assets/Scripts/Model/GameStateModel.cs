/****************************************************
文件：GameStateModel.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 15:11:46
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class GameStateModel : NormalSingleton<GameStateModel>
	{
		public Hero HeroID;

		public int SelectedPlaneID;

		public SceneName CurrentScene { get; set; }
		public SceneName TargetScene { get; set; }

		public int Level {
			get {
				string key = KeysUtil.GetPropertyKeys(DataKeys.LEVEL);
				
				return DataMgr.Instance.Get<int>(key);
			}
		}

		public int GetMoney(string key) {
			int money = 0;
			switch (key)
			{
				case DataKeys.STAR:
					money = DataMgr.Instance.Get<int>(DataKeys.STAR);
					break;

				case DataKeys.DIAMOND:
					money = DataMgr.Instance.Get<int>(DataKeys.DIAMOND);
					break;
				default:
					Debug.LogError(GetType()+ "/Money()/ There is no the type of money: type = "+key);

					break;
			}

			return money;
		}

		public int SetMoney(string key,int money)
		{
			switch (key)
			{
				case DataKeys.STAR:
					DataMgr.Instance.Set(DataKeys.STAR,money);
					break;

				case DataKeys.DIAMOND:
					DataMgr.Instance.Set(DataKeys.DIAMOND, money);
					break;
				default:
					Debug.LogError(GetType() + "/Money()/ There is no the type of money: type = " + key);

					break;
			}

			return money;
		}
	}
}
