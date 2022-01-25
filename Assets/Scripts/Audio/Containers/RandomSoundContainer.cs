using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Random Sound Container", menuName = "Audio/Random Sound Container", order = 0)]
    public class RandomSoundContainer : BaseSoundContainer
    {
        [Header("Sources")]
        [SerializeField]
        private List<BaseSoundContainer> sources;

        public override Task Play(SoundEvent soundEvent)
        {
            var randomIndex = Random.Range(0, sources.Count);

            return sources[randomIndex].Play(soundEvent);
        }
    }
}
