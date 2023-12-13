using UnityEngine;

namespace ShootEmUp {
    public sealed class MoveComponent : MonoBehaviour, IGamePauseListener, IResumeGameListener, IFinishGameListener {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed = 5.0f;
        private bool _isPause;

        public void OnPauseGame() {
            _isPause = true;
        }

        public void OnResumeGame() {
            _isPause = false;
        }

        public void OnFinishGame() {
            _isPause = true;
        }

        public void MoveByRigidbodyVelocity(Vector2 vector) {
            if (_isPause) {
                return;
            }

            var nextPosition = _rigidbody2D.position + vector * Time.fixedDeltaTime * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}