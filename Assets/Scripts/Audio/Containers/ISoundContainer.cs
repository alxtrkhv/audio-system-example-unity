using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public interface ISoundContainer : IReadOnlyList<AudioClip>
    {
        public string Id { get; }
        public SoundConfig Config { get; }
        public SoundContainerType ContainerType { get; }
    }
}
