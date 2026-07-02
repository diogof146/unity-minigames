using UnityEngine;

namespace Robots {

  public class EnemyRobot : MonoBehaviour {

    public Transform[] waypoints;
    private int current;
    private float distance;

    private float speed = 15f;

    void Start() {

    }

    void Update() {
      transform.LookAt(waypoints[current]);
      transform.Translate(Vector3.forward * speed * Time.deltaTime);

      distance = Vector3.Distance(transform.position, waypoints[current].position);

      if (distance <= 1f) {
        current++;
      }

      if (current >= 4) {
        current = 0;
      }
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Player")) {
        GameManager.instance.CatchPlayer();
      }
    }
  }
}
