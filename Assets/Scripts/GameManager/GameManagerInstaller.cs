using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp {
    public class GameManagerInstaller : MonoBehaviour {
        [SerializeField] private GameManager _gameManager;
        private HashSet<IGameLisnter> _listetr = new();

        private void Awake() {
            _listetr = FindObjectsOfType<MonoBehaviour>(true).OfType<IGameLisnter>().ToHashSet();
            _gameManager.AddListners(_listetr);
        }
    }
}