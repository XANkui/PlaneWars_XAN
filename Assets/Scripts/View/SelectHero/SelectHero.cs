/****************************************************
文件：SelectHero.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 22:19:03
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class SelectHero : ViewBase
	{

        protected override void InitChild()
        {
			foreach (Transform trans in transform)
			{
				trans.gameObject.AddComponent<HeroItem>();
			}
		}
    }
}
