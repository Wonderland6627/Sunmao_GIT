/**
*	Author: Wonderland6627
*	Date: 2020-05-13 17:32:44
*	Version: 0.0
*	Description: 每一个榫卯展示用，就是具体展示的那个窗口
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class SunmaoView : MonoBehaviour
    {
        [Header("模型展示")]
        public ModelDisplay modelDisplay;
        [Header("模型动画")]
        public Animator modelAnim;
        [Header("AnimEvent")]
        public AnimEvent animEvent;
        [Header("榫卯名字")]
        public Text sunmaoNameText;
        [Header("拆解按钮")]
        public Button explodeBtn;
        [Header("合并按钮")]
        public Button combineBtn;

        private bool isCombine = true;//是否为合并状态

        private void Start()
        {
            OnInit();
        }

        public void OnInit(object param = null)
        {
            if (modelDisplay)
            {
                modelDisplay.OnInit();
            }

            if (animEvent)
            {
                animEvent.isMute = false;
            }

            explodeBtn.AddButtonClickEvent(ExplodeModel);
            combineBtn.AddButtonClickEvent(CombineModel);
        }

        protected void ExplodeModel()
        {
            if (modelAnim && isCombine)
            {
                if (animEvent)
                {
                    animEvent.isMute = true;
                }
                modelAnim.SetTrigger("Explode");
                isCombine = false;
            }
        }

        protected void CombineModel()
        {
            if (modelAnim && !isCombine)
            {
                if (animEvent)
                {
                    animEvent.isMute = false;
                }
                modelAnim.SetTrigger("Combine");
                isCombine = true;
            }
        }
    }
}