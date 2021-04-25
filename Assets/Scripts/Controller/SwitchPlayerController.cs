using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class SwitchPlayerController : ControllerBase
	{
        private int mId;
        protected override void InitChild()
        {
            GameStateModel.Instance.SelectedPlaneID = DataMgr.Instance.Get<int>(DataKeys.PLANE_ID);
            mId = GameStateModel.Instance.SelectedPlaneID;
            transform.ButtonAction("Left",() => Switch(ref mId, -1));
            transform.ButtonAction("Right",() => Switch(ref mId, 1));


        }

        private void Switch(ref int id, int direction)
        {
            UpdateId(ref id, direction);

        }

        private void UpdateId(ref int id, int direction)
        {
            int min = 0;
            int max = PlaneSpriteModel.Instance.Count;
            id += direction;
            id = id < 0 ? 0 : (id >= max ? max - 1 : id);

            GameStateModel.Instance.SelectedPlaneID = id;
        }
    }
}
