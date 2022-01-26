using System.Collections;
using System.Collections.Generic;
using Alxtrkhv.AudioSystem;
using UnityEngine;

public class DemoGame : MonoBehaviour
{
    [SerializeField]
    private List<Unit> enemies;

    [SerializeField]
    private List<Unit> allies;

    [SerializeField]
    private float initialDelay;

    [SerializeField]
    private float shortIntervalTime;

    [SerializeField]
    private float longIntervalTime;

    private void OnEnable()
    {
        StartCoroutine(MainCoroutine());
    }

    private IEnumerator MainCoroutine()
    {
        var shortInterval = new WaitForSeconds(shortIntervalTime);
        var longInterval = new WaitForSeconds(longIntervalTime);

        yield return new WaitForSeconds(initialDelay);

        while (true) {
            allies[0].Attack();
            yield return shortInterval;

            allies[1].Attack();
            yield return shortInterval;

            allies[0].Attack();
            enemies[1].Attack();
            yield return shortInterval;

            allies[1].Attack();
            enemies[0].Attack();
            yield return longInterval;
        }
    }
}
