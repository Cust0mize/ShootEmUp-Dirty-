using UnityEngine;

namespace ShootEmUp {
    public sealed class EnemyAttackAgent : MonoBehaviour, IRebootComponent {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private float _countdown;
        public delegate void FireHandler(BulletConfig bulletConfig, Vector2 position, Vector2 direction);
        public event FireHandler OnFire;

        private HitPointsComponent _target;
        private float _currentTime;
        private bool _canAttack;

        public void SetTarget(HitPointsComponent target) {
            if (!target) {
                return;
            }
            _target = target;
        }

        public void StartAttack() {
            _canAttack = true;
        }

        public void SetDefaultValue() {
            _canAttack = false;
            _currentTime = 0;
        }

        private void FixedUpdate() {
            if (!_canAttack) {
                return;
            }

            if (!_target.IsHitPointsExists()) {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0) {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire() {
            OnFire?.Invoke(_weaponComponent.BulletConfig, _weaponComponent.Position, _target.transform.position);
        }
    }
}