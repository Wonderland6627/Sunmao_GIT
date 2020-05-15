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
        [Header("榫卯List")]
        public List<GameObject> sunmaoList;
        [Header("展示数量")]
        public int count;
        [Header("当前选中榫卯")]
        public GameObject currentSunmao;

        [SerializeField]
        private float dragOffset = 0;
        private Vector3 targetVec;//目标旋转位置
        private float dragDuration = 1f;
        private float backDuration = 1f;

        private Tweener rotateTweener;
        [SerializeField]
        private float modelAngle;
        [SerializeField]
        private bool isDrag = false;

        public void OnInit(object param = null)
        {
            InitSunmaoList();
            modelAngle = 360f / count;

            rotateTweener = null;
        }

        private void OnDestroy()
        {
            rotateTweener = null;
        }

        private void InitSunmaoList()
        {
            count = displayMenu.childCount;
            for (int i = 0; i < count; i++)
            {
                sunmaoList.Add(displayMenu.GetChild(i).gameObject);
            }
            currentSunmao = sunmaoList[0];
        }

        private bool CalcDragOffset()
        {
            var delta = Input.mousePosition;
            if(Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width
                && Input.mousePosition.y>=0 && Input.mousePosition.y<= Screen.height)
            {
                return true;
            }
            return false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                isDrag = true;
                if (CalcDragOffset())
                {
                    dragOffset += eventData.delta.x;
                }
                targetVec.y += -eventData.delta.x / 2;
                rotateTweener = displayMenu.DOLocalRotate(targetVec, dragDuration);
                targetVec = displayMenu.localRotation.eulerAngles;
            }
        }

        /// <summary>
        /// 找到最前面的榫卯最为选中榫卯
        /// </summary>
        public GameObject FindFisrtSunmao()
        {
            GameObject currentSunmao = null;
            var nearZ = sunmaoList[0].transform.position.z;
            currentSunmao = sunmaoList[0];
            Debug.Log(nearZ);
            for (int i = 1; i < count; i++)
            {
                if(sunmaoList[i].transform.position.z < nearZ)
                {
                    nearZ = sunmaoList[i].transform.position.z;
                    currentSunmao = sunmaoList[i];
                }
            }

            return currentSunmao;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount == 2)
            {
                SunmaoViewBase view = ResourcesManager.Instance.OpenView(currentSunmao.name + "_View");
                view.OnInit();
                MenuView.Instance.OnChangeView(false);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isDrag)
            {
                Debug.Log(dragOffset);
                if (rotateTweener != null)
                {
                    rotateTweener.OnComplete(() =>
                    {
                        //if(Mathf.Abs(dragOffset) >= (Screen.width / 2))//拖拽大于2/3个屏幕了 或者改成松手位置
                        {
                            var sunmao = FindFisrtSunmao();
                            Vector3 targetVec = Vector3.zero;
                            var index = sunmaoList.FindIndex((item) => { return sunmao == item; });
                            targetVec.y += index * modelAngle;
                            rotateTweener = displayMenu.DOLocalRotate(targetVec, dragDuration);
                            currentSunmao = sunmao;
                            dragOffset = 0;
                            Debug.Log("当前" + currentSunmao + sunmao.name);
                        }
                    });
                }
                isDrag = false;
            }
        }
    }
}