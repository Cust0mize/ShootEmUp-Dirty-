using UnityEngine;
using Character;

namespace ShootEmUp {
    public sealed class InputManager : MonoBehaviour {
        [SerializeField] private CharacterWeaponController _characterWeaponController;
        [SerializeField] private CharacterMoveController _characterMoveControlle;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _characterWeaponController.OnFlyBullet();
            }
            var horizontal = Input.GetAxisRaw("Horizontal");
            _characterMoveControlle.TryMove(horizontal);
        }
    }
}