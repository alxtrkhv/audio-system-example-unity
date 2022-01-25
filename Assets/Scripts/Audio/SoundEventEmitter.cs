using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SoundEventEmitter : MonoBehaviour
    {
        [SerializeField]
        private string soundName;

        private SoundPlayer soundPlayer;

        public string SoundName => soundName;

        private void OnEnable()
        {
            soundPlayer = ApplicationContext.GetSoundPlayer();
        }

        public void Emit()
        {
            soundPlayer.RegisterEmitter(this);
        }
    }
}
