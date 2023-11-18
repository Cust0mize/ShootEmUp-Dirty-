using UnityEngine;

namespace ShootEmUp {
    public sealed class WeaponComponent : MonoBehaviour {
        [field: SerializeField] public Bullet _bullet { get; private set; }
        [SerializeField] private Transform _firePoint;

        public Vector2 Position {
            get { return _firePoint.position; }
        }

        public Quaternion Rotation {
            get { return _firePoint.rotation; }
        }
    }
}