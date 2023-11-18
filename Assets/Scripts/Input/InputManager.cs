using UnityEngine;
using Character;

namespace ShootEmUp {
    public sealed class InputManager : MonoBehaviour {
        [SerializeField] private CharacterMoveController _characterMoveController;

        [SerializeField]
        private CharacterController characterController;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                characterController._fireRequired = true;
            }

            var horizontal = Input.GetAxisRaw("Horizontal");
            _characterMoveController.TryMove(horizontal);
        }
    }
}