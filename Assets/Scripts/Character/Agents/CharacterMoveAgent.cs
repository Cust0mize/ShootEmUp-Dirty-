using ShootEmUp;
using UnityEngine;

namespace Controllers {
    public sealed class CharacterMoveAgent : MonoBehaviour, IFixedUpdateListener {
        [SerializeField] private GameObject _characterGO;
        private MoveComponent _moveComponent;
        private float _moveDirection;

        private void Start() {
            _moveComponent = _characterGO.GetComponent<MoveComponent>();
        }

        public void SetMoveDirection(float horizontalDirectional) {
            _moveDirection = horizontalDirectional;
        }

        public void OnFixedUpdateGame(float fixedDeltaTime) {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(_moveDirection, Vector2.zero.y));
        }
    }
}