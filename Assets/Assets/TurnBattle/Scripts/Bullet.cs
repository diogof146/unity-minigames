using UnityEngine;

namespace TurnBattle {

  public class Bullet : MonoBehaviour {

    private float speed = 1.5f;

    void Start() {
      Destroy(gameObject, 3f);
    }

    void Update() {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Enemy") || col.collider.CompareTag("Player")) {
        GameManager.instance.DestroyPiece(col.collider.gameObject);
      }
      Destroy(gameObject);
    }
  }
}
