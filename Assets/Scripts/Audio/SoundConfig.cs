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
        private AudioMixerSnapshot mixerSnapshot;

        [SerializeField]
        private int priority;

        [SerializeField]
        private float maxDistance;

        public AudioMixerGroup MixerGroup => mixerGroup;
        public AudioMixerSnapshot MixerSnapshot => mixerSnapshot;
        public int Priority => priority;
        public float MaxDistance => maxDistance;
    }
}
