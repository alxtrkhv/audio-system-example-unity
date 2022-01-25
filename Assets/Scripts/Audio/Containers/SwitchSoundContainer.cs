using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Switch Sound Container", menuName = "Audio/Switch Sound Container", order = 0)]
    public class SwitchSoundContainer : BaseSoundContainer
    {
        [Header("Sources")]
        [SerializeField]
        private List<BaseSoundContainer> sources;
    }
}
