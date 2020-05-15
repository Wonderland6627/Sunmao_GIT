/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-15 15:55:52
*	Description: MasterCraftsman启动器，所有物体的初始化
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public class MCStarter : MonoBehaviour
    {
        private void Awake()
        {
            Screen.SetResolution(540, 960, false);
            //Cursor.lockState = CursorLockMode.Confined;
        }

        private void Start()
        {
            MenuView.Instance.OnStart();
        }
    }
}