using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class BulletSystem : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private int poolSize = 50;

        [SerializeField]
        private float bulletLerpRate = 0.2f;

        [Header("Prefabs")]
        [SerializeField]
        private Bullet bulletPrefab;

        private IObjectPool<Bullet> bulletPool;

        private List<Bullet> activeBullets;

        private Coroutine coroutine;

        private RangedWeaponImpactSoundController impactSoundController;

        public void Start()
        {
            bulletPool = new MonoBehaviourPool<Bullet>(
                size: poolSize,
                prefab: bulletPrefab,
                parentTransform: transform
            );

            activeBullets = new List<Bullet>(poolSize);
            impactSoundController = GameSceneContext.GetRangedWeaponImpactSoundController();

            coroutine = StartCoroutine(BulletMovementCoroutine());
        }

        public Bullet ShotBullet(Vector3 startPosition, Vector3 endPosition, UnitSide unitSide)
        {
            var bullet = bulletPool.Get();

            bullet.Initialize(startPosition, endPosition, unitSide);
            bullet.transform.position = startPosition;

            bullet.gameObject.SetActive(true);
            activeBullets.Add(bullet);

            return bullet;
        }

        private IEnumerator BulletMovementCoroutine()
        {
            while (true) {
                foreach (var bullet in activeBullets) {
                    var bulletTransform = bullet.transform;

                    if (bulletTransform.position != bullet.EndPosition) {
                        var newPosition = Vector3.Lerp(bulletTransform.position, bullet.EndPosition, bulletLerpRate * Time.deltaTime);
                        bulletTransform.Translate(newPosition);
                        continue;
                    }

                    activeBullets.Remove(bullet);
                    bulletPool.Release(bullet);

                    impactSoundController.PlayImpactSound(bulletTransform.position, bullet.UnitSide, SurfaceType.Wood);
                }
                yield return null;
            }
        }
    }
}
