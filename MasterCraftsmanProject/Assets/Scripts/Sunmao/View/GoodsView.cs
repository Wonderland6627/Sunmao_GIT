/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-23 16:37:32
*	Description: 物品展示
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class GoodsView : CraftsViewBase
    {
        [Header("模型展示")]
        public ModelDisplay modelDisplay;
        [Header("模型动画")]
        public Animator modelAnim;
        [Header("AnimEvent")]
        public AnimEvent animEvent;
        [Header("物品名字")]
        public Text goodsNameText;
        [Header("拆解按钮")]
        public Button explodeBtn;
        [Header("合并按钮")]
        public Button combineBtn;

        private bool isCombine = true;//是否为合并状态
        private const string goodsPath = "Prefabs/SunmaoPrefabs/";

        public override void OnInit(object param = null)
        {
            base.OnInit(param);

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
            closeBtn.AddButtonClickEvent(OnClose);

            base.OnOpen();
        }

        public void ExplodeModel()
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

        public void CombineModel()
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