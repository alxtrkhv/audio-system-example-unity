using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class RangedWeaponImpactSoundController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private string surfaceSoundSwitchName;

        [Header("References")]
        [SerializeField]
        private SoundEventEmitter playerEmitter;

        [SerializeField]
        private SoundEventEmitter allyEmitter;

        [SerializeField]
        private SoundEventEmitter enemyEmitter;

        private Dictionary<int, SoundEventConfig> soundEventConfigs;

        private void Awake()
        {
            InitializeSoundConfigs();
        }

        public void PlayImpactSound(Vector3 position, UnitSide unitSide, SurfaceType surfaceType)
        {
            var emitter = GetEmitter(unitSide);

            emitter.EmitAtLocalPosition(position, soundEventConfigs[(int)surfaceType]);
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

        private void InitializeSoundConfigs()
        {
            var woodIndex = (int)SurfaceType.Wood;
            var metalIndex = (int)SurfaceType.Metal;

            soundEventConfigs = new Dictionary<int, SoundEventConfig>
            {
                [woodIndex] = new SoundEventConfig(new Dictionary<string, int>
                                { [surfaceSoundSwitchName] = woodIndex }),

                [metalIndex] = new SoundEventConfig(new Dictionary<string, int>
                                { [surfaceSoundSwitchName] = metalIndex }),
            };
        }
    }
}
