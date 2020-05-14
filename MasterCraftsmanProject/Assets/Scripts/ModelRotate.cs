/**
*	Author: Wonderland6627
*	Date: 2020-05-14 11:23:34
*	Version: 0.0
*	Description: 菜单页
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace MasterCraftsman
{
    public class ModelRotate : MonoBehaviour, IDragHandler, IPointerClickHandler, IPointerUpHandler
    {
        [Header("展示菜单")]
        public Transform displayMenu;

        private Vector3 targetVec;//目标旋转位置
        private float dragDuration = 0.2f;
        private float backDuration = 1f;

        private Tweener rotateTweener;

        public void OnInit(object param = null)
        {
            rotateTweener = null;
        }

        private void OnDestroy()
        {
            rotateTweener = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                dragOffset += eventData.delta.x;
                targetVec.y += -eventData.delta.x;
                rotateTweener = displayMenu.DOLocalRotate(targetVec, dragDuration);
                targetVec = displayMenu.localRotation.eulerAngles;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount == 2)
            {
                
            }
        }

        private float dragOffset = 0;
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log(dragOffset);
            dragOffset = 0;
        }
    }
}