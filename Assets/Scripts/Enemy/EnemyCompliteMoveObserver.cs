using ShootEmUp;
using UnityEngine;

namespace Controllers {
    public class EnemyCompliteMoveObserver : MonoBehaviour {
        [SerializeField] private EnemyAttackAgent _enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent _enemyMoveAgent;

        private void Start() {
            _enemyMoveAgent.OnReached += _enemyAttackAgent.StartAttack;
        }

        private void OnDestroy() {
            _enemyMoveAgent.OnReached -= _enemyAttackAgent.StartAttack;
        }
    }
}