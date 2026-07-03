using UnityEngine;

namespace MobHouse {

  public class Bullet : MonoBehaviour {
    private float speed = 10f;
    private Vector3 initialPosition;
    private float distanceTravelled;

    void Start() {
      initialPosition = transform.position;
    }

    void Update() {
      distanceTravelled = Vector3.Distance(transform.position, initialPosition);

      if (distanceTravelled >= 20f) {
        Destroy(gameObject);
      }

      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Enemy")) {
        Destroy(col.gameObject);
        Destroy(gameObject);
      }
      else if (col.collider.CompareTag("Player")) {
        GameManager.instance.KillPlayer();
        Destroy(gameObject);
      }
      else if (col.collider.CompareTag("Wall")) {
        Destroy(gameObject);
      }
    }
  }
}
