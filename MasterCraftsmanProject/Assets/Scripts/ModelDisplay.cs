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
    public class ModelDisplay : MonoBehaviour, IDragHandler ,IPointerClickHandler
    {
        [Header("展示模型")]
        public Transform displayModel;
        [Header("正在拖拽")]
        public bool isDrag = false;

        private Vector3 targetVec;//目标旋转位置
        [SerializeField]
        private Vector3 startVec;//初始位置
        private float dragDuration = 0.2f;
        private float backDuration = 1f;

        public void OnInit(object param = null)
        {
            startVec = displayModel.localRotation.eulerAngles;
        }

        public void OnDrag(PointerEventData eventData)
        {
            isDrag = true;
            //targetVec.x += eventData.delta.y;
            targetVec.y += -eventData.delta.x;
            displayModel.DOLocalRotate(targetVec, dragDuration);
            targetVec = displayModel.localRotation.eulerAngles;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isDrag)
            {
                displayModel.DOLocalRotate(startVec, backDuration);
            }
            isDrag = false;
        }
    }
}