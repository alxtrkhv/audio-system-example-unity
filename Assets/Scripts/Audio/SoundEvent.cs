using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundEvent
    {
        public enum EventStatus
        {
            Registered,
            Playing,
            Paused,
            Finished
        }

        public ISound Sound { get; private set; }
        public AudioSource AudioSource { get; private set; }
        public EventStatus Status { get; private set; }

        public void Register(ISound sound, AudioSource source)
        {
            Sound = sound;
            AudioSource = source;
            Status = EventStatus.Registered;
        }

        public async void Play()
        {
            Status = EventStatus.Playing;
            await Sound.Play(AudioSource);
            Status = EventStatus.Finished;
        }
    }
}
