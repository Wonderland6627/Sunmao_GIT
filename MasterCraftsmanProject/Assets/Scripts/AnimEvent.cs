/**
*	Author: Wonderland6627
*	Date: 2020-05-13 22:28:23
*	Version: 0.0
*	Description: ¶¯»­ÊÂ¼þ
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public class AnimEvent : MonoBehaviour
    {
        public void PlaySound(string soundName)
        {
            AudioSoundManager.Instance.Play(soundName);
        }
    }
}