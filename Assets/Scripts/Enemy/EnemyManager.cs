using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class EnemyManager : MonoBehaviour, IGameStartListner, IFinishGameListner, IGamePauseListner, IResumeGameListner {
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private int _spawnTime = 1;

        private readonly HashSet<GameObject> _activeEnemies = new();

        public event Action<GameObject> EnemyOnDestroy;
        public delegate GameObject FireHandler();
        public event FireHandler EnemyOnCreate;

        public void OnStartGame() {
            StartCoroutine(EnemyCreated());
        }

        public void OnResumeGame() {
            StartCoroutine(EnemyCreated());
        }

        public void OnPauseGame() {
            StopAllCoroutines();
        }

        public void FinishGame() {
            StopAllCoroutines();
        }

        private IEnumerator EnemyCreated() {
            while (true) {
                yield return new WaitForSeconds(_spawnTime);
                var enemy = EnemyOnCreate?.Invoke();
                if (enemy != null) {
                    if (_activeEnemies.Add(enemy)) {
                        enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy) {
            if (_activeEnemies.Remove(enemy)) {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
                EnemyOnDestroy?.Invoke(enemy);
            }
        }
    }
}