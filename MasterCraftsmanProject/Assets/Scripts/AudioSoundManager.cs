using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    /// <summary>
    /// 管理MasterCraftsman的所有音效，单例
    /// </summary>
    public class AudioSoundManager : GenericSingleton<AudioSoundManager>
    {
        private class Sound
        {
            public string name;
            public AudioSource audioSource;
        }

        private List<Sound> soundsList = new List<Sound>();

        private void Start()
        {
            InvokeRepeating("RemoveList", 1, 1);
        }

        public void PlayBGM(string path)
        {

        }

        /// <summary>
        /// 播放soundName音效
        /// </summary>
        public AudioSource Play(string soundName, bool loop = false, GameObject target = null)
        {
            if (string.IsNullOrEmpty(soundName))
            {
                return null;
            }

            string soundPath = "Audios/" + soundName;

            AudioClip audioClip = ResourcesManager.Load<AudioClip>(soundPath);
            if (audioClip == null)
            {
                return null;
            }
            float duration = audioClip.length;

            if (target == null)
            {
                target = gameObject;
            }

            var audioSource = target.AddComponent<AudioSource>();
            audioSource.loop = loop;
            audioSource.playOnAwake = true;
            audioSource.clip = audioClip;
            audioSource.Play();

            if (!loop)
            {
                Destroy(audioSource, duration);
            }

            Sound sound = new Sound();
            sound.name = soundName;
            sound.audioSource = audioSource;
            soundsList.Add(sound);

            return audioSource;
        }

        private void RemoveList()
        {
            soundsList.RemoveAll((Sound sound) => { return sound.audioSource == null; });
        }
    }
}