using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace MasterCraftsman.Extends
{
    public static class SelectableExtends
    {
        public static void AddButtonClickEvent(this Button button, UnityAction action)
        {
            if (button != null)
            {
                button.onClick.RemoveListener(action);
                button.onClick.AddListener(action);
            }
        }
    }
}