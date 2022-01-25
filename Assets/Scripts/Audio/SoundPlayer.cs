using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundPlayer
    {
        private Dictionary<string, ISound> sounds;

        private MonoBehaviourPool<ManagedAudioSource> audioSourcesPool;

        public SoundPlayer(SoundPlayerConfig config = default)
        {
            LoadSounds(config.Sounds);
            InitializePool(config);
        }

        public async void RegisterEmitter(SoundEventEmitter emitter, Vector3 position)
        {
            var sound = FindSound(emitter.SoundName);

            if (sound == null) {
                return;
            }

            var audioSource = InitializeSoundSourceAtLocalPosition(emitter, position);

            var soundEvent = new SoundEvent();
            soundEvent.Initialize(
                source: audioSource,
                sound: sound
            );

            await PlaySoundInternal(soundEvent);
        }

        private ManagedAudioSource InitializeSoundSourceAtLocalPosition(Component parent, Vector3 position)
        {
            var audioSource = audioSourcesPool.Get();

            audioSource.transform.SetParent(parent.transform, false);
            audioSource.gameObject.SetActive(true);
            audioSource.transform.localPosition = position;

            return audioSource;
        }

        private void InitializePool(SoundPlayerConfig config)
        {
            audioSourcesPool = new MonoBehaviourPool<ManagedAudioSource>(
                size: config.AudioSourcesPoolSize,
                prefab: config.AudioSourcePrefab,
                parentTransform: null
            );
        }

        private void LoadSounds(IReadOnlyCollection<ISound> sounds)
        {
            this.sounds = new Dictionary<string, ISound>(sounds.Count);

            foreach (var sound in sounds.Distinct()) {
                this.sounds[sound.Id] = sound;
            }
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
