using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp{
    public sealed class EnemyPool : MonoBehaviour{
        [SerializeField] private EnemyInstaller _enemyInstaller;
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _pullSize = 7;

        private readonly Queue<GameObject> _enemyPool = new();

        private void Awake(){
            for (int i = 0; i < _pullSize; i++){
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public bool TryGetEnemy(out GameObject enemy){
            if (_enemyPool.TryDequeue(out enemy)){
                enemy = Instantiate(_prefab, _container);
                _enemyInstaller.InstallEnemy(enemy);
                return true;
            }

            return false;
        }

        public void UnSpawnEnemy(GameObject enemy){
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}