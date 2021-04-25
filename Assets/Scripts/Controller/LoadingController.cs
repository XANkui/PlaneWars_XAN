/****************************************************
文件：LoadingController.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/24 10:14:47
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN {

    [BindPrefabPath(Paths.LOADING_VIEW, Const.BIND_PREFAB_PRIORITY_CONTROLLER)]
    public class LoadingController : ControllerBase
	{
        protected override void InitChild()
        {
        }

        public override void UpdateFunc()
        {
            base.UpdateFunc();
            if (SceneMgr.Instance.Process == 1)
            {
                SceneMgr.Instance.SceneActivation();
            }
        }

        public override void Show()
        {
            base.Show();
            if (GameStateModel.Instance.TargetScene != GameStateModel.Instance.CurrentScene
                && GameStateModel.Instance.TargetScene != SceneName.NULL)
            {
                SceneMgr.Instance.AsyncLoadScene(GameStateModel.Instance.TargetScene);
                LifeCycleMgr.Instance.Add(LifeName.UPDATE,this);
            }

        }

        public override void Hide()
        {
            base.Hide();

            if (GameStateModel.Instance.TargetScene != SceneName.NULL)
            {
                GameStateModel.Instance.CurrentScene = GameStateModel.Instance.TargetScene;
                GameStateModel.Instance.TargetScene = SceneName.NULL;
                
            }
            LifeCycleMgr.Instance.Remove(LifeName.UPDATE, this);
        }

        private void OnDestroy()
        {
            Hide();
        }
    }
}
