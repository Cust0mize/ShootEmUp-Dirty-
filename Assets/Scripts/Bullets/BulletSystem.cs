using UnityEngine;

namespace ShootEmUp {
    public sealed class BulletSystem : MonoBehaviour {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private BulletPool _bulletsPool;

        public void FlyBullet(BulletConfig bulletConfig, Vector2 position, Vector2 direction) {
            if (_bulletsPool.PoolTryDequeue(out var bullet)) {
                bullet.transform.SetParent(_worldTransform);
            }
            else {
                bullet = _bulletsPool.CreateNewBullet(_worldTransform);
            }
            bullet.Init(bulletConfig);
            bullet.SetPosition(position);
            bullet.SetVelosity(direction);

            if (_bulletsPool.ActiveBulletsAdd(bullet)) {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet) {
            if (_bulletsPool.ActiveBulletsRemove(bullet)) {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.transform.SetParent(_bulletsPool.Container);
                _bulletsPool.PoolEnqueue(bullet);
            }
        }
    }
}
