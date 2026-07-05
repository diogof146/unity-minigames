using UnityEngine;

namespace FarWestBank {

  public class Bullet : MonoBehaviour {

    private Rigidbody rb;

    private float speed = 30f;

    void Start() {
      rb = GetComponent<Rigidbody>();
      Invoke("SelfDestruct", 3f);
      rb.linearVelocity = transform.forward * speed;
    }

    void Update() {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Enemy")) {
        Destroy(col.collider.gameObject);
        Destroy(gameObject);
      }
      else if (col.collider.CompareTag("Player")) {
        GameManager.instance.GameOver();
        Destroy(col.collider.gameObject);
        Destroy(gameObject);
      }
    }

    private void SelfDestruct() { Destroy(gameObject); }
  }
}
