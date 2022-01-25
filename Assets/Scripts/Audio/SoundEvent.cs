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
        public SoundEventConfig Config { get; private set; }

        public void Initialize(ISound sound, ManagedAudioSource source, SoundEventConfig config)
        {
            Sound = sound;
            ManagedAudioSource = source;
            Status = EventStatus.Registered;
            Config = config;
        }

        public async Task Play()
        {
            Status = EventStatus.Playing;
            await Sound.Play(this);
            Status = EventStatus.Finished;

            Finished?.Invoke();
        }
    }
}
