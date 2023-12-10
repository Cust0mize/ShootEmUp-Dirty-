using UnityEngine;

namespace ShootEmUp {
    public class BulletCreateObserver : MonoBehaviour {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletPool _bulletPool;

        private void Awake() {
            _bulletPool.OnBulletCreate += AddNewListner;
        }

        private void AddNewListner(Bullet bullet) {
            _gameManager.AddLisnter(bullet);
        }

        private void OnDestroy() {
            _bulletPool.OnBulletCreate -= AddNewListner;
        }
    }
}