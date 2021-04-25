/****************************************************
文件：DataKeys.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 18:13:12
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class DataKeys 
	{
		public const string LIFE = "Life";
		public const string ATTACK = "Attack";
		public const string FIRE_RATE = "FireRate";
		public const string STAR = "star";
		public const string DIAMOND = "diamond";
		public const string PLANE_ID = "PlaneId";
		public const string LEVEL = "Level";

		public const string UPGRADES = "upgrades";
		public const string UPGRADES_RATIO = UPGRADES +"coefficient";
		public const string LEVEL_MAX = UPGRADES+"max";

		/// <summary>
		/// 表示当前项的名称
		/// </summary>
		public const string NAME = "name";

		/// <summary>
		/// 花费的单位 是星星还是钻石
		/// </summary>
		public const string COST_UNIT = "costUnit";


		public const string LEVEL_PASSED = "levelPassed";


		public const string AUDIO_NAME = "Name";
		public const string AUDIO_Volume = "Volume";
	}
}
