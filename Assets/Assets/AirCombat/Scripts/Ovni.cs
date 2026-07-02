using UnityEngine;

public class Ovni : MonoBehaviour {

  private float speed = 10f;
  private Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Acceleration);
  }

  void OnCollisionEnter(Collision col) {
    if (col.collider.CompareTag("Floor")) {
      GameManager.instance.EndGame();
    }
  }
}
