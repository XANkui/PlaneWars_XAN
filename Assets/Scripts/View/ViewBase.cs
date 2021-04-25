/****************************************************
文件：ViewBase.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 17:34:24
功能：View 基类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public abstract class ViewBase : MonoBehaviour, IView
	{
        private UIUtil mUIUtil;
        private List<IViewUpdate> mViewUpdates;
        private List<IViewInit> mViewInits;
        private List<IViewShow> mViewShows;
        private List<IViewHide> mViewHides;
        protected UIUtil UIUtil {
            get {
                if (mUIUtil == null)
                {
                    mUIUtil = gameObject.AddComponent<UIUtil>();
                    mUIUtil.Init();
                }

                return mUIUtil;
            }
        }

        public virtual void Init()
        {
            InitChild();
            InitSubView();
            InitAllSubviews();

            InitViewUpdateObjects();

            
        }

        protected abstract void InitChild();

        private void InitSubView() {
            mViewInits = new List<IViewInit>();
            mViewShows = new List<IViewShow>();
            mViewHides = new List<IViewHide>();
            mViewUpdates = new List<IViewUpdate>();

            InitInterfaces();
        }

        private void InitViewInterface<T>(List<T> list) {
            T view;

            foreach (Transform trans in transform)
            {
                view = trans.GetComponent<T>();
                if (view != null)
                {
                    list.Add(view);
                }
            }
        }

        private void InitViewUpdateObjects() {
            mViewUpdates = transform.GetComponentsInChildren<IViewUpdate>().ToList() ;
            mViewUpdates.Remove(this);
        }

        private void InitAllSubviews() {
            foreach (var view in mViewInits)
            {
                view.Init();
            }
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);

            foreach (var view in mViewShows)
            {
                view.Show();
            }

            UpdateFunc();
        }

        public virtual void Hide()
        {
            foreach (var view in mViewHides)
            {
                view.Hide();
            }

            gameObject.SetActive(false);            
        }

 
        public virtual void UpdateFunc()
        {
            foreach (IViewUpdate item in mViewUpdates)
            {
                item.UpdateFunc();
            }
        }

        public Transform GetTrans()
        {
            return transform;
        }

        private void InitInterfaces() {
            InitViewInterface(mViewInits);
            InitViewInterface(mViewShows);
            InitViewInterface(mViewHides);
            InitViewInterface(mViewUpdates);
        }

        public void Reacquire()
        {
            InitInterfaces();
            InitAllSubviews();
        }
    }
}
