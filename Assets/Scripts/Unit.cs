using System;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class Unit : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private UnitSide unitSide;

        [Header("References")]
        [SerializeField]
        private RangedAttack rangedAttack;

        public UnitSide UnitSide => unitSide;

        private void Start()
        {
            rangedAttack.Initialize(this);
        }

        public void Attack()
        {
            rangedAttack.ShootStraight();
        }
    }
}
