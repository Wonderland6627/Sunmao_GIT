/**
*	Author: Wonderland6627
*	Date: 2020-05-13 22:41:42
*	Version: 0.0
*	Description: 播放声音
*/

using System;
using UnityEngine;

namespace MasterCraftsman
{
    public class PlaySound : UIAction
    {
        public string soundName;
        public bool loop;
        public GameObject target;

        public override void Do()
        {
            AudioSoundManager.Instance.Play(soundName, loop, target);
        }
    }
}