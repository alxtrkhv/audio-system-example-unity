using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class ManagedAudioSource : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        public AudioSource AudioSource => audioSource;

        public bool IsBusy { get; set; }
        public bool IsMarkedForRelease => !IsBusy;
    }
}
