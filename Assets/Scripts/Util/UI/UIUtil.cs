/****************************************************
文件：UIUtil.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/19 17:40:23
功能：UI 工具类
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneWars_XAN { 

	public class UIUtil : MonoBehaviour
	{
        private Dictionary<string, UiUtilData> mDatas;
        public void Init()
        {
            mDatas = new Dictionary<string, UiUtilData>();
            RectTransform rect = transform.GetComponent<RectTransform>();

            foreach (RectTransform rectTransform in rect)
            {
                mDatas.Add(rectTransform.name, new UiUtilData(rectTransform)) ;
            }
        }

        public UiUtilData Get(string name) {
            if (mDatas.ContainsKey(name))
            {
                return mDatas[name];
            }
            else {
                Transform temp = transform.Find(name);
                if (temp == null)
                {
                    Debug.LogError(GetType() + "/Get()/ Have not found: " + name);
                    return null;
                }
                else {
                    mDatas.Add(name, new UiUtilData(temp.GetComponent<RectTransform>()));

                    return mDatas[name];
                }
            }
        }
    }



    public class UiUtilData { 
        public GameObject Go { get; private set; }
        public RectTransform RectTrans { get; private set; }
        public Image Img { get; private set; }
        public Text Txt { get; private set; }

        public UiUtilData(RectTransform rectTrans) {

            RectTrans = rectTrans;
            Go = rectTrans.gameObject;
            Img = rectTrans.GetComponent<Image>() ;
            Txt = rectTrans.GetComponent<Text>() ;
        }

      

        public void SetSprite(Sprite sprite)
        {
            if (Img != null)
            {
                Img.sprite = sprite; ;
            }
            else
            {

                Debug.LogError(GetType() + "/SetSprite()/ " + Go.name + " has no Image ");
            }
        }

        public void SetText(int content) {
            SetText(content.ToString());
        }

        public void SetText(float content)
        {
            SetText(content.ToString());
        }

        public void SetText(string content)
        {
            if (Txt != null)
            {
                Txt.text = content; ;
            }
            else
            {

                Debug.LogError(GetType() + "/SetText()/ " + Go.name + " has no Text ");
            }
        }

        public T Get<T>() where T : Component {
            if (Go == null)
            {
                Debug.LogError(GetType()+ "/Get()/ current gameObject is null:" + Go.name);
                return null;
            }

            return Go.GetComponent<T>();
            
        }

        public void Add<T>() where T : Component
        {
            if (Go == null)
            {
                Debug.LogError(GetType() + "/Add()/ current gameObject is null :" + Go.name);
                return;
            }

            Go.AddComponent<T>();

        }
    }
}
