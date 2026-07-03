using UnityEngine;

public class Elevator : MonoBehaviour {

  private int currentFloor;
  private float distance;
  private bool goingUp;
  private float moveCooldown;
  private float speed = 2f;

  void Start() {
    currentFloor = 3;
    goingUp = true;
    moveCooldown = 0f;
  }

  void Update() {
    if (moveCooldown <= 0) {
      if (goingUp) {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
      }
      else {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
      }
    }

    moveCooldown -= Time.deltaTime;
  }

  void OnTriggerEnter(Collider col) {
    if (col.gameObject.name == "ElevatorTriggerThird") {
      goingUp = true;
      moveCooldown = 2f;
    }
    else if (col.gameObject.name == "ElevatorTriggerSecond") {
      moveCooldown = 2f;
    }
    else if (col.gameObject.name == "ElevatorTriggerFirst") {
      goingUp = false;
      moveCooldown = 2f;
    }

  }
}
