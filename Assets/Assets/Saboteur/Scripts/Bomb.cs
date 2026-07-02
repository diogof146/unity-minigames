using UnityEngine;

namespace Saboteur {
  public class Bomb : MonoBehaviour {
    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.ShowBombPrompt();
      }
    }

    void OnTriggerStay(Collider col) {
      if (col.CompareTag("Player")) {
        if (Input.GetKey(KeyCode.B)) {
          GameManager.instance.StartBombCountdown();
          GameManager.instance.HideBombPrompt();
          Destroy(gameObject);
        }
      }
    }

    void OnTriggerExit(Collider col) {
      if (col.CompareTag("Player")) {
        GameManager.instance.HideBombPrompt();
      }
    }
  }
}
