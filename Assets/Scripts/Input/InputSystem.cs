using UnityEngine;
using System;

namespace ShootEmUp{
    public class InputSystem : MonoBehaviour, IUpdateListener{
        public event Action<float> OnMove;
        public event Action OnFire;

        public void OnUpdateGame(float deltaTime){
            if (Input.GetKeyDown(KeyCode.Space)){
                OnFire?.Invoke();
            }

            var horizontal = Input.GetAxisRaw("Horizontal");
            OnMove?.Invoke(horizontal);
        }
    }
}