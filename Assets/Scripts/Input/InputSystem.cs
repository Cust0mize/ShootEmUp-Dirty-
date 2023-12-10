using UnityEngine;
using System;

namespace ShootEmUp {
    public class InputSystem : MonoBehaviour, IGameStartListner, IGamePauseListner, IFinishGameListner, IResumeGameListner, IUpdateListner {
        public event Action<float> OnMove;
        public event Action OnFire;
        private bool _isEnable;

        public bool IsEnable => _isEnable;

        public void UpdateGame(float time) {
            if (!IsEnable) {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                OnFire?.Invoke();
            }
            var horizontal = Input.GetAxisRaw("Horizontal");
            OnMove?.Invoke(horizontal);
        }

        public void OnResumeGame() {
            _isEnable = true;
        }

        public void FinishGame() {
            _isEnable = false;
        }

        public void OnPauseGame() {
            _isEnable = false;
        }

        public void OnStartGame() {
            _isEnable = true;
        }
    }
}