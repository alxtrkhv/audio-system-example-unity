using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class RangedAttack : MonoBehaviour
    {
        [SerializeField]
        private float maxDistance;

        private BulletSystem bulletSystem;
        private Unit unit;

        private void Start()
        {
            bulletSystem = GameSceneContext.GetBulletSystem();
        }

        public void Initialize(Unit unit)
        {
            this.unit = unit;
        }

        public void ShotStraight()
        {
            bulletSystem.ShotBullet(transform.position, transform.forward, maxDistance, unit.UnitSide);
        }
    }
}
