using UnityEngine;
using Character;

namespace ShootEmUp {
    public sealed class CharacterController : MonoBehaviour {
        [SerializeField] private CharacterWeaponController _characterWeaponController;
        [SerializeField] private CharacterMoveController _characterMoveControlle;
        [SerializeField] private InputSystem _inputSystem;

        private void Start() {
            _inputSystem.OnFire += Fire;
            _inputSystem.OnMove += Move;
        }

        private void OnDestroy() {
            _inputSystem.OnFire -= Fire;
            _inputSystem.OnMove -= Move;
        }

        private void Fire() {
            _characterWeaponController.OnFlyBullet();
        }

        private void Move(float direction) {
            _characterMoveControlle.SetMoveDirection(direction);
        }
    }
}