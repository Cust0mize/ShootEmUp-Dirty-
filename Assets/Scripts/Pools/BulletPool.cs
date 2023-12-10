using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public class BulletPool : MonoBehaviour {
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Bullet Prefab { get; private set; }
        [SerializeField] private int _initialCount = 10;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly Queue<Bullet> _bulletPool = new();
        public event Action<Bullet> OnBulletCreate;

        private void Awake() {
            for (int i = 0; i < _initialCount; i++) {
                var bullet = Instantiate(Prefab, Container);
                _bulletPool.Enqueue(bullet);
                OnBulletCreate?.Invoke(bullet);
            }
        }

        public Bullet GetOrCreateBullet(Transform container) {
            if (!_bulletPool.TryDequeue(out var bullet)) {
                bullet = Instantiate(Prefab, container);
                OnBulletCreate?.Invoke(bullet);
            }
            bullet.transform.SetParent(container);
            return bullet;
        }

        public bool ActiveBulletsAdd(Bullet bullet) {
            return _activeBullets.Add(bullet);
        }

        public bool ActiveBulletsRemove(Bullet bullet) {
            return _activeBullets.Remove(bullet);
        }

        public void PoolEnqueue(Bullet bullet) {
            _bulletPool.Enqueue(bullet);
        }
    }
}