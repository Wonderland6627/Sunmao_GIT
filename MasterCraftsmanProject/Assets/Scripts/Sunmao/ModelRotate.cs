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
        private float dragDuration = 0.8f;
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
            displayMenu.parent.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            rotateTweener = null;
        }

        [ContextMenu("SetChildPos")]
        public void SetChildPos()
        {
            var count = displayMenu.childCount;
            var modelAngle = 360.0f / count;
            for (int i = 0; i < count; i++)
            {
                var go = displayMenu.GetChild(i);
                Debug.Log(go.name);
                go.localRotation = Quaternion.Euler(new Vector3(0, modelAngle * i, 0));
                go.transform.Translate(0, 0, -20);
            }
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
                //isDrag = true;
                if (CalcDragOffset())
                {
                    dragOffset += eventData.delta.x;
                }
                targetVec.y += -eventData.delta.x;
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
                SunmaoViewBase view = ResourcesManager.Instance.OpenView();
                view.OnInit(currentSunmao.name);
                MenuView.Instance.OnChangeView(false);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ConfigRotate();
            //if (isDrag)
            //{
            //    Debug.Log(dragOffset);
            //    if (rotateTweener != null)
            //    {
            //        rotateTweener.OnComplete(() =>
            //        {
            //            //if(Mathf.Abs(dragOffset) >= (Screen.width / 2))//拖拽大于2/3个屏幕了 或者改成松手位置
            //            {
            //                //ConfigRotate();
            //            }
            //        });
            //    }
            //    isDrag = false;
            //}
        }

        /// <summary>
        /// 矫正旋转位置
        /// </summary>
        private void ConfigRotate()
        {
            var sunmao = FindFisrtSunmao();
            Vector3 targetVec = Vector3.zero;
            var index = sunmaoList.FindIndex((item) => { return sunmao == item; });
            targetVec.y -= index * modelAngle;
            rotateTweener = displayMenu.DOLocalRotate(targetVec, dragDuration);
            currentSunmao = sunmao;
            Debug.Log("当前" + currentSunmao + sunmao.name);
            dragOffset = 0;
        }
    }
}