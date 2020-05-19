/**
*	Author: Wonderland6627
*	Date: 2020-05-13 22:28:23
*	Version: 0.0
*	Description: 动画事件
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public class AnimEvent : MonoBehaviour
    {
        public bool isMute = false;//是否静音
        
        public void PlaySound(string soundName)
        {
            if (!isMute)
            {
                AudioSoundManager.Instance.Play(soundName);
            }
        }
    }
}