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
        [Header("最小缩放")]
        public float minScale;
        [Header("最大缩放")]
        public float maxScale;  

        private Vector3 targetVec;//目标旋转位置
        private Vector3 startVec;//初始位置
        private float scaleValue = 1f;//缩放
        private float changeDuration = 0.2f;
        private float backDuration = 1f;

        private Tweener rotateTweener;
        private Tweener scaleTweener;

        public void OnInit(object param = null)
        {
            rotateTweener = null;
            scaleTweener = null;
            startVec = displayModel.localRotation.eulerAngles;
        }

        private void OnDestroy()
        {
            rotateTweener = null;
            scaleTweener = null;
        }

        private void FixedUpdate()
        {
            float value = Input.GetAxis("Mouse ScrollWheel");
            if(value == 0)
            {
                return;
            }
            scaleValue = Mathf.Clamp(scaleValue += value, minScale, maxScale);
            scaleTweener = displayModel.DOScale(scaleValue, changeDuration);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                targetVec.z += -eventData.delta.y;
                targetVec.y += -eventData.delta.x;
                rotateTweener = displayModel.DOLocalRotate(targetVec, changeDuration);
                targetVec = displayModel.localRotation.eulerAngles;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.clickCount == 2)
            {
                rotateTweener = displayModel.DOLocalRotate(startVec, backDuration);
                scaleTweener = displayModel.DOScale(Vector3.one, backDuration);
            }
        }
    }
}