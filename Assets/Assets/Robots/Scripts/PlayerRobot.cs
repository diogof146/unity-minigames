using UnityEngine;

namespace Robots {

  public class PlayerRobot : MonoBehaviour {

    private float speed = 5f;
    private Transform cam;

    void Start() {
      cam = Camera.main.transform;
    }

    void Update() {
      Vector3 dir = Vector3.zero;

      if (Input.GetKey(KeyCode.W)) dir += cam.forward;
      if (Input.GetKey(KeyCode.S)) dir -= cam.forward;
      if (Input.GetKey(KeyCode.D)) dir += cam.right;
      if (Input.GetKey(KeyCode.A)) dir -= cam.right;

      dir.y = 0;
      dir.Normalize();

      if (dir != Vector3.zero) {
        transform.forward = new Vector3(cam.forward.x, 0, cam.forward.z);
        transform.Translate(dir * speed * Time.deltaTime);
      }
    }
  }
}
