using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundPlayer
    {
        private Dictionary<string, ISoundContainer> sounds;

        private IObjectPool<ManagedAudioSource> audioSourcesPool;
        private IObjectPool<SoundEvent> soundEventPool;

        private List<SoundEvent> activeEvents;

        private MonoBehaviour monoBehaviour;
        private Coroutine coroutine;

        public SoundPlayer(SoundPlayerConfig config)
        {
            monoBehaviour = config.MonoBehaviour;

            LoadSounds(config.Sounds);
            InitializeCollections(config);

            coroutine = monoBehaviour.StartCoroutine(SoundPlayerLoopCoroutine());
        }

        public void RegisterEmitter(SoundEventEmitter emitter, SoundEventConfig config, Vector3 position)
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

            var soundEvent = soundEventPool.Get();
            soundEvent.Initialize(
                source: audioSource,
                sound: sound,
                config: config
            );

            PlayEvent(soundEvent);
        }

        private void SetAudioSourceLocalPosition(Component audioSource, Component parent, Vector3 position)
        {
            audioSource.transform.SetParent(parent.transform, false);
            audioSource.gameObject.SetActive(true);
            audioSource.transform.localPosition = position;
        }

        private void InitializeCollections(SoundPlayerConfig config)
        {
            var parent = new GameObject("AudioSourcesPool");

            audioSourcesPool = new LazyReleasedMonoBehaviourPool<ManagedAudioSource>(
                size: config.AudioSourcesPoolSize,
                prefab: config.AudioSourcePrefab,
                parentTransform: parent.transform
            );

            soundEventPool = new ObjectPool<SoundEvent>(config.AudioSourcesPoolSize);
            activeEvents = new List<SoundEvent>(config.AudioSourcesPoolSize);
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

        private void PlayEvent(SoundEvent soundEvent)
        {
            var clip = SoundContainerParser.ParseContainerForAudioClip(soundEvent.Sound, soundEvent.Config);

            soundEvent.Status = SoundEvent.EventStatus.Playing;
            soundEvent.ManagedAudioSource.IsBusy = true;

            PlayAudioClip(clip, soundEvent);
        }

        private IEnumerator SoundPlayerLoopCoroutine()
        {
            var loopInterval = new WaitForSecondsRealtime(0.5f);

            while (true) {
                for (var i = 0; i < activeEvents.Count; i++) {
                    var soundEvent = activeEvents[i];

                    if (soundEvent.ManagedAudioSource.AudioSource.isPlaying) {
                        continue;
                    }

                    soundEvent.Status = SoundEvent.EventStatus.Finished;
                    soundEvent.ManagedAudioSource.IsBusy = false;

                    soundEventPool.Release(soundEvent);
                    activeEvents.Remove(soundEvent);
                }

                yield return loopInterval;
            }
        }

        private void PlayAudioClip(AudioClip clip, SoundEvent soundEvent)
        {
            var source = soundEvent.ManagedAudioSource.AudioSource;

            source.clip = clip;
            source.SetConfig(soundEvent.Sound.Config);
            source.Play();

            activeEvents.Add(soundEvent);
        }
    }
}
