using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class Bullet : MonoBehaviour, IDestroyToBorder {
        public event Action<Bullet> OnCollisionEntered;

        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private float _speedMove;

        public void Init(BulletConfig bulletConfig) {
            gameObject.layer = (int)bulletConfig.PhysicsLayer;
            _spriteRenderer.color = bulletConfig.Color;
            IsPlayer = bulletConfig.IsPlayer;
            _speedMove = bulletConfig.Speed;
            Damage = bulletConfig.Damage;
        }

        public void SetVelosity(Vector3 velocity) {
            _rigidbody2D.velocity = velocity * _speedMove;
        }

        public void SetPosition(Vector3 position) {
            transform.position = position;
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!collision.transform.TryGetComponent(out TeamComponent team)) {
                return;
            }

            if (IsPlayer == team.IsPlayer) {
                return;
            }

            if (collision.transform.TryGetComponent(out HitPointsComponent hitPoints)) {
                hitPoints.TakeDamage(Damage);
            }

            Destroy();
        }

        public void Destroy() {
            OnCollisionEntered?.Invoke(this);
        }
    }
}
