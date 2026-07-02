using UnityEngine;

namespace Saboteur {
  public class AutomaticDoor : MonoBehaviour {

    private Transform player;
    private Animator anim;
    private bool isOpen = false;

    private Vector3 startPosition;

    void Start() {
      player = GameObject.FindWithTag("Player").transform;
      anim = GetComponent<Animator>();
      startPosition = transform.position;
    }

    void Update() {
      float distance = Vector3.Distance(startPosition, player.position);

      if (distance <= 5f && !isOpen) {
        anim.ResetTrigger("close");
        anim.SetTrigger("open");
        isOpen = true;
      }
      else if (distance > 5f && isOpen) {
        anim.ResetTrigger("open");
        anim.SetTrigger("close");
        isOpen = false;
      }
    }
  }
}
