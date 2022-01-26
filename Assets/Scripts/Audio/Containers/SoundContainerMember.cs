using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [Serializable]
    public struct SoundContainerMember
    {
        [SerializeField]
        private AudioClip audioClip;
        [SerializeField]
        private BaseSoundContainer soundContainer;

        public AudioClip AudioClip => audioClip;
        public BaseSoundContainer SoundContainer => soundContainer;
    }
}
