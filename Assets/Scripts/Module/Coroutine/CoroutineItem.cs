/****************************************************
文件：CoroutineItem.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/20 16:12:13
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class CoroutineItem
	{
		public enum CoroutineState { 
			WAITTING,
			RUNNING,
			PAUSED,
			STOP
		}

		public CoroutineState State { get; set; }

		public IEnumerator Body(IEnumerator routine) {
            while (State == CoroutineState.WAITTING)
            {
				yield return null;
            }

			while (State == CoroutineState.RUNNING)
			{
				if (State == CoroutineState.PAUSED)
				{
					yield return null;

				}
				else {
					if (routine != null && routine.MoveNext())
					{
						yield return routine.Current;
					}
					else {
						State = CoroutineState.STOP;
					}
				}


			}
		}
	}
}
