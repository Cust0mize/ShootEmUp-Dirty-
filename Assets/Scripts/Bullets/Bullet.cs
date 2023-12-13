using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class Bullet : MonoBehaviour, IDestroyableOnBorder, IGamePauseListener, IResumeGameListener, IFinishGameListener {
        public event Action<Bullet> OnCollisionEntered;

        private bool _isPlayer;
        private int _damage;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private float _speedMove;
        private Vector2 _oldVelocity;

        public void Init(BulletConfig bulletConfig) {
            gameObject.layer = (int)bulletConfig.PhysicsLayer;
            _spriteRenderer.color = bulletConfig.Color;
            _isPlayer = bulletConfig.IsPlayer;
            _speedMove = bulletConfig.Speed;
            _damage = bulletConfig.Damage;
        }

        public void SetVelocity(Vector3 velocity) {
            _rigidbody2D.velocity = velocity * _speedMove;
        }

        public void SetPosition(Vector3 position) {
            transform.position = position;
        }

        public void OnPauseGame() {
            _oldVelocity = _rigidbody2D.velocity;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
        }

        public void OnResumeGame() {
            _rigidbody2D.velocity = _oldVelocity;
            _rigidbody2D.isKinematic = false;
        }

        public void OnFinishGame() {
            OnCollisionEntered?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!collision.transform.TryGetComponent(out TeamComponent team)) {
                return;
            }

            if (_isPlayer == team.IsPlayer) {
                return;
            }

            if (collision.transform.TryGetComponent(out HitPointsComponent hitPoints)) {
                hitPoints.TakeDamage(_damage);
            }

            Destroy();
        }

        public void Destroy() {
            OnCollisionEntered?.Invoke(this);
        }
    }
}
