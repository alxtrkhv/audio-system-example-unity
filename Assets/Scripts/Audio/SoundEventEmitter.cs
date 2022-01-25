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

        public void Emit(SoundEventConfig config = default)
        {
            soundPlayer.RegisterEmitter(this, config, Vector3.zero);
        }

        public void EmitAtLocalPosition(Vector3 position, SoundEventConfig config = default)
        {
            soundPlayer.RegisterEmitter(this, config, position);
        }
    }
}
