using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public sealed class EnemyPool : MonoBehaviour {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions _enemyPositions;

        [SerializeField] private GameObject _character;

        [SerializeField] private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform _container;

        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> _enemyPool = new();

        private void Awake() {
            for (var i = 0; i < 7; i++) {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy() {
            if (!_enemyPool.TryDequeue(out var enemy)) {
                return null;
            }

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.GetRandomSpawnPoint();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition(enemy);
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character.GetComponent<HitPointsComponent>());
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy) {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}