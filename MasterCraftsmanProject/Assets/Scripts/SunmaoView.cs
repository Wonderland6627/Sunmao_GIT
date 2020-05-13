/**
*	Author: Wonderland6627
*	Date: 2020-05-13 17:32:44
*	Version: 0.0
*	Description: 每一个榫卯展示用
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MasterCraftsman
{
    public class SunmaoView : MonoBehaviour
    {
        [Header("模型展示")]
        public ModelDisplay modelDisplay;
        [Header("榫卯名字")]
        public Text sunmaoNameText;

        private void Start()
        {
            OnInit();
        }

        public void OnInit(object param = null)
        {
            if(modelDisplay == null)
            {
                modelDisplay = GetComponentInChildren<ModelDisplay>();
            }
            modelDisplay.OnInit();
        }
    }
}