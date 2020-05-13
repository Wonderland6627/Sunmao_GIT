/**
*	Author: Wonderland6627
*	Date: 2020-05-13 17:01:50
*	Version: 0.0
*	Description: 模型展示
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace MasterCraftsman
{
    public class ModelDisplay : MonoBehaviour, IDragHandler, IPointerClickHandler
    {
        [Header("展示模型")]
        public Transform displayModel;
        [Header("正在拖拽")]
        public bool isDrag = false;

        private Vector3 targetVec;//目标旋转位置
        private Vector3 startVec;//初始位置
        private float dragDuration = 0.2f;
        private float backDuration = 1f;

        private Tweener rotateTweener;

        public void OnInit(object param = null)
        {
            rotateTweener = null;
            startVec = displayModel.localRotation.eulerAngles;
        }

        private void OnDestroy()
        {
            rotateTweener = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                isDrag = true;
                targetVec.z += -eventData.delta.y;
                targetVec.y += -eventData.delta.x;
                rotateTweener = displayModel.DOLocalRotate(targetVec, dragDuration);
                targetVec = displayModel.localRotation.eulerAngles;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isDrag)
            {
                rotateTweener = displayModel.DOLocalRotate(startVec, backDuration);
            }
            isDrag = false;
            rotateTweener = null;
        }
    }
}