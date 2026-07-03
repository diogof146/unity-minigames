using UnityEngine;

namespace MobHouse {

  public class PickupBullet : MonoBehaviour {
    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.CollectBullet();
        Destroy(gameObject);
      }
    }
  }
}
