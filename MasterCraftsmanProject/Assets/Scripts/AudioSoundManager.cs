using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    /// <summary>
    /// 管理FingertipBallet的所有音效，单例
    /// </summary>
    public class AudioSoundManager : GenericSingleton<AudioSoundManager>
    {
        public List<AudioSource> audioSources = new List<AudioSource>();

        /// <summary>
        /// 播放clip音效，播放后销毁
        /// </summary>
        public void PlaySound(AudioClip clip, GameObject go = null)
        {
            AudioSource aud = null;
            float duration = clip.length;

            if(go != null)
            {
                aud = go.AddComponent(typeof(AudioSource)) as AudioSource;
            }
            else
            {
                aud = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            }

            aud.clip = clip;
            aud.playOnAwake = false;
            aud.Play();

            Destroy(aud, duration);
        }
    }
}