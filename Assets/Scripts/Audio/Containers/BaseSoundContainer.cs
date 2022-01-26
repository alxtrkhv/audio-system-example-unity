using System;
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

        public abstract SoundContainerMember this[int index] { get; }
        public abstract IEnumerator<SoundContainerMember> GetEnumerator();
        public abstract int Count { get; }

        public abstract SoundContainerType ContainerType { get; }

        public string Id { get; private set; }

        public SoundConfig Config => config;

        private void OnEnable()
        {
            Id = name;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
