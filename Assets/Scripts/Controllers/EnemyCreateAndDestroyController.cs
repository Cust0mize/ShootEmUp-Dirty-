using System.Linq;
using UnityEngine;

namespace ShootEmUp {
    public class EnemyCreateAndDestroyController : MonoBehaviour {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private GameManager _gameManager;
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
            var enemy = _enemyPool.GetEnemyFromPool();
            _gameManager.AddListners(enemy.GetComponents<IGameLisnter>().ToHashSet());
            return enemy;
        }

        private void EnemyDestroy(GameObject enemy) {
            enemy.GetComponent<EnemyContainer>().SetDefaultValue();
            _enemyPositions.ReleasePosition(enemy);
            _enemyPool.UnspawnEnemy(enemy);
        }
    }
}