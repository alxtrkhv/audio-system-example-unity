using System.Collections.Generic;

namespace Alxtrkhv.AudioSystem
{
    public struct SoundPlayerConfig
    {
        public IReadOnlyCollection<ISoundContainer> Sounds { get; }
        public ManagedAudioSource AudioSourcePrefab { get; }
        public int AudioSourcesPoolSize { get; }

        public SoundPlayerConfig(IReadOnlyCollection<ISoundContainer> sounds, ManagedAudioSource audioSourcePrefab,
            int audioSourcesPoolSize)
        {
            Sounds = sounds;
            AudioSourcesPoolSize = audioSourcesPoolSize;
            AudioSourcePrefab = audioSourcePrefab;
        }
    }
}
