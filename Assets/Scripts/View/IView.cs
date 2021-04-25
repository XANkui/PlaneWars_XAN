/****************************************************
文件：IView.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 17:29:09
功能：View 接口
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public interface IView :IViewInit,IViewHide,IViewShow, IViewUpdate
	{
		Transform GetTrans();
		void Reacquire();
	}
}
