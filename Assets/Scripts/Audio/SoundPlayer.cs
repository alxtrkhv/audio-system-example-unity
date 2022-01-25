using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundPlayer
    {
        private const int TaskInterval = 50;

        private Dictionary<string, ISoundContainer> sounds;

        private IObjectPool<ManagedAudioSource> audioSourcesPool;

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

            var audioSource = emitter.GetFreeAudioSource();

            if (audioSource == null) {
                audioSource = audioSourcesPool.Get();
                emitter.AssignAudioSource(audioSource);
            }

            SetAudioSourceLocalPosition(audioSource, emitter, position);

            var soundEvent = new SoundEvent();
            soundEvent.Initialize(
                source: audioSource,
                sound: sound,
                config: config
            );

            soundEvent.Status = SoundEvent.EventStatus.Playing;
            audioSource.IsBusy = true;

            await PlayEvent(soundEvent);

            soundEvent.Status = SoundEvent.EventStatus.Finished;
            audioSource.IsBusy = false;
        }

        private void SetAudioSourceLocalPosition(Component audioSource, Component parent, Vector3 position)
        {
            audioSource.transform.SetParent(parent.transform, false);
            audioSource.gameObject.SetActive(true);
            audioSource.transform.localPosition = position;
        }

        private void InitializePool(SoundPlayerConfig config)
        {
            var parent = new GameObject("AudioSourcesPool");

            audioSourcesPool = new LazyReleasedMonoBehaviourPool<ManagedAudioSource>(
                size: config.AudioSourcesPoolSize,
                prefab: config.AudioSourcePrefab,
                parentTransform: parent.transform
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

        private Task PlayEvent(SoundEvent soundEvent)
        {
            var clip = SoundContainerParser.ParseContainerForAudioClip(soundEvent.Sound, soundEvent.Config);

            return PlayAudioClip(clip, soundEvent.ManagedAudioSource.AudioSource, soundEvent.Sound.Config);
        }

        private static Task PlayAudioClip(AudioClip clip, AudioSource source, SoundConfig config)
        {
            source.clip = clip;
            source.SetConfig(config);
            source.Play();

            return Task.Factory.StartNew(async () =>
            {
                while (source.isPlaying) {
                    await Task.Delay(TaskInterval);
                }
            });
        }
    }
}
