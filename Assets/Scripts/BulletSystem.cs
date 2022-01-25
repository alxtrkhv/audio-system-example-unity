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
        private float bulletSpeed = 1f;

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
        }

        public Bullet ShootBullet(Vector3 startPosition, Vector3 direction, float maxDistance, UnitSide unitSide)
        {
            var bullet = bulletPool.Get();

            var ray = new Ray(startPosition, direction);
            var hasHit = Physics.Raycast(ray, out var hit, maxDistance, 1 << 6);

            var endPosition = hasHit ? hit.point : ray.GetPoint(maxDistance);

            bullet.Initialize(startPosition, endPosition, unitSide, hit.collider);
            bullet.transform.position = startPosition;

            bullet.gameObject.SetActive(true);
            activeBullets.Add(bullet);

            return bullet;
        }

        private void Update()
        {
            for (var i = 0; i < activeBullets.Count; i++) {
                var bullet = activeBullets[i];
                var bulletTransform = bullet.transform;

                if (bulletTransform.position != bullet.EndPosition) {
                    bulletTransform.position = Vector3.MoveTowards(bulletTransform.position, bullet.EndPosition, bulletSpeed * Time.deltaTime);
                    continue;
                }

                activeBullets.Remove(bullet);
                bulletPool.Release(bullet);

                if (bullet.Target != null && bullet.Target.sharedMaterial != null) {
                    impactSoundController.PlayImpactSound(bulletTransform.position, bullet.UnitSide, GetColliderMaterial(bullet.Target));
                }
            }
        }

        private static SurfaceType GetColliderMaterial(Collider collider)
        {
            return collider.sharedMaterial.name switch
            {
                "Wood" => SurfaceType.Wood,
                "Metal" => SurfaceType.Metal,
                _ => default
            };
        }
    }
}
