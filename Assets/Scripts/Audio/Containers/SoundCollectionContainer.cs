using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Sound Collection Container", menuName = "Audio/Sound Collection Container")]
    public class SoundCollectionContainer : BaseSoundContainer
    {
        [SerializeField]
        private bool randomOrder;

        [Header(AudioClipsHeader)]
        [SerializeField]
        private List<AudioClip> audioClips;

        public override SoundContainerType ContainerType => randomOrder ? SoundContainerType.Random : SoundContainerType.Sequential;

        public override int Count => audioClips.Count;

        public override AudioClip this[int index] => audioClips[index];

        public override IEnumerator<AudioClip> GetEnumerator()
        {
            return ((IEnumerable<AudioClip>)audioClips).GetEnumerator();
        }
    }
}
