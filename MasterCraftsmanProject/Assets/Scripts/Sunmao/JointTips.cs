/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-25 16:24:18
*	Description: 拼接提示
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class JointTips : MonoBehaviour
    {
        public HighlightableObject highlightableObject;

        private void Awake()
        {
            highlightableObject = gameObject.AddorGetComponent<HighlightableObject>();//这句话要放在Awake中
        }

        public void FlashOn(Color color)
        {
            Color clear = new Color(color.r, color.g, color.b, 0);
            highlightableObject.FlashingOn(clear, color, 1);
        }

        public void ConstantOn(Color color)
        {
            highlightableObject.ConstantOn(color);
        }

        public void ConstantOff()
        {
            highlightableObject.ConstantOff();
        }
    }
}