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
        [Header("介绍按钮")]
        public Button messageBtn;
        [Header("介绍按钮动画")]
        public Animator messageBtnAnim;
        [Header("榫卯介绍")]
        public Transform messageImgPos;
        [Header("拆解按钮")]
        public Button explodeBtn;
        [Header("合并按钮")]
        public Button combineBtn;
        [Header("关闭按钮")]
        public Button closeBtn;

        private bool isCombine = true;//是否为合并状态
        private bool isPull = false;//是否拉动绳子
        private const string sunmaoPath = "Prefabs/SunmaoPrefabs/";
        private const string messageImgPath = "Images/";

        public void OnInit(object param = null)
        {
            if (param != null)
            {
                string sunmaoName = param as string;
                if (!string.IsNullOrEmpty(sunmaoName))
                {
                    Sunmao sunmao = ResourcesManager.LoadAndInit<Sunmao>(sunmaoPath + sunmaoName);
                    sunmao.transform.SetParent(modelDisplay.displayModel.transform);
                    sunmao.transform.ResetTransform();
                    sunmao.transform.localScale = Vector3.one;
                    modelAnim = sunmao.GetComponent<Animator>();
                    animEvent = sunmao.GetComponent<AnimEvent>();
                    sunmaoNameText.text = sunmao.SunmaoName;
                    Image msgImg = ResourcesManager.LoadAndInit<Image>(messageImgPath + sunmaoName);
                    if (msgImg)
                    {
                        msgImg.transform.SetParent(messageImgPos);
                        msgImg.transform.ResetTransform();
                        msgImg.transform.localScale = Vector2.one;
                        msgImg.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                    }
                    else
                    {
                        messageImgPos.gameObject.SetActive(false);
                    }
                }
            }

            if (modelDisplay)
            {
                modelDisplay.OnInit();
            }

            if (animEvent)
            {
                animEvent.isMute = false;
            }

            messageBtn.AddButtonClickEvent(PullRope);
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

        private void PullRope()
        {
            isPull = !isPull;
            MessageContentMove(isPull);
            if (isPull)
            {
                messageBtnAnim.SetTrigger("isPull");
            }
            else
            {
                messageBtnAnim.SetTrigger("isView");
            }
        }

        private void MessageContentMove(bool isPull)
        {
            if (isPull)
            {
                messageImgPos.DOLocalMoveY(0, 1f);
            }
            else
            {
                messageImgPos.DOLocalMoveY(1920, 1f);
            }
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