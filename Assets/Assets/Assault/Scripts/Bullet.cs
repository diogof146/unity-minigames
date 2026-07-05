using UnityEngine;

namespace Assault {

  public class Bullet : MonoBehaviour {
    private float speed = 10f;

    void Start() {
      Invoke("SelfDestroy", 3f);
    }

    void Update() {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Enemy")) {
        Destroy(col.gameObject);
        GameManager.instance.SpawnEnemy();
        Destroy(gameObject);
      }
      else if (col.collider.CompareTag("Door")) {
        Destroy(col.gameObject);
        Destroy(gameObject);
      }
    }

    private void SelfDestroy() {
      Destroy(gameObject);
    }
  }
}
