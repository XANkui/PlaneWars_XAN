/****************************************************
文件：LevelsRoot.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 12:22:59
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LevelsRoot : ViewBase
	{
        private enum Name {
            levelCount = 0,
            COUNT

        }

        protected override void InitChild()
        {
            var reader = ReadMgr.Instance.GetReader(Paths.CONFIG_LEVEL_CONFIG);

            for (Name i = 0; i < Name.COUNT; i++)
            {
                Name temp = i;
                TaskQueueMgr<int>.Instance.AddQueue(()=>reader[temp.ToString()]);
            }
            TaskQueueMgr<int>.Instance.Execute(SpawnLevelItem);
        }

        private void SpawnLevelItem(int[] values)
        {
            if (values.Length != (int)Name.COUNT)
            {
                Debug.LogError(GetType()+ "/SpawnLevelItem()/The number of data returned does not match. Correct number = "+(int)Name.COUNT+", Current number = "+values.Length);
                return;
            }

            int levelCount = values[(int)Name.levelCount];

            SpawnItem(levelCount);
        }

        private void SpawnItem(int levelCount )
        {
            GameObject go;
            for (int i = 0; i < levelCount; i++)
            {
                go = LoadMgr.Instance.LoadPrefab(Paths.LEVEL_ITEM,transform);
                go.AddComponent<LevelItem>();
            }

            Reacquire();
        }
    }
}
