/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-22 15:04:15
*	Description: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class CraftsViewBase : MonoBehaviour
    {
        [Header("CanvasGroup")]
        public CanvasGroup canvasGroup;

        [Header("关闭按钮")]
        public Button closeBtn;

        public virtual void OnInit(object param = null)
        {
            
        }

        public virtual void OnOpen()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1, 0.5f);
            canvasGroup.DisplayCanvasGroup(true);
        }

        public virtual void OnClose()
        {
            canvasGroup.DisplayCanvasGroup(false);
            transform.DOScale(0, 0.5f)
                .OnComplete(() => 
                {
                    Destroy(gameObject);
                });
        }
    }
}