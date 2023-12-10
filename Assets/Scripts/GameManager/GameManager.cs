using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public sealed class GameManager : MonoBehaviour {
        private List<IResumeGameListner> _iResumeGameListner = new();
        private List<IFinishGameListner> _iFinishGameListner = new();
        private List<IGameStartListner> _iGameStartListner = new();
        private List<IGamePauseListner> _iGamePauseListner = new();

        public void AddListners(HashSet<IGameLisnter> listetr) {
            foreach (var item in listetr) {
                if (item is IGameStartListner start) {
                    _iGameStartListner.Add(start);
                }
                if (item is IGamePauseListner pause) {
                    _iGamePauseListner.Add(pause);
                }
                if (item is IFinishGameListner finih) {
                    _iFinishGameListner.Add(finih);
                }
                if (item is IResumeGameListner resume) {
                    _iResumeGameListner.Add(resume);
                }
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
        }

        public void FinishGame() {
            Debug.Log("Game over!");

            foreach (var item in _iFinishGameListner) {
                item.FinishGame();
            }
        }

        public void PauseGame() {
            foreach (var item in _iGamePauseListner) {
                item.OnPauseGame();
            }
        }

        public void StartGame() {
            foreach (var item in _iGameStartListner) {
                item.OnStartGame();
            }
        }

        public void ResumeGame() {
            foreach (var item in _iResumeGameListner) {
                item.OnResumeGame();
            }
        }
    }
}