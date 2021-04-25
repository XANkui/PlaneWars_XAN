/****************************************************
文件：LaunchGame.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 14:42:00
功能：程序入口
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LaunchGame : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			//DataMgr.Instance.ClearAll();  // 数据修改的时候，作为清空重新加载使用

			GameStateModel.Instance.CurrentScene = SceneName.Main;
			IInit lifeCycle = LifeCycleMgr.Instance;
			lifeCycle.Init();

			AudioMgr.Instance.Init();

			UIMgr.Instance.Show(Paths.START_VIEW);
		}

		
	}
}
