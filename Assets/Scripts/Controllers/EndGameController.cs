using UnityEngine;

namespace ShootEmUp {
    public class EndGameController : MonoBehaviour {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _characterGO;

        private void Start() {
            _characterGO.GetComponent<HitPointsComponent>().HpEmpty += EndGame;
        }

        private void OnDestroy() {
            if (_characterGO != null) {
                _characterGO.GetComponent<HitPointsComponent>().HpEmpty -= EndGame;
            }
        }

        private void EndGame(GameObject gameObject) {
            _gameManager.FinishGame();
        }
    }
}