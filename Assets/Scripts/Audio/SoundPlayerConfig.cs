using System.Collections.Generic;

namespace Alxtrkhv.AudioSystem
{
    public struct SoundPlayerConfig
    {
        public IReadOnlyCollection<ISound> Sounds { get; }
        public int AudioSourcesPoolSize { get; }
        public ManagedAudioSource AudioSourcePrefab { get; }

        public SoundPlayerConfig(IReadOnlyCollection<ISound> sounds, int poolSize, ManagedAudioSource audioSourcePrefab)
        {
            Sounds = sounds;
            AudioSourcesPoolSize = poolSize;
            AudioSourcePrefab = audioSourcePrefab;
        }
    }
}
