/****************************************************
文件：SelectHeroController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 11:27:51
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class SelectHeroController : ControllerBase
	{

        private HeroItemController[] mItems;
        protected override void InitChild()
        {
            mItems = new HeroItemController[transform.childCount];
            HeroItemController item = null;
            int index = 0;
            foreach (Transform trans in transform)
            {
                item = trans.gameObject.AddComponent<HeroItemController>();
                mItems[index] = item;
                index++;
            }
        }
    }
}
