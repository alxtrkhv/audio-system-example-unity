using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public interface ISoundContainer : IReadOnlyList<SoundContainerMember>
    {
        public string Id { get; }
        public SoundConfig Config { get; }
        public SoundContainerType ContainerType { get; }
    }
}
