using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Alxtrkhv.AudioSystem
{
    [Serializable]
    public class SoundConfig
    {
        [SerializeField]
        private AudioMixerGroup mixerGroup;

        [SerializeField]
        private SnapshotGroup snapshotGroup;

        [SerializeField]
        private int snapshotGroupMemberIndex;

        [SerializeField]
        private float maxDistance;

        public AudioMixerGroup MixerGroup => mixerGroup;
        public float MaxDistance => maxDistance;
        public SnapshotGroup SnapshotGroup => snapshotGroup;
        public int SnapshotGroupMemberIndex => snapshotGroupMemberIndex;
    }
}
