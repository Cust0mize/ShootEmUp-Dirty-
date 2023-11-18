using Object = UnityEngine.Object;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp {
    public class GameObjectCreator : MonoBehaviour {
        public void CreateObjectAndAddPool<T>(Queue<T> pull, T prefab, int pullSize, Transform container) where T : Object {
            for (int i = 0; i < pullSize; i++) {
                pull.Enqueue(Instantiate(prefab, container));
            }
        }
    }
}