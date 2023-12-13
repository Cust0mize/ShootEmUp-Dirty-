using UnityEngine;

namespace ShootEmUp {
    public class BulletCreateObserver : MonoBehaviour {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletPool _bulletPool;

        private void Awake() {
            _bulletPool.OnBulletCreate += AddNewListener;
        }

        private void AddNewListener(Bullet bullet) {
            _gameManager.AddListeners(bullet);
        }

        private void OnDestroy() {
            _bulletPool.OnBulletCreate -= AddNewListener;
        }
    }
}