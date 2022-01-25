using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New MultiSound Container", menuName = "Audio/MultiSound Container")]
    public class MultiSoundContainer : BaseSoundContainer
    {
        [SerializeField]
        private SoundContainerType containerType;

        [Header(AudioClipsHeader)]
        [SerializeField]
        private List<AudioClip> audioClips;

        public override SoundContainerType ContainerType => containerType;

        public override int Count => audioClips.Count;

        public override AudioClip this[int index] => audioClips[index];

        public override IEnumerator<AudioClip> GetEnumerator()
        {
            return audioClips.GetEnumerator();
        }
    }
}
