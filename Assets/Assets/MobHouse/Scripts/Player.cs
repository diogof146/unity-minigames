using UnityEngine;

namespace MobHouse {

  public class Player : MonoBehaviour {

    private Rigidbody rb;
    private float jumpForce = 8f;
    private float speed = 5f;
    private bool canJump;
    private bool jumping;
    private bool movingRight;
    private bool movingLeft;

    public GameObject bulletPrefab;
    public Transform attackPoint;

    void Start() {
      rb = GetComponent<Rigidbody>();
    }

    void Update() {
      movingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
      movingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);

      if (movingRight) {
        transform.rotation = Quaternion.Euler(0, 90, 0);
      }

      if (movingLeft) {
        transform.rotation = Quaternion.Euler(0, 270, 0);
      }

      if (Input.GetKeyDown(KeyCode.Space) && canJump) {
        jumping = true;
      }

      if (GameManager.instance.hasGun && GameManager.instance.bulletCount > 0 && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0))) {
        GameManager.instance.bulletCount--;
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
      }
    }

    void FixedUpdate() {
      if (movingRight || movingLeft) {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
      }

      if (jumping && canJump) {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false;
        jumping = false;
      }
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Floor")) {
        canJump = true;
      }
    }

    void OnCollisionExit(Collision col) {
      if (col.collider.CompareTag("Floor")) {
        canJump = false;
      }
    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Finish")) {
        GameManager.instance.EndGame();
      }
    }
  }
}
