using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public sealed class BulletSystem : MonoBehaviour {
        private Dictionary<PoolType, BaseBulletPool> _bulletsPool = new Dictionary<PoolType, BaseBulletPool>();
        [SerializeField] private Transform _worldTransform;

        private void Awake() {
            var bulletsPools = FindObjectsOfType<BaseBulletPool>();

            foreach (var item in bulletsPools) {
                _bulletsPool.Add(item.PoolType, item);
            }
        }

        public void FlyBullet(Bullet bulletElement, Vector2 position, Vector2 direction) {
            if (_bulletsPool[bulletElement.PoolType].PoolTryDequeue(out var bullet)) {
                bullet.transform.SetParent(_worldTransform);
            }
            else {
                bullet = _bulletsPool[bulletElement.PoolType].CreateBullet(bulletElement, _worldTransform);
            }

            bullet.SetPosition(position);
            bullet.SetVelosity(direction);

            if (_bulletsPool[bulletElement.PoolType].ActiveBulletsAdd(bullet)) {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet) {
            if (_bulletsPool[bullet.PoolType].ActiveBulletsRemove(bullet)) {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.transform.SetParent(_bulletsPool[bullet.PoolType].Container);
                _bulletsPool[bullet.PoolType].PoolEnqueue(bullet);
            }
        }
    }
}
