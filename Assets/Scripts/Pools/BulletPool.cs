using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public class BulletPool : MonoBehaviour {
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Bullet Prefab { get; private set; }
        [SerializeField] private int _initialCount = 10;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly Queue<Bullet> _bulletPool = new();

        private void Awake() {
            for (int i = 0; i < _initialCount; i++) {
                _bulletPool.Enqueue(Instantiate(Prefab, Container));
            }
        }

        public Bullet CreateNewBullet(Transform container) {
            return Instantiate(Prefab, container);
        }

        public bool ActiveBulletsAdd(Bullet bullet) {
            return _activeBullets.Add(bullet);
        }

        public bool ActiveBulletsRemove(Bullet bullet) {
            return _activeBullets.Remove(bullet);
        }

        public bool PoolTryDequeue(out Bullet bullet) {
            return _bulletPool.TryDequeue(out bullet);
        }

        public void PoolEnqueue(Bullet bullet) {
            _bulletPool.Enqueue(bullet);
        }
    }
}


namespace ShootEmUp {
    public sealed class BulletSystefm : MonoBehaviour {
        [SerializeField]
        private int initialCount = 50;

        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;

        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        private void FixedUpdate() {
            this.m_cache.Clear();
            this.m_cache.AddRange(this.m_activeBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++) {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position)) {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args) {
            if (this.m_bulletPool.TryDequeue(out var bullet)) {
                bullet.transform.SetParent(this.worldTransform);
            }
            else {
                bullet = Instantiate(this.prefab, this.worldTransform);
            }

            bullet.SetPosition(args.position);

            if (this.m_activeBullets.Add(bullet)) {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet) {
            if (this.m_activeBullets.Remove(bullet)) {
                bullet.OnCollisionEntered -= this.OnBulletCollision;
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }

        public struct Args {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}