using UnityEngine;
using System;

namespace ShootEmUp {
    public class InputSystem : MonoBehaviour, IGameStartListner, IGamePauseListner, IFinishGameListner, IResumeGameListner {
        public event Action OnFire;
        public event Action<float> OnMove;

        private void Awake() {
            enabled = false;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                OnFire?.Invoke();
            }
            var horizontal = Input.GetAxisRaw("Horizontal");
            OnMove?.Invoke(horizontal);
        }

        public void OnResumeGame() {
            enabled = true;
        }

        public void FinishGame() {
            enabled = false;
        }

        public void OnPauseGame() {
            enabled = false;
        }

        public void OnStartGame() {
            enabled = true;
        }
    }
}