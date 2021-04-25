/****************************************************
文件：CoruotineMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 16:05:23
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class CoruotineMgr : MonoSingleton<CoruotineMgr>
	{
		private Dictionary<int, CoroutineController> mControllersDict;
		public CoruotineMgr() {
			mControllersDict = new Dictionary<int, CoroutineController>();
		}

		public int Execute(IEnumerator routine, bool isAutoStart = true) {
			CoroutineController controller = new CoroutineController(this, routine);
			mControllersDict.Add(controller.ID, controller);

			if (isAutoStart==true)
            {
				StartExecute(controller.ID);
            }


			return controller.ID;
		}

		public void ExecuteOnce(IEnumerator routine) { 
			CoroutineController controller = new CoroutineController(this, routine);
			controller.Start(); 
		}

		public void Restart(int id)
		{
			var controller = GetController(id);
			if (controller != null)
			{
				controller.Restart();
			}
		}

		public void StartExecute(int id) {
			var controller = GetController(id);
            if (controller != null)
            {
				controller.Start();
            }
		}

		public void Pause(int id)
		{
			var controller = GetController(id);
			if (controller != null)
			{
				controller.Pause();
			}
		}

		public void Stop(int id)
		{
			var controller = GetController(id);
			if (controller != null)
			{
				controller.Stop();
			}
		}

		public void Continue(int id)
		{
			var controller = GetController(id);
			if (controller != null)
			{
				controller.Continue();
			}
		}

		private CoroutineController GetController(int id) {
			if (mControllersDict.ContainsKey(id))
			{
				return mControllersDict[id];
			}
			else {
				Debug.LogError(GetType()+"/()/ The id does not exist, id = "+id);
				return null;
			}
		}
	}
}
