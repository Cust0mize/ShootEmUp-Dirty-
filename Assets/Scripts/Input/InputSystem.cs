using UnityEngine;
using System;

namespace ShootEmUp {
    public class InputSystem : MonoBehaviour {
        public event Action OnFire;
        public event Action<float> OnMove;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                OnFire?.Invoke();
            }
            var horizontal = Input.GetAxisRaw("Horizontal");
            OnMove?.Invoke(horizontal);
        }
    }
}