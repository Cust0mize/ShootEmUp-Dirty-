﻿using UnityEngine;
using ShootEmUp;

namespace Character {
    public class CharacterWeaponController : MonoBehaviour {
        [SerializeField] private GameObject _characterGO;
        private BulletSystem _bulletSystem;
        private WeaponComponent _weapon;

        private void Start() {
            _weapon = _characterGO.GetComponent<WeaponComponent>();
            _bulletSystem = FindObjectOfType<BulletSystem>();
        }

        public void OnFlyBullet() {
            _bulletSystem.FlyBullet(_weapon._bullet, _weapon.Position, Vector3.up);
        }
    }
}