using UnityEngine.UI;
using UnityEngine;

namespace ShootEmUp {
    public class StopOrStartGameController : MonoBehaviour, IGameStartListner {
        [SerializeField] private Button _stopOrStartGameButton;
        [SerializeField] private GameManager _gameManager;
        private bool _isStop;

        public void OnStartGame() {
            _stopOrStartGameButton.gameObject.SetActive(true);
        }

        private void Start() {
            _stopOrStartGameButton.RemoveAllAndAddListner(StopOrStartButtonClick);
            _stopOrStartGameButton.gameObject.SetActive(false);
        }

        private void StopOrStartButtonClick() {
            if (_isStop) {
                _isStop = false;
                _gameManager.ResumeGame();
            }
            else {
                _isStop = true;
                _gameManager.PauseGame();
            }
        }
    }
}