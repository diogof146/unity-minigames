using UnityEngine;

namespace Fruits {

  public class Player : MonoBehaviour {

    private float speed = 20f;
    private Rigidbody rb;
    private bool canJump = true;

    public Transform left;
    public Transform right;

    void Start() {
      rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
      rb.AddForce(new Vector3(0, -20f, 0), ForceMode.Acceleration);

      if (Input.GetKey(KeyCode.Space) && canJump) {
        rb.AddForce(Vector3.up * 35f, ForceMode.Impulse);
        canJump = false;
      }
    }

    void Update() {
      if (Input.GetKey(KeyCode.A) && transform.position.x > left.position.x) {
        transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.D) && transform.position.x < right.position.x) {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
      }
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Floor")) { canJump = true; }
    }

    void OnCollisionExit(Collision col) {
      if (col.collider.CompareTag("Floor")) { canJump = false; }
    }
  }
}
