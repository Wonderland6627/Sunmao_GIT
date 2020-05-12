using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class GameObjectExtends
    {
        public static T AddorGetComponent<T>(this GameObject gameObject) where T :Component
        {
            if(gameObject.GetComponent<T>() == null)
            {
                return gameObject.AddComponent(typeof(T)) as T;
            }
            return gameObject.GetComponent<T>();
        }
    }
}
