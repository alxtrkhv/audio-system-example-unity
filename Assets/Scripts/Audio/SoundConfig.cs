using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [Serializable]
    public struct SoundConfig
    {
        [SerializeField]
        private float maxDistance;

        public float MaxDistance => maxDistance;
    }
}
