using UnityEngine;

namespace Fruits {

  public class Tire : MonoBehaviour {

    private Rigidbody rb;
    private string rotation;

    void Start() {
      rb = GetComponent<Rigidbody>();
      Destroy(this.gameObject, 10f);
    }

    void FixedUpdate() {
      if (rotation == "right") {
        // transform.Rotate(new Vector3(0f, 0f, 5f));
        rb.AddForce(Vector3.left * 5f);
      }
      else if (rotation == "left") {
        // transform.Rotate(new Vector3(0f, 0f, -5f));
        rb.AddForce(Vector3.right * 5f);
      }
    }

    public void Rotate(string rot) {
      rotation = rot;
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Left")) {
        rotation = "left";

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.right * 10f, ForceMode.Impulse);
      }
      else if (col.collider.CompareTag("Right")) {
        rotation = "right";

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.left * 10f, ForceMode.Impulse);
      }
      else if (col.collider.CompareTag("Tire")) {
        Destroy(gameObject);
      }
      else if (col.collider.CompareTag("Player") || col.collider.CompareTag("Basket")) {
        GameManager.instance.GameOver();
      }
    }
  }
}
