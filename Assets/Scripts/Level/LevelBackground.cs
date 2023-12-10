using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class LevelBackground : MonoBehaviour, IGameStartListner, IGamePauseListner, IResumeGameListner, IFinishGameListner, IUpdateListner {
        public bool IsEnable { get => _isEnable; }
        [SerializeField] private Params _params;
        private Transform _myTransform;

        private bool _isEnable;
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;

        public void FinishGame() {
            _isEnable = false;
        }

        public void OnPauseGame() {
            _isEnable = false;
        }

        public void OnResumeGame() {
            _isEnable = true;
        }

        public void OnStartGame() {
            _isEnable = true;
        }

        public void UpdateGame(float time) {
            if (!IsEnable) {
                return;
            }

            if (_myTransform.position.y <= _endPositionY) {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.deltaTime,
                _positionZ
            );
        }

        private void Awake() {
            _startPositionY = _params._startPositionY;
            _endPositionY = _params._endPositionY;
            _movingSpeedY = _params._movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
            enabled = false;
        }

        [Serializable]
        public sealed class Params {
            [SerializeField] public float _startPositionY;
            [SerializeField] public float _endPositionY;
            [SerializeField] public float _movingSpeedY;
        }
    }
}