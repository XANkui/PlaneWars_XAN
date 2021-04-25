/****************************************************
文件：LifeCycleConfig.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/22 12:18:47
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LifeCycleConfig 
	{
		public static Dictionary<LifeName, ILifeCycle> Lifecycles = new Dictionary<LifeName, ILifeCycle>() {

			{LifeName.INIT, new LifeCycle<IInit>()},
			{LifeName.UPDATE, new LifeCycle<IUpdate>()}
		};

		public static Dictionary<LifeName, Action> LifecycleFuncs = new Dictionary<LifeName, Action>() {

			{LifeName.INIT, ()=>Lifecycles[LifeName.INIT].Execute((IInit o)=> o.Init())},
			{LifeName.UPDATE, ()=>Lifecycles[LifeName.UPDATE].Execute((IUpdate o)=> o.UpdateFunc())}
		};
	}

	public enum LifeName
	{
		INIT,
		UPDATE
	}
}
