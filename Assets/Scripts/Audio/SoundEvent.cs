using System;
using System.Threading.Tasks;
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

        public event Action Finished;

        public ISound Sound { get; private set; }
        public ManagedAudioSource ManagedAudioSource { get; private set; }
        public EventStatus Status { get; private set; }

        public void Initialize(ISound sound, ManagedAudioSource source)
        {
            Sound = sound;
            ManagedAudioSource = source;
            Status = EventStatus.Registered;
        }

        public async Task Play()
        {
            Status = EventStatus.Playing;
            await Sound.Play(ManagedAudioSource.AudioSource, this);
            Status = EventStatus.Finished;

            Finished?.Invoke();
        }
    }
}
