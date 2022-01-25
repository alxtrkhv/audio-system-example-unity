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

        private Vector3 offset = new Vector3(0f, 1f, 1f);

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
            var startPosition = transform.position + offset;
            bulletSystem.ShotBullet(startPosition, transform.forward, maxDistance, unit.UnitSide);
        }
    }
}
