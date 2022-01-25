using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async void RegisterEvent(SoundEventEmitter emitter)
        {
            var soundEvent = new SoundEvent();
            var sound = FindSound(emitter.SoundName);

            if (sound == null) {
                return;
            }

            soundEvent.Register(
                source: emitter.AudioSource,
                sound: sound
            );

            await PlaySoundInternal(soundEvent);
        }

        private ISound FindSound(string key)
        {
            if (sounds.TryGetValue(key, out var sound)) {
                return sound;
            }

            Debug.LogError($"There is no {key} sound loaded.");
            return null;
        }

        private async Task PlaySoundInternal(SoundEvent soundEvent)
        {
            await soundEvent.Play();
        }

        private void ApplySoundConfig(AudioSource audioSource, SoundConfig config)
        {
        }
    }
}
