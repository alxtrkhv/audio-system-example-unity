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
        private SoundContainerMember member;

        public override SoundContainerType ContainerType => SoundContainerType.Single;

        public override int Count => 1;

        public override SoundContainerMember this[int index] {
            get {
                if (index != 0) {
                    throw new IndexOutOfRangeException();
                }

                return member;
            }
        }

        public override IEnumerator<SoundContainerMember> GetEnumerator()
        {
            yield return member;
        }
    }
}
