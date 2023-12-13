using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp {
    public class GameManagerInstaller : MonoBehaviour {
        [SerializeField] private GameManager _gameManager;

        private void Awake() {
            var listeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IGameListener>();
            _gameManager.AddListener(listeners);
        }
    }
}