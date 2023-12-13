using UnityEngine;

namespace ShootEmUp{
    public sealed class EnemyAttackAgent : MonoBehaviour, IRebootComponent, IUpdateListener{
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private float _countdown;
        private BulletSystem _bulletSystem;

        private HitPointsComponent _target;
        private float _currentTime;
        private bool _canAttack;

        private void Start(){
            _bulletSystem = FindObjectOfType<BulletSystem>();
        }

        public void OnUpdateGame(float deltaTime){
            if (!_canAttack || !_target.IsHitPointsExists()){
                return;
            }

            _currentTime -= deltaTime;
            if (_currentTime <= 0){
                Fire();
                _currentTime += _countdown;
            }
        }

        public void SetTarget(HitPointsComponent target){
            if (!target){
                return;
            }

            _target = target;
        }

        public void StartAttack(){
            _canAttack = true;
        }

        public void Reboot(){
            _canAttack = false;
            _currentTime = 0;
        }

        private void Fire(){
            var vector = (Vector2)_target.transform.position - _weaponComponent.Position;
            var direction = vector.normalized;
            _bulletSystem.FlyBullet(_weaponComponent.BulletConfig, _weaponComponent.Position, direction);
        }
    }
}