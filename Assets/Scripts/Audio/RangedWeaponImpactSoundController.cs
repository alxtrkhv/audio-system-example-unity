using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class RangedWeaponImpactSoundController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private SoundEventEmitter playerEmitter;

        [SerializeField]
        private SoundEventEmitter allyEmitter;

        [SerializeField]
        private SoundEventEmitter enemyEmitter;

        public void PlayImpactSound(Vector3 position, UnitSide unitSide, SurfaceType surfaceType)
        {
            var emitter = GetEmitter(unitSide);

            emitter.EmitAtLocalPosition(position, new SoundEventConfig((int)surfaceType));
        }

        private SoundEventEmitter GetEmitter(UnitSide unitSide)
        {
            return unitSide switch
            {
                UnitSide.Ally => allyEmitter,
                UnitSide.Enemy => enemyEmitter,
                UnitSide.Player => playerEmitter,
                _ => null
            };
        }
    }
}
