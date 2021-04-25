/****************************************************
文件：LoadingView.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/24 09:58:00
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

    [BindPrefabPath(Paths.LOADING_VIEW,Const.BIND_PREFAB_PRIORITY_VIEW)]
	public class LoadingView : ViewBase
	{
        private Slider mSLider;
        protected override void InitChild()
        {
            mSLider = UIUtil.Get("Slider").Get<Slider>();
        }

        public override void Show()
        {
            base.Show();
            LifeCycleMgr.Instance.Add(LifeName.UPDATE,this);


        }

        public override void Hide()
        {
            base.Hide();
            LifeCycleMgr.Instance.Remove(LifeName.UPDATE, this);
        }

        public override void UpdateFunc()
        {
            base.UpdateFunc();

            UpdateProgress();
            UpdateSlider();

            
        }

        private void UpdateProgress() {
            float progress = SceneMgr.Instance.Process;
            progress *= 100;
            UIUtil.Get("Progress").SetText(progress+"%") ;
        }

        private void UpdateSlider() {
            mSLider.value = SceneMgr.Instance.Process;
        }

        private void OnDestroy()
        {
            Hide();
        }
    }
}
