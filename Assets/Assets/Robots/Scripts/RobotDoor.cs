using UnityEngine;

namespace Robots {

  public class RobotDoor : MonoBehaviour {
    private Transform player;
    private float distance;

    void Start() {
      player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
      distance = Vector3.Distance(transform.position, player.position);
      if (distance <= 3f) {
        GameManager.instance.ShowOpenPrompt();
      }
      else {
        GameManager.instance.HideOpenPrompt();
      }

      if (distance <= 3f && Input.GetKeyDown(KeyCode.E)) {
        GameManager.instance.GameOver();
      }
    }
  }
}
