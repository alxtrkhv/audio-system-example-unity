using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public static class AudioSourceExtension
    {
        public static void SetConfig(this AudioSource audioSource, SoundConfig config)
        {
            audioSource.maxDistance = config.MaxDistance;
        }
    }
}
