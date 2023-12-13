using System.Collections;
using UnityEngine;
using ShootEmUp;

namespace Enemy{
    public class EnemyCooldownSpawner : MonoBehaviour, IGameStartListener, IResumeGameListener, IGamePauseListener,
        IFinishGameListener{
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private float _spawnCooldown = 1;

        public void OnStartGame(){
            StartCoroutine(CooldownSpawn());
        }

        public void OnPauseGame(){
            StopAllCoroutines();
        }

        public void OnResumeGame(){
            StartCoroutine(CooldownSpawn());
        }

        public void OnFinishGame(){
            StopAllCoroutines();
        }
        
        private IEnumerator CooldownSpawn(){
            while (true){
                _enemyManager.SpawnEnemy();
                yield return new WaitForSecondsRealtime(_spawnCooldown);
            }
        }
    }
}