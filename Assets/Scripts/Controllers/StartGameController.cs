using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace ShootEmUp {
    public class StartGameController : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _startGameButton;

        private void Start() {
            _timerText.gameObject.SetActive(false);
            _startGameButton.RemoveAllAndAddListner(StartGameClick);
        }

        private void StartGameClick() {
            _timerText.gameObject.SetActive(true);
            _startGameButton.gameObject.SetActive(false);
            StartCoroutine(OnStartGame());
        }

        private IEnumerator OnStartGame() {
            float startTime = 3;

            while (startTime > 0) {
                startTime -= Time.deltaTime;
                _timerText.text = $"{startTime:f0}";
                yield return null;
            }
            _timerText.gameObject.SetActive(false);
            _gameManager.StartGame();
        }
    }
}