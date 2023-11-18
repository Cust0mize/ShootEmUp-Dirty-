using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class Bullet : MonoBehaviour {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [field: SerializeField] public PoolType PoolType { get; private set; }
        [field: SerializeField] public bool IsPlayer { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speedMove;
        [SerializeField] private Color _color;
        [SerializeField] private PhysicsLayer _layer;

        private void Start() {
            gameObject.layer = (int)_layer;
            _spriteRenderer.color = _color;
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