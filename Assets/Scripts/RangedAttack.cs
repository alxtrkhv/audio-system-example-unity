using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class RangedAttack : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private float maxDistance;

        [Header("References")]
        [SerializeField]
        private CharacterController characterController;

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
            var tf = transform;

            var startPosition = tf.position + characterController.center;
            bulletSystem.ShotBullet(startPosition, tf.forward, maxDistance, unit.UnitSide);
        }
    }
}
