using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp{
    public sealed class EnemyMoveAgent : MonoBehaviour, IRebootComponent, IFixedUpdateListener{
        [SerializeField] private MoveComponent _moveComponent;

        public event Action OnReached;
        private Vector2 _destination;
        private bool _isReached;
        private const float MinimalDistance = 0.25f;

        public void SetDestination(Vector2 endPoint){
            _destination = endPoint;
        }

        public void Reboot(){
            _isReached = false;
            transform.position = Vector3.zero;
        }

        public void OnFixedUpdateGame(float fixedDeltaTime){
            if (_isReached || transform.position == Vector3.zero){
                return;
            }

            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= MinimalDistance){
                _isReached = true;
                OnReached?.Invoke();
                return;
            }

            _moveComponent.MoveByRigidbodyVelocity(vector.normalized);
        }
    }
}