using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public interface ISound
    {
        public string Id { get; }
        public SoundConfig Config { get; }

        void Play(AudioSource audioSource);
    }
}
