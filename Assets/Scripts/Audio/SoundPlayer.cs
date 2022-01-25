using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundPlayer
    {
        private const int TaskInterval = 50;

        private Dictionary<string, ISoundContainer> sounds;

        private MonoBehaviourPool<ManagedAudioSource> audioSourcesPool;

        public SoundPlayer(SoundPlayerConfig config = default)
        {
            LoadSounds(config.Sounds);
            InitializePool(config);
        }

        public async void RegisterEmitterAsync(SoundEventEmitter emitter, SoundEventConfig config, Vector3 position)
        {
            var sound = FindSound(emitter.SoundName);

            if (sound == null) {
                return;
            }

            var audioSource = InitializeSoundSourceAtLocalPosition(emitter, position);

            var soundEvent = new SoundEvent();
            soundEvent.Initialize(
                source: audioSource,
                sound: sound,
                config: config
            );

            soundEvent.Status = SoundEvent.EventStatus.Playing;
            await PlaySoundInternal(soundEvent);
            soundEvent.Status = SoundEvent.EventStatus.Finished;
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

        private void LoadSounds(IReadOnlyCollection<ISoundContainer> sounds)
        {
            this.sounds = new Dictionary<string, ISoundContainer>(sounds.Count);

            foreach (var sound in sounds) {
                this.sounds[sound.Id] = sound;
            }
        }

        private ISoundContainer FindSound(string key)
        {
            if (sounds.TryGetValue(key, out var sound)) {
                return sound;
            }

            Debug.LogError($"There is no {key} sound loaded.");
            return null;
        }

        private Task PlaySoundInternal(SoundEvent soundEvent)
        {
            var clip = ParseContainerForAudioClip(soundEvent.Sound, soundEvent.Config);

            return PlayAudioClip(clip, soundEvent.ManagedAudioSource.AudioSource);
        }

        private AudioClip ParseContainerForAudioClip(ISoundContainer container, SoundEventConfig config)
        {
            while (true) {
                var containerMember = container.ContainerType switch
                {
                    SoundContainerType.Single => container[0],
                    SoundContainerType.Random => ParseRandomContainer(container),
                    _ => default
                };

                if (containerMember.SoundContainer != null) {
                    container = containerMember.SoundContainer;
                    continue;
                }

                return containerMember.AudioClip;
            }
        }

        private static SoundContainerMember ParseRandomContainer(ISoundContainer container)
        {
            var index = Random.Range(0, container.Count);

            return container[index];
;        }

        private static Task PlayAudioClip(AudioClip clip, AudioSource source)
        {
            source.clip = clip;
            source.Play();

            return Task.Factory.StartNew(async () =>
            {
                while (source.isPlaying) {
                    await Task.Delay(TaskInterval);
                }
            });
        }

        private void ApplySoundConfig(AudioSource audioSource, SoundConfig config)
        {
        }
    }
}
