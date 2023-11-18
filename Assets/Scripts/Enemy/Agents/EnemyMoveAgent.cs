using System;
using UnityEngine;

namespace ShootEmUp {
    public sealed class EnemyMoveAgent : MonoBehaviour, IRebootComponent {
        [SerializeField] private MoveComponent moveComponent;

        public event Action OnReached;
        private Vector2 _destination;
        private bool _isReached;
        private float _minimalDistance = 0.25f;

        public void SetDestination(Vector2 endPoint) {
            _destination = endPoint;
        }

        public void SetDefaultValue() {
            _isReached = false;
        }

        private void FixedUpdate() {
            if (_isReached) {
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