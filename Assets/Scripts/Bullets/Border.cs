using UnityEngine;

namespace ShootEmUp{
    public class Border : MonoBehaviour{
        private void OnCollisionEnter2D(Collision2D collision){
            if (collision.transform.TryGetComponent(out IDestroyableOnBorder destroyToBorder)){
                destroyToBorder.Destroy();
            }
        }
    }
}