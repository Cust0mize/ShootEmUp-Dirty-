using UnityEngine;

namespace ShootEmUp {
    public class EnemyCreateAndDestroyController : MonoBehaviour {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private EnemyPool _enemyPool;

        public bool TryCreateEnemy(out GameObject enemy) {
            if (_enemyPool.TryGetEnemy(out enemy)) {
                _gameManager.AddListener(enemy.GetComponents<IGameListener>());
                return true;
            }

            return false;
        }
        
        public void EnemyDestroy(GameObject enemy) {
            enemy.GetComponent<EnemyContainer>().RebootComponents();
            _enemyPositions.ReleasePosition(enemy);
            _enemyPool.UnSpawnEnemy(enemy);
        }
    }
}