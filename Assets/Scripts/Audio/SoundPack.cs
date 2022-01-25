using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Sound Pack", menuName = "Audio/Sound Pack", order = 0)]
    public class SoundPack : ScriptableObject
    {
        [SerializeField]
        private List<BaseSoundContainer> sounds;

        public IReadOnlyCollection<ISound> Sounds => sounds;
    }
}
