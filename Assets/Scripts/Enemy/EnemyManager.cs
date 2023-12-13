using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp{
    public sealed class EnemyManager : MonoBehaviour{
        [SerializeField] private EnemyCreateAndDestroyController _enemyCreateAndDestroyController;
        private readonly HashSet<GameObject> _activeEnemies = new();

        public void SpawnEnemy(){
            if (_enemyCreateAndDestroyController.TryCreateEnemy(out GameObject enemy)){
                if (_activeEnemies.Add(enemy)){
                    enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                }
            }
        }

        private void OnDestroyed(GameObject enemy){
            if (_activeEnemies.Remove(enemy)){
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
                _enemyCreateAndDestroyController.EnemyDestroy(enemy);
            }
        }
    }
}