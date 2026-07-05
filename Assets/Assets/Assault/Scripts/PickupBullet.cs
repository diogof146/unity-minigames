using UnityEngine;

namespace Assault {

  public class PickupBullet : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.CollectBullets();
        Destroy(gameObject);
      }
    }
  }
}
