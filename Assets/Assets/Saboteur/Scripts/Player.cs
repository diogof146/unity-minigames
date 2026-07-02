using UnityEngine;

namespace Saboteur {
  public class Player : MonoBehaviour {

    private float speed = 5f;

    void Start() {
    }

    void Update() {
      Move();
    }

    void Move() {
      Vector3 dir = Vector3.zero;

      if (Input.GetKey(KeyCode.W)) dir += Vector3.forward;
      if (Input.GetKey(KeyCode.S)) dir -= Vector3.forward;
      if (Input.GetKey(KeyCode.D)) dir += Vector3.right;
      if (Input.GetKey(KeyCode.A)) dir -= Vector3.right;

      dir.y = 0;
      dir.Normalize();

      if (dir != Vector3.zero) {
        transform.Translate(dir * speed * Time.deltaTime);
      }
    }
  }
}
