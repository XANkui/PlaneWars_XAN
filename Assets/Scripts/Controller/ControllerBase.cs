/****************************************************
文件：ControllerBase.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 21:29:03
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public abstract class ControllerBase : MonoBehaviour,IController
	{
        private List<IControllerUpdate> mUpdates;
        private List<IControllerInit> mInits;
        private List<IControllerShow> mShows;
        private List<IControllerHide> mHides;
        private Action mOnUpdataAction;

        public virtual void Init()
        {
            InitChild();            

            InitAllComponents();

            InitComponents();

            AddUpdateAction();
        }

        protected abstract void InitChild();

        private void AddUpdateAction()
        {
            foreach (Button btn in GetComponentsInChildren<Button>())
            {
                btn.onClick.AddListener(()=> {
                    if (mOnUpdataAction!= null)
                    {
                        mOnUpdataAction();

                    }

                    UpdateFunc();
                }
                );
            }
        }

        public void Reacquire() {
            initInterface();
            InitComponents();
        }

        private void initInterface() {
            InitComponent(mInits, this);
            InitComponent(mUpdates, this);
            InitComponent(mShows, this);
            InitComponent(mHides, this);
        }


        private void InitAllComponents() {

            mInits = new List<IControllerInit>();
            mUpdates = new List<IControllerUpdate>();
            mShows = new List<IControllerShow>();
            mHides = new List<IControllerHide>();

            initInterface();
        }

        private void InitComponent<T>(List<T> list, T removeObject) {
            var temp = transform.GetComponentsInChildren<T>();

            list.AddRange(temp);
            list.Remove(removeObject);
        }

        private void InitComponents() {
            foreach (var component in mInits)
            {
                component.Init();
            }
        }

        public virtual void UpdateFunc()
        {
            foreach (var component in mUpdates)
            {
                component.UpdateFunc();
            }
        }

        public virtual void Hide()
        {
            foreach (var component in mHides)
            {
                component.Hide();
            }
        }

        public virtual void Show()
        {
            foreach (var component in mShows)
            {
                component.Show();
            }
        }

        public void AddUpdateListener(Action action)
        {
            mOnUpdataAction += action;
        }
    }
}
