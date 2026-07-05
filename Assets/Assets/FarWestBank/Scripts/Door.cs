using UnityEngine;

namespace FarWestBank {

  public class Door : MonoBehaviour {

    private Animator anim;

    public Transform spawnPoint;

    void Start() { anim = GetComponent<Animator>(); }

    void Update() {

    }

    public void Spawn(GameObject obj) {
      anim.SetTrigger("open");
      Instantiate(obj, spawnPoint.position, spawnPoint.rotation);
      Invoke("Close", 2f);
    }

    private void Close() { anim.SetTrigger("close"); }
  }
}
