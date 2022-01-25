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

        public ISound Sound { get; private set; }
        public AudioSource AudioSource { get; private set; }
        public EventStatus Status { get; private set; }

        public void Initialize(ISound sound, AudioSource source)
        {
            Sound = sound;
            AudioSource = source;
            Status = EventStatus.Registered;
        }

        public async Task Play()
        {
            Status = EventStatus.Playing;
            await Sound.Play(AudioSource);
            Status = EventStatus.Finished;
        }
    }
}
