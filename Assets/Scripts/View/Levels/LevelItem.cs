/****************************************************
文件：LevelItem.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/23 16:35:55
功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class LevelItem : ViewBase
	{

        private int mLeftOffset = 15;
        private int mLineSpaceing = 5;


        protected override void InitChild()
        {
            int id = transform.GetSiblingIndex();
            SetLevelTextId(id);
            SetMaskState(JudgeOpenState(id));
            InitPos(id);
        }

        public void InitPos(int id )
        {
            
            var reader = ReadMgr.Instance.GetReader(Paths.CONFIG_LEVEL_CONFIG);

            reader["eachRow"].Get<int>((data)=> {
                var grid = GetGrid(data,id);
                SetPos(grid);
            });
           
        }

        private bool JudgeOpenState(int id)
        {
            int passed = -1;
            if (DataMgr.Instance.Contains(DataKeys.LEVEL_PASSED))
            {
                passed = DataMgr.Instance.Get<int>(DataKeys.LEVEL_PASSED);
            }

            return id <= passed + 1;
        }

        private void SetMaskState(bool isOpen)
        {
            UIUtil.Get("Mask").Go.SetActive(!isOpen) ;
        }

        private void SetLevelTextId(int id) {
            UIUtil.Get("Enter/Text").SetText(id + 1) ;
        }

        

        private Vector2 GetGrid(int eachRow,int id) {
            int y = id / eachRow;
            int x = id % eachRow;

            return new Vector2(x,y);
        }

        private void SetPos(Vector2 gridID) {
            float width = transform.Rect().rect.width * transform.localScale.x;
            float height = transform.Rect().rect.height * transform.localScale.y;

            int indention = gridID.y % 2 == 0 ? mLeftOffset : 0;

            float x = indention + width * 0.5f + (mLeftOffset + width) * gridID.x;
            float y = height * 0.5f + (mLineSpaceing + height) * gridID.y;
            transform.Rect().anchoredPosition = new Vector2(x, -y);
        }
    }
}
