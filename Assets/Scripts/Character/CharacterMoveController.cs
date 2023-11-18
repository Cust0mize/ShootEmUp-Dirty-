using UnityEngine;
using ShootEmUp;

namespace Character {
    public sealed class CharacterMoveController : MonoBehaviour {
        [SerializeField] private GameObject _characterGO;
        private MoveComponent _moveComponent;
        private float _moveDirection;

        private void Start() {
            _moveComponent = _characterGO.GetComponent<MoveComponent>();
        }

        public void TryMove(float horizontal) {
            _moveDirection = horizontal;
        }

        private void FixedUpdate() {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(_moveDirection, Vector2.zero.y));
        }
    }
}