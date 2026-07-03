using UnityEngine;

namespace MobHouse {
  public class PickupGun : MonoBehaviour {
    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.CollectGun();
        Destroy(gameObject);
      }
    }
  }
}
