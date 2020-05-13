/**
*	Author: Wonderland6627
*	Date: 2020-05-13 21:48:37
*	Version: 0.0
*	Description: Resourcesπ‹¿Ì
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
            T instance = null;
            if (!string.IsNullOrEmpty(path))
            {
                instance = Load<T>(path);
                if (instance)
                {
                    instance = Init<T>(instance, position, rotation, parent);
                    return instance;
                }
            }
            return instance;
        }
    }
}