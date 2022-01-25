using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public struct SoundPlayerConfig
    {
        public IReadOnlyCollection<ISoundContainer> Sounds { get; }
        public ManagedAudioSource AudioSourcePrefab { get; }
        public int AudioSourcesPoolSize { get; }
        public MonoBehaviour MonoBehaviour { get; }

        public SoundPlayerConfig(IReadOnlyCollection<ISoundContainer> sounds, ManagedAudioSource audioSourcePrefab,
            int audioSourcesPoolSize, MonoBehaviour monoBehaviour)
        {
            Sounds = sounds;
            AudioSourcesPoolSize = audioSourcesPoolSize;
            AudioSourcePrefab = audioSourcePrefab;
            MonoBehaviour = monoBehaviour;
        }
    }
}
