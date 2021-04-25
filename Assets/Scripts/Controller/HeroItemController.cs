/****************************************************
文件：HeroItemController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 11:33:36
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public class HeroItemController : ControllerBase
	{
        private Hero mHero;
        protected override void InitChild()
        {
			GetComponent<Button>().onClick.AddListener(Selected);
            string hereoName = transform.GetComponent<Image>().sprite.name;

            try
            {
                mHero = (Hero)Enum.Parse(typeof(Hero),hereoName);
            }
            catch (Exception e)
            {
                Debug.Log(GetType()+ "/InitChild()/" + e);
            }
		}

        private void Selected()
        {
            GameStateModel.Instance.HeroID = mHero;
            AudioMgr.Instance.Play(mHero.ToString());
        }

        public override void UpdateFunc()
        {
            base.UpdateFunc();
            if (mHero != GameStateModel.Instance.HeroID)
            {
                AudioMgr.Instance.Stop(mHero.ToString());
            }
        }
    }
}
