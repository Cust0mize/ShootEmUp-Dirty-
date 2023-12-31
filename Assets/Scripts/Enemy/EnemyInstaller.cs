﻿using UnityEngine;

namespace ShootEmUp {
    public class EnemyInstaller : MonoBehaviour {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _characterGO;
        [SerializeField] private Transform _worldTransform;

        public GameObject EnemyInstance(GameObject enemy) {
            enemy.transform.SetParent(_worldTransform);
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition(enemy);
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_characterGO.GetComponent<HitPointsComponent>());
            return enemy;
        }
    }
}