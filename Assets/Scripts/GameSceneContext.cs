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

        public void Initialize(Transform transform)
        {
            if (ApplicationContext.GetApplication() == null) {
                Instantiate(applicationPrefab, transform);
            }

            rangedWeaponImpactSoundController = Instantiate(rangedWeaponImpactSoundControllerPrefab, transform);
            bulletSystem = Instantiate(bulletSystemPrefab, transform);
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
