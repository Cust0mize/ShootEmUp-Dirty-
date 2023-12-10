using UnityEngine;

namespace ShootEmUp {
    public sealed class EnemyAttackAgent : MonoBehaviour, IRebootComponent, IGamePauseListner, IResumeGameListner, IFinishGameListner, IFixedUpdateListner {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private float _countdown;
        private BulletSystem _bulletSystem;

        private HitPointsComponent _target;
        private float _currentTime;
        private bool _canAttack;

        public bool IsEnable => _isEnable;
        private bool _isEnable;

        private void Start() {
            _bulletSystem = FindObjectOfType<BulletSystem>();
        }

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

        public void FinishGame() {
            _isEnable = false;
        }

        public void OnResumeGame() {
            _isEnable = true;
        }

        public void OnPauseGame() {
            _isEnable = false;
        }

        public void FixedUpdateGame(float time) {
            if (!_isEnable) {
                return;
            }

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
            var vector = (Vector2)_target.transform.position - _weaponComponent.Position;
            var direction = vector.normalized;
            _bulletSystem.FlyBullet(_weaponComponent.BulletConfig, _weaponComponent.Position, direction);
        }
    }
}