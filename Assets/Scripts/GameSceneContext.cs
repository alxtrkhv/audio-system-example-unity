using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class GameSceneContext : MonoBehaviour
    {
        [SerializeField]
        private RangedWeaponImpactSoundController rangedWeaponImpactSoundControllerPrefab;

        [SerializeField]
        private Application applicationPrefab;

        [SerializeField]
        private BulletSystem bulletSystemPrefab;

        private static RangedWeaponImpactSoundController rangedWeaponImpactSoundController;
        private static BulletSystem bulletSystem;

        public void Start()
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
    }
}
