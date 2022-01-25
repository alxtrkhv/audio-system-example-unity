using System.Collections.Generic;

namespace Alxtrkhv.AudioSystem
{
    public struct SoundPlayerConfig
    {
        public IReadOnlyCollection<ISoundContainer> Sounds { get; }
        public ManagedAudioSource AudioSourcePrefab { get; }
        public int AudioSourcesPoolSize { get; }
        public int SoundEventPoolSize { get; }

        public SoundPlayerConfig(IReadOnlyCollection<ISoundContainer> sounds, ManagedAudioSource audioSourcePrefab,
            int audioSourcesPoolSize, int soundEventPoolSize)
        {
            Sounds = sounds;
            AudioSourcesPoolSize = audioSourcesPoolSize;
            AudioSourcePrefab = audioSourcePrefab;
            SoundEventPoolSize = soundEventPoolSize;
        }
    }
}
