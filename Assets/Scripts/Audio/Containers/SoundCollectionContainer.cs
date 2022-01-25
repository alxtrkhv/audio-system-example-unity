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
        private List<SoundContainerMember> members;

        public override SoundContainerType ContainerType => randomOrder ? SoundContainerType.Random : SoundContainerType.Sequential;

        public override int Count => members.Count;

        public override SoundContainerMember this[int index] => members[index];

        public override IEnumerator<SoundContainerMember> GetEnumerator()
        {
            return ((IEnumerable<SoundContainerMember>)members).GetEnumerator();
        }
    }
}
