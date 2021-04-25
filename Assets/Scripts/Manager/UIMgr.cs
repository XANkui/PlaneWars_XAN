/****************************************************
文件：UIMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 17:29:52
功能：UI 管理类
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class UIMgr : NormalSingleton<UIMgr>
	{
		private Stack<string> mUiStack = new Stack<string>();
		private Dictionary<string, IView> mViewsDIct = new Dictionary<string, IView>();

		private Canvas mCanvas;

		private IView mDialog;

		public Canvas canvas {
			get {
                if (mCanvas ==null)
                {
					mCanvas = GameObject.FindObjectOfType<Canvas>();
                }

				if (mCanvas == null) {
					Debug.LogError(GetType()+ "/canvas()/ there is no canvas in current scene");
				}

				return mCanvas;
			}
		}

		public IView Show(string path) {
            if (mUiStack.Count>0)
            {
				string name = mUiStack.Peek();
				mViewsDIct[name].Hide();
			}

			IView view = InitView(path);

			ShowAll(view);

			mUiStack.Push(path);
			mViewsDIct[path] = view;

			return view;
		}

		public DialogVIew ShowDialog(string content, Action trueAction =null, Action falseAction = null) {
			var dialogGO = LoadMgr.Instance.LoadPrefab(Paths.DIALOG_VIEW,canvas.transform);
			AddTypeComponent(dialogGO, Paths.DIALOG_VIEW);

			DialogVIew dialog = dialogGO.GetComponent<DialogVIew>();
			if (dialog != null)
			{
				dialog.InitDialog(content, trueAction, falseAction);
			}
			else {
				Debug.LogError(GetType()+ "/ShowDialog ()/ dialog is null");
			}
			mDialog = dialog;
			return dialog;
		}

		private IView InitView(string path) {
			if (mViewsDIct.ContainsKey(path))
			{
				return mViewsDIct[path];
			}
			else {
				GameObject viewGo = LoadMgr.Instance.LoadPrefab(path, canvas.transform);

				AddTypeComponent(viewGo, path);

				AddUpdateListener(viewGo);

				InitComponent(viewGo);

				IView view = viewGo.GetComponent<IView>();
                if (view == null)
                {
					Debug.LogError(GetType()+ "/InitView()/ GetComponent<IView>() is null ");
                }

				return view;
			}
		}

		private void AddTypeComponent(GameObject viewGo, string path) {
			foreach (var type in BindUtil.GetType(path))
			{
				viewGo.AddComponent(type);


			}
		}

		private void AddUpdateListener(GameObject viewGo) {
			var controller = viewGo.GetComponent<IController>();
            if (controller == null)
            {
				Debug.LogWarning(GetType()+ "/AddUpdateListener()/ There is No IController component ");
				return;
            }

            foreach (IUpdate update in viewGo.GetComponents<IUpdate>())
            {
				controller.AddUpdateListener(update.UpdateFunc);
            }
		}

		private void InitComponent(GameObject viewGo) {
			IInit[] inits = viewGo.GetComponents<IInit>();
			foreach (var init in inits)
			{
				init.Init();
			}
		}

		public void Back() {


            if (mUiStack.Count<=1)
            {
				return;
            }
			if (mDialog == null)
			{
				string name = mUiStack.Pop();
				HideAll(mViewsDIct[name]);

				name = mUiStack.Peek();
				ShowAll(mViewsDIct[name]);
			}
			else {
				mDialog.Hide();
				mDialog = null;
				mViewsDIct[mUiStack.Peek()].Show();
			}
			
		}

		private void ShowAll(IView view) {
			if (view != null)
			{
				foreach (IShow show in view.GetTrans().GetComponents<IShow>())
				{
					show.Show();

				}
			}
			else {
				Debug.LogError(GetType() + "/ShowAll()/ view is null ");
			}
			
		}

		private void HideAll(IView view)
		{
			foreach (IHide hide in view.GetTrans().GetComponents<IHide>())
			{
				hide.Hide();

			}
		}
	}
}
