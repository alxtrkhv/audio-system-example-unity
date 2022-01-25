using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public interface ISound
    {
        public string Id { get; }
        public SoundConfig Config { get; }

        Task Play(SoundEvent soundEvent);
    }
}
