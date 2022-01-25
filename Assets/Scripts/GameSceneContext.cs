using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class GameSceneContext : MonoBehaviour
    {
        [SerializeField]
        private RangedWeaponImpactSoundController rangedWeaponImpactSoundControllerPrefab;

        [SerializeField]
        private Application applicationPrefab;

        private static RangedWeaponImpactSoundController rangedWeaponImpactSoundController;

        public void Start()
        {
            if (ApplicationContext.GetApplication() == null) {
                Instantiate(applicationPrefab, Vector3.zero, Quaternion.identity);
            }

            rangedWeaponImpactSoundController = Instantiate(rangedWeaponImpactSoundControllerPrefab, Vector3.zero, Quaternion.identity);
        }

        public static RangedWeaponImpactSoundController GetRangedWeaponImpactSoundController()
        {
            return rangedWeaponImpactSoundController;
        }
    }
}
