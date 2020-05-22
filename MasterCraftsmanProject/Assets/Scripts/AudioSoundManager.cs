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
        private AudioSource currentBGM = null;
        private string currentBGMName = null;

        private void Start()
        {
            InvokeRepeating("RemoveList", 1, 1);
        }

        public void MuteSounds(bool isMute)
        {
            if (soundsList.Count > 0)
            {
                soundsList.ForEach((item) =>
                {
                    item.audioSource.mute = isMute;
                });
            }
            
            if (currentBGM)
            {
                currentBGM.mute = isMute;
            }
        }

        public AudioSource PlayBGM(string soundName, float volume = 1)
        {
            if (currentBGM != null && currentBGM.isPlaying && currentBGMName == soundName)
            {
                return currentBGM;
            }

            StopBGM();
            currentBGM = Play(soundName, true);
            currentBGM.volume = volume;
            currentBGMName = soundName;

            return currentBGM;
        }

        public void StopBGM()
        {
            if (currentBGM != null)
            {
                Destroy(currentBGM);
            }
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

        public void Stop(string soundName)
        {
            foreach (var sound in soundsList)
            {
                if (sound.name == soundName && sound.audioSource != null)
                {
                    Destroy(sound.audioSource);
                }
            }
        }

        private void RemoveList()
        {
            soundsList.RemoveAll((Sound sound) => { return sound.audioSource == null; });
        }
    }
}