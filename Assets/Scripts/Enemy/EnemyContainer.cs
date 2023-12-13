using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp {
    public class EnemyContainer : MonoBehaviour {
        public List<IRebootComponent> _rebootsComponents = new List<IRebootComponent>();

        private void Start() {
            _rebootsComponents = transform.GetComponents<IRebootComponent>().ToList();
        }

        public void RebootComponents() {
            foreach (var item in _rebootsComponents) {
                item.Reboot();
            }
        }
    }
}