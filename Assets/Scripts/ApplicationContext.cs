using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Application Context", menuName = "Application/Application Context", order = 0)]
    public class ApplicationContext : ScriptableObject
    {
        private static Application application;
        private static SoundPlayer soundPlayer;
        private static Game game;

        [Header("Audio")]
        [SerializeField]
        private int audioSourcesPoolSize;

        [SerializeField]
        private ManagedAudioSource audioSourcePrefab;

        [SerializeField]
        private SoundPack mainSoundPack;

        public void Init(Application applicationInstance)
        {
            application = applicationInstance;
            InitializeSoundPlayer();
            InitializeGame();
        }

        public static Application GetApplication()
        {
            return application;
        }

        public static SoundPlayer GetSoundPlayer()
        {
            return soundPlayer;
        }

        public Game GetGame()
        {
            return game;
        }

        private void InitializeSoundPlayer()
        {
            var config = new SoundPlayerConfig(
                audioSourcesPoolSize: audioSourcesPoolSize,
                sounds: mainSoundPack.Sounds,
                audioSourcePrefab: audioSourcePrefab,
                monoBehaviour: application
            );

            soundPlayer = new SoundPlayer(config);
        }

        private void InitializeGame()
        {
            game = new Game();
        }
    }
}
