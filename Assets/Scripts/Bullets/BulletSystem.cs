using UnityEngine;

namespace ShootEmUp {
    public sealed class BulletSystem : MonoBehaviour {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private BulletPool _bulletsPool;

        public void FlyBullet(BulletConfig bulletConfig, Vector2 position, Vector2 direction) {
            Bullet bullet = _bulletsPool.GetOrCreateBullet(_worldTransform);

            bullet.Init(bulletConfig);
            bullet.SetPosition(position);
            bullet.SetVelosity(direction);

            if (_bulletsPool.ActiveBulletsAdd(bullet)) {
                bullet.OnCollisionEntered += RemoveBullet;
            }
        }

        private void RemoveBullet(Bullet bullet) {
            if (_bulletsPool.ActiveBulletsRemove(bullet)) {
                bullet.OnCollisionEntered -= RemoveBullet;
                bullet.transform.SetParent(_bulletsPool.Container);
                _bulletsPool.PoolEnqueue(bullet);
            }
        }
    }
}
