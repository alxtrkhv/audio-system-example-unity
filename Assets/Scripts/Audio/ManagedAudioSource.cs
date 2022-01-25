using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class ManagedAudioSource : MonoBehaviour, ILazyPoolable
    {
        [SerializeField]
        private AudioSource audioSource;

        private SoundEventEmitter emitter;

        public AudioSource AudioSource => audioSource;

        public bool IsBusy { get; set; }
        public bool IsReadyForRelease => !IsBusy;

        public void AssignEmitter(SoundEventEmitter emitter)
        {
            this.emitter = emitter;
        }

        public void Release()
        {
            emitter.ReleaseAudioSource(this);
            gameObject.SetActive(false);
        }
    }
}
