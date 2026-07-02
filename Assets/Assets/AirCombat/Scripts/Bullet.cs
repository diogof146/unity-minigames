using UnityEngine;

namespace AirCombat {
  public class Bullet : MonoBehaviour {

    private float speed = 1500f;

    void Start() {
      Destroy(gameObject, 5f);
    }

    void Update() {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Enemy")) {
        Destroy(col.collider.gameObject);
        GameManager.instance.KillOvni();
        Destroy(gameObject);
      }
    }
  }
}
