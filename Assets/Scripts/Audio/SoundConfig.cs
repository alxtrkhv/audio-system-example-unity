using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Alxtrkhv.AudioSystem
{
    [Serializable]
    public struct SoundConfig
    {
        [SerializeField]
        private AudioMixerGroup mixerGroup;

        [SerializeField]
        private float maxDistance;

        public AudioMixerGroup MixerGroup => mixerGroup;
        public float MaxDistance => maxDistance;
    }
}
