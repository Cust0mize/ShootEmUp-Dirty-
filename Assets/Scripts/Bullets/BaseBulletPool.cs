using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public abstract class BaseBulletPool : MonoBehaviour {
        [SerializeField] private GameObjectCreator _gameObjectCreator;
        public abstract PoolType PoolType { get; }
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Bullet Prefab { get; private set; }
        [SerializeField] private int _initialCount = 10;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly Queue<Bullet> _bulletPool = new();

        private void Awake() {
            _gameObjectCreator.CreateObjectAndAddPool(_bulletPool, Prefab, _initialCount, Container);
        }

        public Bullet CreateBullet(Bullet prefab, Transform container) {
            return Instantiate(prefab, container);
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

public enum PoolType {
    Player,
    Enemy
}