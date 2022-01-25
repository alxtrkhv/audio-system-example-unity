using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Game Scene Context", menuName = "Application/Game Scene Context", order = 0)]
    public class GameSceneContext : ScriptableObject
    {
        [SerializeField]
        private RangedWeaponImpactSoundController rangedWeaponImpactSoundControllerPrefab;

        [SerializeField]
        private Application applicationPrefab;

        [SerializeField]
        private BulletSystem bulletSystemPrefab;

        private static RangedWeaponImpactSoundController rangedWeaponImpactSoundController;
        private static BulletSystem bulletSystem;

        public void Initialize()
        {
            if (ApplicationContext.GetApplication() == null) {
                Instantiate(applicationPrefab, Vector3.zero, Quaternion.identity);
            }

            rangedWeaponImpactSoundController = Instantiate(rangedWeaponImpactSoundControllerPrefab, Vector3.zero, Quaternion.identity);
            bulletSystem = Instantiate(bulletSystemPrefab, Vector3.zero, Quaternion.identity);
        }

        public static RangedWeaponImpactSoundController GetRangedWeaponImpactSoundController()
        {
            return rangedWeaponImpactSoundController;
        }

        public static BulletSystem GetBulletSystem()
        {
            return bulletSystem;
        }
    }
}
