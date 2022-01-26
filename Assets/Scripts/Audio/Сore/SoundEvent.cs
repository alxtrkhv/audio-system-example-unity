using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundEvent : IPoolable
    {
        public enum EventStatus
        {
            Registered,
            Playing,
            Paused,
            Finished
        }

        public EventStatus Status { get; set; }

        public ISoundContainer Sound { get; private set; }
        public ManagedAudioSource ManagedAudioSource { get; private set; }
        public SoundEventConfig Config { get; private set; }

        public void Initialize(ISoundContainer sound, ManagedAudioSource source, SoundEventConfig config)
        {
            Sound = sound;
            ManagedAudioSource = source;
            Status = EventStatus.Registered;
            Config = config;
        }

        public void Release()
        {

        }
    }
}
