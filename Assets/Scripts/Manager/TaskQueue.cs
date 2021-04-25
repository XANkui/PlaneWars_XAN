/****************************************************
文件：TaskQueue.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 14:51:30
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN {

	public class TaskQueue
	{
		private Queue<Action<TaskQueue, int>> mTakes;

		private int mId = -1;

		private object[] mValues;

		private int mAddValueTimes = 0;
		private Action<object[]> mOnComplete;

		public TaskQueue() {
			mTakes = new Queue<Action<TaskQueue, int>>();
			ResetValue();
		}

		public void ResetValue() {
			mId = -1;
			mAddValueTimes = 0;
		}

		public void Add(Action<TaskQueue,int> task) {
			mTakes.Enqueue(task);
		}

		public void Execute(Action<object[]> onComplete) {
			mOnComplete = onComplete;
			mValues = new object[mTakes.Count];

			while (mTakes.Count > 0)
			{ 
				mId++;
				var task = mTakes.Dequeue();
				if (task != null)
				{
					task.Invoke(this, mId);
				}
			}

			ResetValue();
		}

		public void AddValue(int id, object value) {
			mAddValueTimes++;
			mValues[id] = value;
			JudgeComplete();
		}

        private void JudgeComplete()
        {
			if (mAddValueTimes == mValues.Length)
			{
				if (mOnComplete != null)
				{
					mOnComplete.Invoke(mValues);

				}
			}
			else if (mAddValueTimes > mValues.Length)
			{
				Debug.LogError(GetType()+ "/JudgeComplete()/mAddValueTimes greater than Actual number of additions");
			}
        }
    }

	public class TaskQueue<T>
	{
		private Queue<Action<TaskQueue<T>, int>> mTakes;

		private int mId = -1;

		private T[] mValues;

		private int mAddValueTimes = 0;
		private Action<T[]> mOnComplete;

		public TaskQueue()
		{
			mTakes = new Queue<Action<TaskQueue<T>, int>>();
			ResetValue();
		}

		public void ResetValue()
		{
			mId = -1;
			mAddValueTimes = 0;
		}

		public void Add(Action<TaskQueue<T>, int> task)
		{
			mTakes.Enqueue(task);
		}

		public void Execute(Action<T[]> onComplete)
		{
			mOnComplete = onComplete;
			mValues = new T[mTakes.Count];

			while (mTakes.Count > 0)
			{
				mId++;
				var task = mTakes.Dequeue();
				if (task != null)
				{
					task.Invoke(this, mId);
				}
			}

			ResetValue();
		}

		public void AddValue(int id, T value)
		{
			mAddValueTimes++;
			mValues[id] = value;
			JudgeComplete();
		}

		private void JudgeComplete()
		{
			if (mAddValueTimes == mValues.Length)
			{
				if (mOnComplete != null)
				{
					mOnComplete.Invoke(mValues);

				}
			}
			else if (mAddValueTimes > mValues.Length)
			{
				Debug.LogError(GetType() + "/JudgeComplete()/mAddValueTimes greater than Actual number of additions");
			}
		}
	}
}
