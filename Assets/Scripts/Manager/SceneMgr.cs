/****************************************************
文件：SceneMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/24 10:00:13
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlaneWars_XAN { 

	public class SceneMgr : NormalSingleton<SceneMgr>
	{
		private AsyncOperation mAsync;

		public float Process
		{
			get
			{
				if (mAsync == null)
				{
					return 0;
				}
				if (mAsync.progress >= 0.9f)
				{
					return 1;
				}

				return mAsync.progress;
			}
		}

		public void AsyncLoadScene(SceneName sceneName) {
			CoruotineMgr.Instance.ExecuteOnce(AsyncLoad(sceneName.ToString()));
			
		}

		private IEnumerator AsyncLoad(string name) {
			mAsync = SceneManager.LoadSceneAsync(name);
			mAsync.allowSceneActivation = false;

			yield return mAsync;
		}

		public void SceneActivation() {
            if (mAsync == null)
            {
				return;
            }

			mAsync.allowSceneActivation = true;
			mAsync = null;
		}
	}
}
