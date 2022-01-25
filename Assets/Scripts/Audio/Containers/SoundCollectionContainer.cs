using System;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Sound Collection Container", menuName = "Audio/Sound Collection Container")]
    public class SoundCollectionContainer : BaseSoundContainer
    {
        private enum CollectionMode
        {
            Random,
            Sequential,
            Switch
        }

        [SerializeField]
        private CollectionMode collectionMode;

        [Header(AudioClipsHeader)]
        [SerializeField]
        private List<SoundContainerMember> members;

        public override SoundContainerType ContainerType => collectionMode switch
        {
            CollectionMode.Random => SoundContainerType.Random,
            CollectionMode.Sequential => SoundContainerType.Sequential,
            CollectionMode.Switch => SoundContainerType.Switch,
            _ => throw new NotImplementedException($"{collectionMode} mode of {nameof(SoundCollectionContainer)} is not supported.")
        };

        public override int Count => members.Count;

        public override SoundContainerMember this[int index] => members[index];

        public override IEnumerator<SoundContainerMember> GetEnumerator()
        {
            return ((IEnumerable<SoundContainerMember>)members).GetEnumerator();
        }
    }
}
