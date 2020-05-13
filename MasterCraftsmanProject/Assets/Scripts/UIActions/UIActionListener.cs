/**
*	Author: Wonderland6627
*	Date: 2020-05-13 22:32:16
*	Version: 0.0
*	Description: UIActionBase¼àÌý
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public abstract class UIAction : MonoBehaviour
    {
        public abstract void Do();
    }

    public class UIActionListener : MonoBehaviour
    {
        public UIAction[] UIActions;

        public void Do()
        {
            if (UIActions != null)
            {
                foreach (var act in UIActions)
                {
                    if (act != null)
                    {
                        act.Do();
                    }
                    else
                    {
                        Debug.LogError(act.gameObject.name + " listener is null");
                    }
                }
            }
        }
    }
}