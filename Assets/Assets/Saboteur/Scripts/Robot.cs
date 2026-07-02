using UnityEngine;

namespace Saboteur {

  public class Robot : MonoBehaviour {

    private float speed = 5f;

    void Update() {
      transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Player")) {
        GameManager.instance.CatchPlayer();
      }
      else if (col.collider.CompareTag("Wall")) {
        Destroy(gameObject);
      }
    }
  }
}
