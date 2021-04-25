using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class PlaneSpriteModel : NormalSingleton<PlaneSpriteModel>,IInit
	{
		private Dictionary<int, List<Sprite>> mPlaneSpritesDict = new Dictionary<int, List<Sprite>>();

        public int Count {
            get {
                if (mPlaneSpritesDict==null)
                {
                    return 0;
                }

                return mPlaneSpritesDict.Count;
            }
        }

        public Sprite this[int id, int level] {
            get {
                return GetPlaneSprite(id, level);
            }
        }

        private void LoadSprite()
        {
            mPlaneSpritesDict = new Dictionary<int, List<Sprite>>();

            Sprite[] sprites = LoadMgr.Instance.LoadAll<Sprite>(Paths.PLAYER_PICTURE_FOLDER);

            foreach (Sprite sprite in sprites)
            {
                string[] idData = sprite.name.Split('_');
                int playerId = int.Parse(idData[0]);

                if (mPlaneSpritesDict.ContainsKey(playerId) == false)
                {
                    mPlaneSpritesDict[playerId] = new List<Sprite>();
                }
                mPlaneSpritesDict[playerId].Add(sprite);
            }
        }

        public void Init() {
            LoadSprite();
        }

        private Sprite GetPlaneSprite(int id, int level) {
            if (mPlaneSpritesDict.ContainsKey(id) ==false || level >= mPlaneSpritesDict[id].Count)
            {
                Debug.LogError(GetType() + "/GetPlaneSprite()/ id or level is error");
                return null;
            }

            return mPlaneSpritesDict[id][level];
        }
    }
}
