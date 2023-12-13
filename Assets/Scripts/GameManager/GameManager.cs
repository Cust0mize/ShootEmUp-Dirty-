using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp{
    public sealed class GameManager : MonoBehaviour{
        private GameState _currentGameState = GameState.None;

        private readonly List<IResumeGameListener> _resumeListeners = new();
        private readonly List<IFinishGameListener> _finishListeners = new();
        private readonly List<IGameStartListener> _startListeners = new();
        private readonly List<IGamePauseListener> _pauseListeners = new();

        private readonly List<IFixedUpdateListener> _fixedUpdateListeners = new();
        private readonly List<IUpdateListener> _updateListeners = new();

        public void AddListener(IEnumerable<IGameListener> listeners){
            foreach (var item in listeners){
                AddListeners(item);
            }
        }

        public void AddListeners(IGameListener gameListener){
            if (gameListener is IGameStartListener start){
                _startListeners.Add(start);
            }

            if (gameListener is IGamePauseListener pause){
                _pauseListeners.Add(pause);
            }

            if (gameListener is IFinishGameListener finish){
                _finishListeners.Add(finish);
            }

            if (gameListener is IResumeGameListener resume){
                _resumeListeners.Add(resume);
            }

            if (gameListener is IUpdateListener update){
                _updateListeners.Add(update);
            }

            if (gameListener is IFixedUpdateListener fixedUpdate){
                _fixedUpdateListeners.Add(fixedUpdate);
            }
        }

        public void FinishGame(){
            if (_currentGameState is GameState.None or GameState.Finished){
                return;
            }

            for (int i = 0; i < _finishListeners.Count; i++){
                _finishListeners[i].OnFinishGame();
            }

            Debug.Log("Game over!");
            _currentGameState = GameState.Finished;
        }

        public void PauseGame(){
            if (_currentGameState != GameState.Playing){
                return;
            }

            for (int i = 0; i < _pauseListeners.Count; i++){
                _pauseListeners[i].OnPauseGame();
            }

            _currentGameState = GameState.Paused;
        }

        public void StartGame(){
            if (_currentGameState != GameState.None){
                return;
            }

            for (int i = 0; i < _startListeners.Count; i++){
                _startListeners[i].OnStartGame();
            }

            _currentGameState = GameState.Playing;
        }

        public void ResumeGame(){
            if (_currentGameState != GameState.Paused){
                return;
            }
            
            for (int i = 0; i < _resumeListeners.Count; i++){
                _resumeListeners[i].OnResumeGame();
            }

            _currentGameState = GameState.Playing;
        }

        private void Update(){
            if (_currentGameState != GameState.Playing){
                return;
            }

            for (int i = 0; i < _updateListeners.Count; i++){
                _updateListeners[i].OnUpdateGame(Time.deltaTime);
            }
        }

        private void FixedUpdate(){
            if (_currentGameState != GameState.Playing){
                return;
            }

            for (int i = 0; i < _fixedUpdateListeners.Count; i++){
                _fixedUpdateListeners[i].OnFixedUpdateGame(Time.fixedDeltaTime);
            }
        }
    }

    public enum GameState{
        None = 0,
        Playing,
        Paused,
        Finished
    }
}