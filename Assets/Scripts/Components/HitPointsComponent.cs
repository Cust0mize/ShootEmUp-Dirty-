using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class HitPointsComponent : MonoBehaviour {
        public event Action<GameObject> HpEmpty;

        [SerializeField] private int _hitPoints = 5;
        private int _startHitPointsValue;

        private void Start() {
            _startHitPointsValue = _hitPoints;
        }

        public bool IsHitPointsExists() {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage) {
            _hitPoints -= damage;
            if (_hitPoints <= 0) {
                HpEmpty?.Invoke(gameObject);
            }
        }

        public void SetDefaultValue() {
            _hitPoints = _startHitPointsValue;
        }
    }
}