/****************************************************
文件：TaskQueueMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 15:58:20
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class TaskQueueMgr<T> : NormalSingleton<TaskQueueMgr<T>>
	{
		private TaskQueue<T> mQueue;

		public TaskQueueMgr() {
			mQueue = new TaskQueue<T>();
		}

		public void AddQueue(Func<IReader> getReader) {
			mQueue.Add((self,id)=> { getReader().Get<T>((data) => self.AddValue(id, data)); });
		}

		public void Execute(Action<T[]> onComplete) {
			mQueue.Execute(onComplete);
		}
	}

	public class TaskQueueMgr: NormalSingleton<TaskQueueMgr>
	{
		private TaskQueue mQueue;

		public TaskQueueMgr()
		{
			mQueue = new TaskQueue();
		}

		public void AddQueue<T>(Func<IReader> getReader)
		{
			mQueue.Add((self, id) => { getReader().Get<T>((data) => self.AddValue(id, data)); });
		}

		public void Execute(Action<object[]> onComplete)
		{
			mQueue.Execute(onComplete);
		}
	}
}
