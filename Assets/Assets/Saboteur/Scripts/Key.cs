using UnityEngine;

namespace Saboteur {
  public class Key : MonoBehaviour {
    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        if (gameObject.name == "Key") {
          GameManager.instance.CollectFirstKey();
        }
        else {
          GameManager.instance.CollectSecondKey();
        }
        Destroy(gameObject);
      }
    }
  }
}
