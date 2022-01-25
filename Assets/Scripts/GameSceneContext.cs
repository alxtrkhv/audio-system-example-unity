using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class GameSceneContext : MonoBehaviour
    {
        [SerializeField]
        private RangedWeaponImpactSoundController rangedWeaponImpactSoundController;

        private static RangedWeaponImpactSoundController RangedWeaponImpactSoundController;

        public void Start()
        {
            RangedWeaponImpactSoundController = Instantiate(rangedWeaponImpactSoundController, Vector3.zero, Quaternion.identity);
        }

        public static RangedWeaponImpactSoundController  GetRangedWeaponImpactSoundController()
        {
            return RangedWeaponImpactSoundController;
        }
    }
}
