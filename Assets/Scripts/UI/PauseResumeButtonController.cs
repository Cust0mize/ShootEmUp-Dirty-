using ShootEmUp;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Controllers{
    public class PauseResumeButtonController : MonoBehaviour, IGameStartListener{
        [SerializeField] private Button _pauseResumeButton;
        [SerializeField] private GameManager _gameManager;
        private bool _isPause;

        private void Awake(){
            _pauseResumeButton.RemoveAllAndAddListner(StopOrStartButtonClick);
            _pauseResumeButton.gameObject.SetActive(false);
        }

        public void OnStartGame(){
            _pauseResumeButton.gameObject.SetActive(true);
        }
        
        private void StopOrStartButtonClick(){
            if (_isPause){
                _isPause = false;
                _gameManager.ResumeGame();
            }
            else{
                _isPause = true;
                _gameManager.PauseGame();
            }
        }
    }
}