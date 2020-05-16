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
        public GameObject start;

        private void Awake()
        {
#if UNITY_STANDALONE
            Screen.SetResolution(540, 960, false);
#elif UNITY_ANDROID
            Screen.SetResolution(1080, 1920, true);
#endif
            //Cursor.lockState = CursorLockMode.Confined;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(4f);
            Destroy(start);
            MenuView.Instance.OnStart();
        }
    }
}