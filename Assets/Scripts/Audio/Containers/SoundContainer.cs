using System.Threading.Tasks;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Sound Container", menuName = "Audio/Sound Container", order = 0)]
    public class SoundContainer : BaseSoundContainer
    {
        [Header("Sources")]
        [SerializeField]
        private AudioClip audioClip;

        public override Task Play(SoundEvent soundEvent)
        {
            var audioSource = soundEvent.ManagedAudioSource.AudioSource;

            audioSource.clip = audioClip;
            audioSource.Play();

            return Task.Factory.StartNew(async () =>
            {
                while (audioSource.isPlaying) {
                    await Task.Delay(100);
                }
            });
        }
    }
}
