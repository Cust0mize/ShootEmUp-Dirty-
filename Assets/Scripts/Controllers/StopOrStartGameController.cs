using UnityEngine.UI;
using UnityEngine;

namespace ShootEmUp {
    public class StopOrStartGameController : MonoBehaviour {
        [SerializeField] private Button _stopOrStartGameButton;
        [SerializeField] private GameManager _gameManager;
        private bool _isStop;

        private void Start() {
            _stopOrStartGameButton.RemoveAllAndAddListner(StopOrStartButtonClick);
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