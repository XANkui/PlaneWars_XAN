/****************************************************
文件：Enums.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 11:49:29
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN {

	public enum Hero { 
		player_0,
		player_1,
		player_2
	}

	public enum SceneName { 
		NULL,
		Main,
		Game
	}

	public enum BGAudio {
		Game_BG
	}

	public enum UIAudio { 
		ClickButton,
		Loading,
		StartGame
	}

}
