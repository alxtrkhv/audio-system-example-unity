using System;
using System.Collections;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [RequireComponent(typeof(Unit))]
    public class AttackRepeater : MonoBehaviour
    {
        [SerializeField]
        private float interval;

        [SerializeField]
        private float initialDelay;

        private Unit unit;

        private void OnEnable()
        {
            unit = GetComponent<Unit>();

            StartCoroutine(MainCoroutine());
        }

        private IEnumerator MainCoroutine()
        {
            var delayInstruction = new WaitForSeconds(initialDelay);
            var intervalInstruction = new WaitForSeconds(interval);

            yield return delayInstruction;

            while (true) {
                unit.Attack();
                yield return intervalInstruction;
            }
        }
    }
}
