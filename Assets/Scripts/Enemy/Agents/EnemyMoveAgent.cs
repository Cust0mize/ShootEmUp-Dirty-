using System;
using UnityEngine;

namespace ShootEmUp {
    public sealed class EnemyMoveAgent : MonoBehaviour, IRebootComponent, IFixedUpdateListner {
        [SerializeField] private MoveComponent moveComponent;

        public event Action OnReached;
        private Vector2 _destination;
        private bool _isReached;
        private float _minimalDistance = 0.25f;

        public bool IsEnable => _isEnable;
        private bool _isEnable = true;

        public void SetDestination(Vector2 endPoint) {
            _destination = endPoint;
        }

        public void SetDefaultValue() {
            _isReached = false;
        }

        public void FixedUpdateGame(float time) {
            if (_isReached || !IsEnable) {
                return;
            }

            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= _minimalDistance) {
                _isReached = true;
                OnReached?.Invoke();
                return;
            }

            moveComponent.MoveByRigidbodyVelocity(vector.normalized);
        }
    }
}