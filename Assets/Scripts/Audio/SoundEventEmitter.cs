using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundEventEmitter : MonoBehaviour
    {
        [SerializeField]
        private string soundName;

        private AudioSource audioSource;
        private SoundPlayer soundPlayer;

        public string SoundName => soundName;
        public AudioSource AudioSource => audioSource;

        private void OnEnable()
        {
            audioSource ??= GetComponent<AudioSource>();
            soundPlayer = ApplicationContext.GetSoundPlayer();
        }

        public void Emit()
        {
            soundPlayer.RegisterEmitter(this);
        }
    }
}
