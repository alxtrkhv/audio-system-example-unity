using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Sound Container", menuName = "Audio/Sound Container", order = 0)]
    public class SoundContainer : BaseSoundContainer
    {
        [Header("Sources")]
        [SerializeField]
        private AudioClip audioClip;

        public override void Play(AudioSource audioSource)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
