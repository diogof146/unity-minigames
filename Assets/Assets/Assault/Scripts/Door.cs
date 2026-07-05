using UnityEngine;

namespace Assault {

  public class Door : MonoBehaviour {

    private Animator anim;

    void Awake() {
      anim = GetComponent<Animator>();
    }

    void Update() {

    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Bullet")) {
        Destroy(gameObject);
      }
    }

    public void Open() { anim.SetTrigger("open"); }
    public void Close() { anim.SetTrigger("close"); }
  }
}
