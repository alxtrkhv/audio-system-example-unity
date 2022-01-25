using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public abstract class BaseSoundContainer : ScriptableObject, ISoundContainer
    {
        protected const string AudioClipsHeader = "Audio Clips";

        [Header("Settings")]
        [SerializeField]
        private SoundConfig config;

        public abstract AudioClip this[int index] { get; }
        public abstract IEnumerator<AudioClip> GetEnumerator();
        public abstract int Count { get; }

        public abstract SoundContainerType ContainerType { get; }

        public string Id => name;
        public SoundConfig Config => config;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
