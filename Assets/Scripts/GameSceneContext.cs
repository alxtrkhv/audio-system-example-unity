using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class GameSceneContext : MonoBehaviour
    {
        [SerializeField]
        private RangedWeaponImpactSoundController rangedWeaponImpactSoundControllerPrefab;

        [SerializeField]
        private Application applicationPrefab;

        private static RangedWeaponImpactSoundController RangedWeaponImpactSoundController;

        public void Start()
        {
            if (ApplicationContext.GetApplication() == null) {
                Instantiate(applicationPrefab, Vector3.zero, Quaternion.identity);
            }

            RangedWeaponImpactSoundController = Instantiate(rangedWeaponImpactSoundControllerPrefab, Vector3.zero, Quaternion.identity);
        }

        public static RangedWeaponImpactSoundController  GetRangedWeaponImpactSoundController()
        {
            return RangedWeaponImpactSoundController;
        }
    }
}
