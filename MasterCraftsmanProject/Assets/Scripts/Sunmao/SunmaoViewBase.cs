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
using DG.Tweening;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class SunmaoViewBase : MonoBehaviour
    {
        [Header("CanvasGroup")]
        public CanvasGroup canvasGroup;
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
        [Header("关闭按钮")]
        public Button closeBtn;

        private bool isCombine = true;//是否为合并状态

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
            closeBtn.AddButtonClickEvent(OnClose);

            OpenAnim();
        }

        protected void OpenAnim()
        {
            transform.localScale = Vector3.zero;
            canvasGroup.DisplayCanvasGroup(true);
            transform.DOScale(1, 0.5f);
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

        protected void OnClose()
        {
            MenuView.Instance.OnChangeView(true);
            canvasGroup.DisplayCanvasGroup(false);
            transform.DOScale(0, 0.5f).OnComplete(() => { Destroy(gameObject); });
        }
    }
}