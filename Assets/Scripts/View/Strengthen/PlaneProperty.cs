/****************************************************
文件：PlaneProperty.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 23:05:30
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class PlaneProperty : ViewBase
	{
        public enum Property { 
            attack = 0,
            fireRate,
            life,
            COUNT
        }

        private List<PropertyItem> mItems;

        protected override void InitChild()
        {
            mItems = new List<PropertyItem>((int)Property.COUNT);

            for (Property i = 0; i < Property.COUNT; i++)
            {
                GameObject item =  LoadMgr.Instance.LoadPrefab(Paths.PROPERTY_ITEM, transform);
                PropertyItem itemS = item.AddComponent<PropertyItem>();
                itemS.Init(i.ToString());

                mItems.Add(itemS);
            }


        }

      
    }
}
