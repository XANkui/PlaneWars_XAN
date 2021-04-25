/****************************************************
文件：HeroItem.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 22:19:13
功能：Nothing
*****************************************************/

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public class HeroItem : ViewBase
	{
		private Color mDefaultColor = Color.gray;
		private Color mSelectedColor = Color.white;
		private float mTime = 0.5f;
		private Image mImage;

		private Hero mHero;

		protected override void InitChild()
		{
			mImage = transform.GetComponent<Image>();

			string hereoName = mImage.sprite.name;

			try
			{
				mHero = (Hero)Enum.Parse(typeof(Hero), hereoName);
			}
			catch (Exception e)
			{
				Debug.Log(GetType() + "/InitChild()/" + e);
			}
			Unselected();
		}

        public override void UpdateFunc()
        {
			bool isSelected = mHero == GameStateModel.Instance.HeroID;

			if (isSelected)
			{
				Selected();
			}
			else {
				Unselected();
			}
        }

        private void Selected()
        {
			mImage.DOKill();
			mImage.DOColor(mSelectedColor,mTime);
        }

		public void Unselected()
		{
			mImage.DOKill();
			mImage.DOColor(mDefaultColor, mTime);
		}
 
    }
}
