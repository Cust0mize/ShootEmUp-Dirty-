using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public sealed class GameManager : MonoBehaviour {
        private List<IResumeGameListner> _iResumeGameListner = new();
        private List<IFinishGameListner> _iFinishGameListner = new();
        private List<IGameStartListner> _iGameStartListner = new();
        private List<IGamePauseListner> _iGamePauseListner = new();
        private List<IFixedUpdateListner> _iGameFixedUpdate = new();
        private List<IUpdateListner> _iGameUpdate = new();

        public void AddListners(HashSet<IGameLisnter> listetr) {
            foreach (var item in listetr) {
                AddLisnter(item);
            }
        }

        public void AddLisnter(IGameLisnter gameLisnter) {
            if (gameLisnter is IGameStartListner start) {
                _iGameStartListner.Add(start);
            }
            if (gameLisnter is IGamePauseListner pause) {
                _iGamePauseListner.Add(pause);
            }
            if (gameLisnter is IFinishGameListner finih) {
                _iFinishGameListner.Add(finih);
            }
            if (gameLisnter is IResumeGameListner resume) {
                _iResumeGameListner.Add(resume);
            }
            if (gameLisnter is IUpdateListner update) {
                _iGameUpdate.Add(update);
            }
            if (gameLisnter is IFixedUpdateListner fixedUpdate) {
                _iGameFixedUpdate.Add(fixedUpdate);
            }
        }

        public void FinishGame() {
            for (int i = 0; i < _iFinishGameListner.Count; i++) {
                _iFinishGameListner[i].FinishGame();
            }
            Debug.Log("Game over!");
        }

        public void PauseGame() {
            for (int i = 0; i < _iGamePauseListner.Count; i++) {
                _iGamePauseListner[i].OnPauseGame();
            }
        }

        public void StartGame() {
            for (int i = 0; i < _iGameStartListner.Count; i++) {
                _iGameStartListner[i].OnStartGame();
            }
        }

        public void ResumeGame() {
            for (int i = 0; i < _iResumeGameListner.Count; i++) {
                _iResumeGameListner[i].OnResumeGame();
            }
        }

        private void Update() {
            for (int i = 0; i < _iGameUpdate.Count; i++) {
                _iGameUpdate[i].UpdateGame(Time.deltaTime);
            }
        }

        private void FixedUpdate() {
            for (int i = 0; i < _iGameFixedUpdate.Count; i++) {
                _iGameFixedUpdate[i].FixedUpdateGame(Time.fixedDeltaTime);
            }
        }
    }
}