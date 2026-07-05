using UnityEngine;

namespace FarWestBank {

  public class Burglar : MonoBehaviour {

    void Start() {
      Invoke("Rob", 2f);
    }

    void Update() {

    }

    private void Rob() {
      GameManager.instance.GetRobbed();
      Destroy(gameObject);
    }
  }
}
