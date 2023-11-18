using UnityEngine;

namespace ShootEmUp {
    public class EnemyCreateAndDestroyController : MonoBehaviour {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private EnemyPool _enemyPool;

        private void Start() {
            _enemyManager.EnemyOnDestroy += EnemyDestroy;
            _enemyManager.EnemyOnCreate += EnemyCreate;
        }

        private void OnDestroy() {
            _enemyManager.EnemyOnDestroy -= EnemyDestroy;
            _enemyManager.EnemyOnCreate -= EnemyCreate;
        }

        private GameObject EnemyCreate() {
            return _enemyPool.GetEnemyFromPool();
        }

        private void EnemyDestroy(GameObject enemy) {
            enemy.GetComponent<EnemyContainer>().SetDefaultValue();
            _enemyPositions.ReleasePosition(enemy);
            _enemyPool.UnspawnEnemy(enemy);
        }
    }
}