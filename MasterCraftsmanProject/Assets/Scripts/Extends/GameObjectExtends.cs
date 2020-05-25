using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class GameObjectExtends
    {
        public static T AddorGetComponent<T>(this GameObject gameObject) where T :Component
        {
            if (gameObject == null)
            {
                return null;
            }

            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        public static void Destroy(this UnityEngine.Object obj)
        {
#if UNITY_EDITOR
            GameObject.DestroyImmediate(obj);
#else
            GameObject.Destroy(obj);
#endif
        }

        /// <summary>
        /// 返回找到的第一个,是否是激活的对象
        /// </summary>
        public static GameObject GetChild(this GameObject parent,string name,bool needActive = false)
        {
            var res = parent.transform.Find(name);
            if (res != null && (!needActive || res.gameObject.activeSelf))
            {
                return res.gameObject;
            }

            for (int i = 0; i < parent.transform.childCount; ++i)
            {
                var child = parent.transform.GetChild(i);
                if (needActive && !child.gameObject.activeSelf)
                {
                    continue;
                }
                var ob = GetChild(child.gameObject, name, needActive);
                if (ob) return ob;
            }

            return null;
        }

        public static bool HasChild(this GameObject obj, GameObject child)
        {
            if (obj)
            {
                var myTrans = obj.transform;
                Transform parent = child.transform;
                while (parent)
                {
                    if (parent == myTrans)
                    {
                        return true;
                    }
                    parent = parent.parent;
                }
            }
            return false;
        }

        /// <summary>
        /// 打印对象树
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static string PrintObjectTree(this GameObject go)
        {
            var c = go.transform.parent;
            string r = go.name;
            while (c != null)
            {
                r = c.name + "->" + r;
                c = c.parent;
            }
            return r;
        }
    }
}
