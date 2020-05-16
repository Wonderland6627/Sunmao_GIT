/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-17 01:00:27
*	Description: 榫卯信息
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public class Sunmao : MonoBehaviour
    {
        [SerializeField]
        [Header("榫卯名称")]
        private string sunmaoName;

        public string SunmaoName
        {
            get
            {
                return sunmaoName;
            }
        }
    }
}