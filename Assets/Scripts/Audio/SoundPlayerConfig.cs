using System.Collections.Generic;

namespace Alxtrkhv.AudioSystem
{
    public struct SoundPlayerConfig
    {
        public IReadOnlyCollection<ISoundContainer> Sounds { get; }
        public int AudioSourcesPoolSize { get; }
        public ManagedAudioSource AudioSourcePrefab { get; }

        public SoundPlayerConfig(IReadOnlyCollection<ISoundContainer> sounds, int poolSize, ManagedAudioSource audioSourcePrefab)
        {
            Sounds = sounds;
            AudioSourcesPoolSize = poolSize;
            AudioSourcePrefab = audioSourcePrefab;
        }
    }
}
