/****************************************************
文件：DialogVIew.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 08:36:18
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PlaneWars_XAN {

	[BindPrefabPath(Paths.DIALOG_VIEW, Const.BIND_PREFAB_PRIORITY_VIEW)]
	public class DialogVIew : MonoBehaviour, IView
	{
		string mOnePath = "Frame/Buttons/One";
		string mTwoPath = "Frame/Buttons/Two";
		string mYesBtn = "Yes";
		string mNoBtn = "No";

		private UIUtil mUIUtil;

		private float mUpAndDown = 40;
		private float mLeftAndRight = 40;
		private float mOffset = 40;
		private float mMaxWidth = 550;
		private float mMinWidth = 330;


		public void InitDialog(string content, Action trueAction = null, Action falseAction = null)
		{
			if (mUIUtil == null)
			{
				mUIUtil = gameObject.AddComponent<UIUtil>();
				mUIUtil.Init();
			}

			UpdataContent(content);
			AddAction(trueAction, falseAction);

			CoruotineMgr.Instance.ExecuteOnce(ChangeSize());
		}

		IEnumerator ChangeSize()
		{
			yield return null;

			var content = mUIUtil.Get("Frame/Content").RectTrans;
			var buttons = mUIUtil.Get("Frame/Buttons").RectTrans;
			var frame = mUIUtil.Get("Frame").RectTrans;
			SetWeight(content, frame);
			yield return null;
			SetHeight(content, buttons, frame);
		}

		private void SetHeight(RectTransform content, RectTransform buttons, RectTransform frame)
		{
			SetContentY(content);
			SetButtonsY(content, buttons);
			SetFrameHeight(content, buttons, frame);
		}

		private void SetWeight(RectTransform content, RectTransform frame)
		{
			float weight = mLeftAndRight * 2 + content.rect.width;

			float result = 0;
			if (weight <= mMinWidth)
			{
				result = mMinWidth;
				//GetComponent<LayoutElement>().preferredWidth = -1;
			}
			else if (weight > mMaxWidth)
			{
				result = mMaxWidth + mLeftAndRight * 2;
				content.GetComponent<LayoutElement>().preferredWidth = mMaxWidth;
			}
			else
			{
				result = weight;
			}

			frame.sizeDelta = new Vector2(result, frame.sizeDelta.y);
		}

		private void SetContentY(RectTransform content)
		{
			float y = content.rect.height * 0.5f + mUpAndDown;
			SetPosY(content, y);
		}

		private void SetButtonsY(RectTransform content, RectTransform buttons)
		{
			float offset = content.rect.height + mOffset + mUpAndDown;
			float y = offset + buttons.rect.height * 0.5f;
			SetPosY(buttons, y);
		}

		private void SetFrameHeight(RectTransform content, RectTransform buttons, RectTransform frame)
		{
			float height = mUpAndDown * 2 + mOffset + content.rect.height + buttons.rect.height;
			var size = frame.sizeDelta;
			size.y = height;
			mUIUtil.Get("Frame").RectTrans.sizeDelta = size;
		}

		private void SetPosY(RectTransform rect, float y)
		{
			var pos = rect.anchoredPosition;
			pos.y = -y;
			rect.anchoredPosition = pos;
		}


		private void UpdataContent(string content)
		{
			transform.Find("Frame/Content").GetComponent<Text>().text = content;
		}

		private void AddAction(Action trueAction, Action falseAction)
		{
			if (trueAction == null && falseAction == null)
			{
				SetButtonState(true);
				AddOneListener(trueAction);

			}
			else if (trueAction == null && falseAction != null)
			{
				Debug.LogError(GetType() + "/AddAction()/if falseAction is not null,then trueAction is not null too, but trueAction is null");
				AddOneListener(trueAction);
			}

			else if (trueAction != null && falseAction == null)
			{
				SetButtonState(true);
				AddOneListener(trueAction);
			}
			else
			{
				SetButtonState(false);
				AddTwoListener(trueAction, falseAction);
			}
		}

		private void SetButtonState(bool isOne)
		{
			transform.Find(mOnePath).gameObject.SetActive(isOne);
			transform.Find(mTwoPath).gameObject.SetActive(!isOne);
		}

		private void AddOneListener(Action trueAction)
		{
			if (trueAction == null)
			{
				transform.ButtonAction(mOnePath + "/" + mYesBtn, UIMgr.Instance.Back);
			}
			else
			{
				transform.ButtonAction(mOnePath + "/" + mYesBtn, trueAction);
			}
		}

		private void AddTwoListener(Action trueAction, Action falseAction)
		{
			transform.ButtonAction(mTwoPath + "/" + mYesBtn, trueAction);
			transform.ButtonAction(mTwoPath + "/" + mNoBtn, falseAction);
		}

		public Transform GetTrans()
		{
			return transform;
		}

		public void Init()
		{
			return;
		}

		public void Hide()
		{
			Destroy(this.gameObject);
		}

		public void Show()
		{
			return;
		}

		public void UpdateFunc()
		{
			return;
		}

        public void Reacquire()
        {
            throw new NotImplementedException();
        }
    }
}
