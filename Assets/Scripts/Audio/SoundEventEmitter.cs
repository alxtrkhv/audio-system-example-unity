using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundEventEmitter : MonoBehaviour
    {
        [SerializeField]
        private string soundName;

        private SoundPlayer soundPlayer;

        public string SoundName => soundName;

        private List<ManagedAudioSource> audioSources = new List<ManagedAudioSource>();

        private void OnEnable()
        {
            soundPlayer = ApplicationContext.GetSoundPlayer();
        }

        public void Emit(SoundEventConfig config = default)
        {
            soundPlayer.RegisterEmitter(this, config, Vector3.zero);
        }

        public void EmitAtLocalPosition(Vector3 position, SoundEventConfig config = default)
        {
            soundPlayer.RegisterEmitter(this, config, position);
        }

        public void AssignAudioSource(ManagedAudioSource audioSource)
        {
            audioSources.Add(audioSource);
            audioSource.AssignEmitter(this);
        }

        public ManagedAudioSource GetFreeAudioSource()
        {
            ManagedAudioSource source = null;

            for (var i = 0; i < audioSources.Count; i++) {
                if (!audioSources[i].IsBusy) {
                    source = audioSources[i];
                }
            }

            return source;
        }

        public void ReleaseAudioSource(ManagedAudioSource audioSource)
        {
            audioSources.Remove(audioSource);
        }
    }
}
