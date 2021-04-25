/****************************************************
文件：IController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/21 18:11:03
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public interface IController : IControllerInit,IControllerUpdate,IControllerHide,IControllerShow
	{
		void AddUpdateListener(Action action);
		void Reacquire();
	}
}
