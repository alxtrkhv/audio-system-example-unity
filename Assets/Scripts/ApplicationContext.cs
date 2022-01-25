using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Application Context", menuName = "Application/Application Context", order = 0)]
    public class ApplicationContext : ScriptableObject
    {
        [Header("Audio")]
        [SerializeField]
        private int audioSourcesPoolSize;

        [SerializeField]
        private ManagedAudioSource audioSourcePrefab;

        [SerializeField]
        private SoundPack mainSoundPack;

        private static SoundPlayer soundPlayer;

        public void Init()
        {
            InitializeSoundPlayer();
        }

        private void InitializeSoundPlayer()
        {
            var config = new SoundPlayerConfig(
                sounds: mainSoundPack.Sounds,
                poolSize: audioSourcesPoolSize,
                audioSourcePrefab: audioSourcePrefab
            );

            soundPlayer = new SoundPlayer(config);
        }

        public static SoundPlayer GetSoundPlayer()
        {
            return soundPlayer;
        }
    }
}
