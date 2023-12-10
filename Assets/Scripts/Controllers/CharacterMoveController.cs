using UnityEngine;
using ShootEmUp;

namespace Character {
    public sealed class CharacterMoveController : MonoBehaviour, IFixedUpdateListner {
        [SerializeField] private GameObject _characterGO;
        private MoveComponent _moveComponent;
        private float _moveDirection;

        public bool IsEnable => _isEnable;
        private bool _isEnable = true;

        private void Start() {
            _moveComponent = _characterGO.GetComponent<MoveComponent>();
        }

        public void SetMoveDirection(float horizontalDirectional) {
            _moveDirection = horizontalDirectional;
        }

        public void FixedUpdateGame(float time) {
            if (!IsEnable) {
                return;
            }

            _moveComponent.MoveByRigidbodyVelocity(new Vector2(_moveDirection, Vector2.zero.y));
        }
    }
}