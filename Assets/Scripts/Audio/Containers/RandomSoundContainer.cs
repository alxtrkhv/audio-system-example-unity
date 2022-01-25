using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class RandomSoundContainer : BaseSoundContainer
    {
        [Header("Source")]
        [SerializeField]
        private List<ISound> sources;

        public override Task Play(AudioSource audioSource)
        {
            var randomIndex = Random.Range(0, sources.Count);

            return sources[randomIndex].Play(audioSource);
        }
    }
}
