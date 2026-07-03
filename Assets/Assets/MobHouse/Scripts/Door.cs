using UnityEngine;

namespace MobHouse {

  public class Door : MonoBehaviour {

    private Animator anim;
    private float distance;
    private Transform player;

    void Start() {
      anim = GetComponent<Animator>();
      player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
      distance = Vector3.Distance(transform.position, player.position);

      if (distance <= 1f) {
        GameManager.instance.ShowPrompt();
      }
      else {
        GameManager.instance.HidePrompt();
      }

      if (distance <= 1f && GameManager.instance.hasKey && Input.GetKeyDown(KeyCode.E)) {
        anim.SetTrigger("open");
      }
    }
  }
}
