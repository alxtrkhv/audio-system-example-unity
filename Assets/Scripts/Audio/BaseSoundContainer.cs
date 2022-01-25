using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public abstract class BaseSoundContainer : ScriptableObject, ISound
    {
        [Header("Settings")]
        [SerializeField]
        private SoundConfig config;

        public string Id => name;
        public SoundConfig Config => config;

        public abstract void Play(AudioSource audioSource);
    }
}
