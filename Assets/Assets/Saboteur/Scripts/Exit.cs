using UnityEngine;

namespace Saboteur {
  public class Exit : MonoBehaviour {
    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.Escape();
        Destroy(gameObject);
      }
    }
  }
}
