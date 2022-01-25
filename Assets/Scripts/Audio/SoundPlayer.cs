using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundPlayer
    {
        private Dictionary<string, ISound> sounds;

        public SoundPlayer(IReadOnlyCollection<ISound> sounds)
        {
            this.sounds = new Dictionary<string, ISound>(sounds.Count);

            foreach (var sound in sounds.Distinct()) {
                this.sounds[sound.Id] = sound;
            }
        }

        public void RegisterEvent(SoundEventEmitter emitter)
        {
            PlaySoundInternal(emitter.SoundName, emitter.AudioSource);
        }

        private void PlaySoundInternal(string key, AudioSource audioSource)
        {
            if (sounds.TryGetValue(key, out var sound)) {
                ApplySoundConfig(audioSource, sound.Config);
                sound.Play(audioSource);
            } else {
                Debug.LogError($"There is no {key} sound loaded.");
            }
        }

        private void ApplySoundConfig(AudioSource audioSource, SoundConfig config)
        {
        }
    }
}
