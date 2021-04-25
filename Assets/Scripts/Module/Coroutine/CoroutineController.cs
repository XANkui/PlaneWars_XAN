/****************************************************
文件：CoroutineController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 16:12:01
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class CoroutineController
	{
		private static int mId = 0;
		public int ID { get; private set; }
		private MonoBehaviour mMono;
		private IEnumerator mRoutine;
		private CoroutineItem mItem;
		private Coroutine mCurCoroutine;

		public CoroutineController(MonoBehaviour mono, IEnumerator routine) {
			mItem = new CoroutineItem();
			mMono = mono;
			mRoutine = routine;
			ResetData();
		}

		public void Start() {
			mItem.State = CoroutineItem.CoroutineState.RUNNING;
			mCurCoroutine = mMono.StartCoroutine(mItem.Body(mRoutine));
		}

		public void Pause() {
			mItem.State = CoroutineItem.CoroutineState.PAUSED;
		}

		public void Stop()
		{
			mItem.State = CoroutineItem.CoroutineState.STOP;
		}

		public void Continue()
		{
			mItem.State = CoroutineItem.CoroutineState.RUNNING;
		}

		public void Restart() {
			if (mCurCoroutine != null)
            {
				mMono.StopCoroutine(mCurCoroutine);
            }

			Start();
		}

		private void ResetData() {
			ID = mId++;
		}
	}
}
