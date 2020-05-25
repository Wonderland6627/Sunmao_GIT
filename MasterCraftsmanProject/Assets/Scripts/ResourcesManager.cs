/**
*	Author: Wonderland6627
*	Date: 2020-05-13 21:48:37
*	Version: 0.0
*	Description: Resources管理
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public class ResourcesManager : GenericSingleton<ResourcesManager>
    {
        public static T Load<T>(string path) where T : Object
        {
            if (!string.IsNullOrEmpty(path))
            {
                T instance = Resources.Load<T>(path);
                if (instance)
                {
                    return instance;
                }
            }
            return null;
        }

        public static T Init<T>(T instance, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Transform parent = null) where T : Object
        {
            T instanceGo = null;
            if (instance)
            {
                instanceGo = GameObject.Instantiate(instance, position, rotation, parent);
            }
            return instanceGo;
        }

        public static T LoadAndInit<T>(string path, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Transform parent = null) where T : Object
        {
            T go = null;
            if (!string.IsNullOrEmpty(path))
            {
                go = Load<T>(path);
                if (go)
                {
                    T instance = Init<T>(go, position, rotation, parent);
                    instance.name = go.name;
                    return instance;
                }
            }

            return go;
        }

        /// <summary>
        /// 加载View
        /// </summary>
        public SunmaoView OpenView()
        {
            string path = "Prefabs/View/SunmaoView";
            SunmaoView view = LoadAndInit<SunmaoView>(path);
            if (view)
            {
                return view;
            }

            return null;
        }

        public T OpenView<T>() where T : CraftsViewBase
        {
            string path = "Prefabs/View/SunmaoView";
            

            return default(T);
        }
    }
}