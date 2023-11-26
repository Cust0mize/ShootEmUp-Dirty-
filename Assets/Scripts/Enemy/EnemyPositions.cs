using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ShootEmUp {
    public sealed class EnemyPositions : MonoBehaviour {
        [SerializeField] private Transform[] _attackPositions;
        [SerializeField] private Transform[] _spawnPositions;

        private readonly Dictionary<Transform, GameObject> _fillPositions = new();

        public Transform RandomSpawnPosition() {
            return GetRandomSpawnPoint();
        }

        public Transform GetRandomSpawnPoint() {
            var index = Random.Range(0, _spawnPositions.Length);
            return _spawnPositions[index];
        }

        public Transform RandomAttackPosition(GameObject enemy) {
            return RandomTransform(_attackPositions, enemy);
        }

        private Transform RandomTransform(Transform[] points, GameObject enemy) {
            int index;
            Transform targetPosition;
            int tryCount = 0;

            do {
                index = Random.Range(0, points.Length);
                targetPosition = points[index].transform;
                tryCount++;

                if (tryCount == 100) {
                    return null;
                }
            } while (_fillPositions.ContainsKey(targetPosition));

            _fillPositions.TryAdd(points[index], enemy);
            return targetPosition;
        }

        public void ReleasePosition(GameObject gameObject) {
            var positionKey = _fillPositions.FirstOrDefault(x => x.Value == gameObject).Key;
            if (positionKey != null) {
                _fillPositions.Remove(positionKey);
            }
        }
    }
}