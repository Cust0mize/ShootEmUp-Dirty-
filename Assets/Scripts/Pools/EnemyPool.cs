using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class EnemyPool : MonoBehaviour {
        [SerializeField] private EnemyInstaller _enemyInstaller;
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _pullSize = 7;

        private readonly Queue<GameObject> _enemyPool = new();
        public event Action<GameObject> OnCreateEnemy;

        private void Awake() {
            for (int i = 0; i < _pullSize; i++) {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
                OnCreateEnemy?.Invoke(enemy);
            }
        }

        public GameObject GetEnemyFromPool() {
            if (!_enemyPool.TryDequeue(out var enemy)) {
                return null;
            }
            return _enemyInstaller.EnemyInstance(enemy);
        }

        public void UnspawnEnemy(GameObject enemy) {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}