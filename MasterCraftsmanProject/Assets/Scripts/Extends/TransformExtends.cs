using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class TransformExtends
    {
        /// <summary>
        /// 重置子位置为0
        /// </summary>
        public static void ResetLocalPosition(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// 重置子旋转为0
        /// </summary>
        public static void ResetLocalRotation(this Transform transform)
        {
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        /// <summary>
        /// 重置子缩放为0
        /// </summary>
        public static void ResetLocalScale(this Transform transform)
        {
            transform.localScale = Vector3.zero;
        }

        public static void ResetTransform(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.zero;
        }

        /// <summary>
        /// 移除所有子物体
        /// </summary>
        public static void RemoveAllChildrenGameObjects(this Transform transform)
        {
            foreach (var item in transform.GetComponentsInChildren<Transform>())
            {
                if(item.name != transform.name)//防止销毁自身
                {
                    UnityEngine.Object.Destroy(item.gameObject);
                }
            }
        }
    }
}