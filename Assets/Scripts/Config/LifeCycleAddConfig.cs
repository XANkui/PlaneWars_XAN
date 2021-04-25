/****************************************************
文件：LifeCycleAddConfig.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/22 12:21:14
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LifeCycleAddConfig : IInit
	{
        public ArrayList _objects { get; private set; }
        public void Init()
        {
            _objects = new ArrayList();
            Add();
        }

        private void Add()
        {

            _objects.Add(ConfigMgr.Instance);
            _objects.Add(new InitCustomAttributes());
            _objects.Add(PlaneSpriteModel.Instance);
        }
    }
}
