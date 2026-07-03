using UnityEngine;

namespace MobHouse {
  public class PickupKey : MonoBehaviour {

    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.CollectKey();
        Destroy(gameObject);
      }
    }
  }
}
