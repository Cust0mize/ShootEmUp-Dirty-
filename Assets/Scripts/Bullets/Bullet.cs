using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class Bullet : MonoBehaviour {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private PhysicsLayer _layer;
        private float _speedMove;
        private Color _color;

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
            OnCollisionEntered?.Invoke(this, collision);
        }
    }
}