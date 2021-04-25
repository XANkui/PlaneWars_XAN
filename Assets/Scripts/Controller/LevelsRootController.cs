/****************************************************
文件：LevelsRootController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 12:23:50
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LevelsRootController : ControllerBase
	{
        protected override void InitChild()
        {
            var reader = ReadMgr.Instance.GetReader(Paths.CONFIG_LEVEL_CONFIG);
            reader["levelCount"].Get<int>((data) => {
                CoruotineMgr.Instance.ExecuteOnce(Wait(data));
            });

        }

        private IEnumerator Wait(int count) {
            yield return new WaitUntil(()=> transform.childCount >= count);
            AddComponent();
            Reacquire();
        }

        private void AddComponent()
        {
            foreach  (Transform trans in transform)
            {
                trans.gameObject.AddComponent<LevelItemController>();
            }
        }
    }
}
