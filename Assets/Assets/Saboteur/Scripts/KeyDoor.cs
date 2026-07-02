using UnityEngine;

namespace Saboteur {
  public class KeyDoor : MonoBehaviour {

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

      if (distance <= 3f && !isOpen) {
        if ((gameObject.name == "DoorFirst" && GameManager.instance.hasFirstKey) || (gameObject.name == "DoorSecond" && GameManager.instance.hasSecondKey)) {
          GameManager.instance.ShowOpenPrompt();
          if (Input.GetKeyDown(KeyCode.E)) {
            anim.ResetTrigger("close");
            anim.SetTrigger("open");
            isOpen = true;
          }
        }
      }
      else if (distance > 5f && isOpen) {
        GameManager.instance.HideOpenPrompt();
        anim.ResetTrigger("open");
        anim.SetTrigger("close");
        isOpen = false;
      }

      if (isOpen) {
        GameManager.instance.HideOpenPrompt();
      }
    }
  }
}
