using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class RangedAttack : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private float maxDistance;

        [SerializeField]
        private Vector3 heightOffset;

        [Header("References")]
        [SerializeField]
        private CharacterController characterController;

        private BulletSystem bulletSystem;
        private Unit unit;

        private void Start()
        {
            bulletSystem = GameSceneContext.GetBulletSystem();

            if (characterController != null) {
                heightOffset = characterController.center;
            }
        }

        public void Initialize(Unit unit)
        {
            this.unit = unit;
        }

        public void ShootStraight()
        {
            var tf = transform;

            var startPosition = tf.position + heightOffset;
            bulletSystem.ShootBullet(startPosition, tf.forward, maxDistance, unit.UnitSide);
        }
    }
}
