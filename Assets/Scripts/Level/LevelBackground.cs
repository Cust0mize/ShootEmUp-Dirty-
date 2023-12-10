using UnityEngine;
using System;

namespace ShootEmUp {
    public sealed class LevelBackground : MonoBehaviour, IGameStartListner, IGamePauseListner, IResumeGameListner, IFinishGameListner {
        [SerializeField] private Params _params;
        private Transform _myTransform;

        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;

        public void FinishGame() {
            enabled = false;
        }

        public void OnPauseGame() {
            enabled = false;
        }

        public void OnResumeGame() {
            enabled = true;
        }

        public void OnStartGame() {
            enabled = true;
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

        private void Update() {
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

        [Serializable]
        public sealed class Params {
            [SerializeField] public float _startPositionY;
            [SerializeField] public float _endPositionY;
            [SerializeField] public float _movingSpeedY;
        }
    }
}