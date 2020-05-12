using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class CanvasExtends
    {
        public static void DisplayCanvasGroup(this CanvasGroup canvasGroup, bool value)
        {
            if (canvasGroup != null)
            {
                if (value)
                {
                    canvasGroup.alpha = 1f;
                }
                else
                {
                    canvasGroup.alpha = 0;
                }
            }
        }
    }
}