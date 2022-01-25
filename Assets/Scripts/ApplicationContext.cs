using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Application Context", menuName = "Application/Application Context", order = 0)]
    public class ApplicationContext : ScriptableObject
    {
        [SerializeField]
        private SoundPack mainSoundPack;

        private static SoundPlayer soundPlayer;

        public void Init()
        {
            var sounds = mainSoundPack.Sounds;
            soundPlayer = new SoundPlayer(sounds);
        }

        public static SoundPlayer GetSoundPlayer()
        {
            return soundPlayer;
        }
    }
}
