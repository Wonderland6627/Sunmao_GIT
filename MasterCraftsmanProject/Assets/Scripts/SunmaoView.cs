/**
*	Author: Wonderland6627
*	Date: 2020-05-13 17:32:44
*	Version: 0.0
*	Description: 每一个榫卯展示用
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
        [Header("榫卯名字")]
        public Text sunmaoNameText;
        [Header("拆解按钮")]
        public Button explodeBtn;
        [Header("合并按钮")]
        public Button combineBtn;

        private void Start()
        {
            OnInit();
        }

        public void OnInit(object param = null)
        {
            if(modelDisplay)
            {
                modelDisplay.OnInit();
            }

            explodeBtn.AddButtonClickEvent(ExplodeModel);
            combineBtn.AddButtonClickEvent(CombineModel);
        }

        protected void ExplodeModel()
        {
            if (modelAnim)
            {
                modelAnim.SetTrigger("Open");
            }
        }

        protected void CombineModel()
        {
            if (modelAnim)
            {
                modelAnim.SetTrigger("Close");
            }
        }
    }
}