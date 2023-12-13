using System.Collections;
using ShootEmUp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers {
    public class GameCooldownLauncher : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private float _launchCooldown = 3;

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
            float startTime = _launchCooldown;

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