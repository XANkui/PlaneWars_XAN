/****************************************************
文件：Paths.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 21:36:35
功能：路径管理
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class Paths 
	{
		public const string PREFAB_DOLFER = "Prefab/";
		public const string START_VIEW = PREFAB_DOLFER+"StartView";
		public const string SELECTED_HERO_VIEW = PREFAB_DOLFER + "SelectedHeroView";
		public const string PREFAB_STRENGTHEN_VIEW = PREFAB_DOLFER + "StrengthenView";
		public const string PROPERTY_ITEM = PREFAB_DOLFER + "PropertyItem";
		public const string DIALOG_VIEW = PREFAB_DOLFER + "Dialog";
		public const string LEVELS_VIEW = PREFAB_DOLFER + "LevelsView";
		public const string LEVEL_ITEM = PREFAB_DOLFER + "LevelItem";
		public const string LOADING_VIEW = PREFAB_DOLFER + "LoadingView";
		
		public const string PLAYER_PICTURE_FOLDER = "Picture/Player";

		public static readonly string CONFIG_FOLDER = Application.streamingAssetsPath + "/Config";
		public static readonly string CONFIG_INIT_PLANE_CONFIG = CONFIG_FOLDER + "/InitPlane.json";
		public static readonly string CONFIG_LEVEL_CONFIG = CONFIG_FOLDER + "/LevelConfig.json";
		public static readonly string CONFIG_AUDIO_VOULME_CONFIG = CONFIG_FOLDER + "/AudioVolume.json";


		//音频路径
		public static readonly string AUDIO_FOLDER = "Audio";
		public static readonly string AUDIO_UI_FOLDER = AUDIO_FOLDER + "/UI/";
		public static readonly string AUDIO_Player_FOLDER = AUDIO_FOLDER + "/Player/";
		public static readonly string AUDIO_GAME_BG = AUDIO_FOLDER + "/Game_BG";
		public static readonly string AUDIO_CLICK_BUTTON = AUDIO_Player_FOLDER + "/UI_ClickButton";
		public static readonly string AUDIO_LOADING = AUDIO_Player_FOLDER + "/UI_Loading";
		public static readonly string AUDIO_START_GAME = AUDIO_Player_FOLDER + "/UI_StartGame";
	}
}
