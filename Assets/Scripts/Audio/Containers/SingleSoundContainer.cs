using System;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Single Sound Container", menuName = "Audio/Single Sound Container")]
    public class SingleSoundContainer : BaseSoundContainer
    {
        [Header(AudioClipsHeader)]
        [SerializeField]
        private AudioClip audioClip;

        public override SoundContainerType ContainerType => SoundContainerType.Single;

        public override int Count => 1;

        public override AudioClip this[int index] {
            get {
                if (index != 0) {
                    throw new IndexOutOfRangeException();
                }

                return audioClip;
            }
        }

        public override IEnumerator<AudioClip> GetEnumerator()
        {
            yield return audioClip;
        }
    }
}
