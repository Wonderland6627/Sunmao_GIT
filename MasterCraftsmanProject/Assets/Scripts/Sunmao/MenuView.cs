/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-15 15:59:38
*	Description: 主界面展示，一个单例，这个界面不需要销毁了
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class MenuView : MonoBehaviour
    {
        private static MenuView _instance;

        [Header("CanvasGroup")]
        public CanvasGroup canvasGroup;
        [Header("摄像机")]
        public Transform mainCamera;
        [Header("旋转展示拖拽")]
        public ModelRotate modelRotate;
        [Header("展示模型")]
        public Transform displayModel;
        [Header("展示背景")]
        public GameObject backGroundPanel;
        [Header("声音按钮")]
        public Button soundBtn;
        [Header("静音提示")]
        public GameObject muteTips;

        private bool isMute = false;

        public static MenuView Instance
        {
            get
            {
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }
        }

        public void OnStart(object param = null)
        {
            modelRotate.OnInit();
            soundBtn.AddButtonClickEvent(MuteAudio);
            backGroundPanel.SetActive(true);
            gameObject.SetActive(true);
            FirstView();
        }

        private void MuteAudio()
        {
            isMute = !isMute;
            muteTips.SetActive(isMute);
            AudioSoundManager.Instance.MuteSounds(isMute);
        }

        private void FirstView()
        {
            displayModel.localPosition = new Vector3(0, -50, 15);
            modelTweener = displayModel.DOLocalMoveY(2.5f, 1f);
            cameraTweener = mainCamera.DOLocalMoveZ(-24.5f, 1f);
            canvasGroup.DisplayCanvasGroup(true);
        }

        public void OnChangeView(bool toMenu)
        {
            MoveCamera(toMenu);
            MoveModelRotate(toMenu);
            canvasGroup.DisplayCanvasGroup(toMenu);
        }

        private Tweener modelTweener;
        private void MoveModelRotate(bool toMenu)
        {
            if (toMenu)
            {
                displayModel.localPosition = new Vector3(0, 50, 15);
                modelTweener = displayModel.DOLocalMoveY(2.5f, 1f);
            }
            else
            {
                modelTweener = displayModel.DOLocalMoveY(-50f, 1f);
            }
        }

        private Tweener cameraTweener;
        /// <summary>
        /// 移动摄像机 是否是返回主页
        /// </summary>
        private void MoveCamera(bool toMenu)
        {
            if (toMenu)
            {
                cameraTweener = mainCamera.DOLocalMoveZ(-24.5f, 1f);
            }
            else
            {
                cameraTweener = mainCamera.DOLocalMoveZ(-8, 1f);
            }
        }
    }
}