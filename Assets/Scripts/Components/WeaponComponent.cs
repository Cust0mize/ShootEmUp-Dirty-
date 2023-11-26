using UnityEngine;

namespace ShootEmUp {
    public sealed class WeaponComponent : MonoBehaviour {
        [field: SerializeField] public BulletConfig BulletConfig { get; private set; }
        [SerializeField] private Transform _firePoint;

        public Vector2 Position {
            get { return _firePoint.position; }
        }

        public Quaternion Rotation {
            get { return _firePoint.rotation; }
        }
    }
}