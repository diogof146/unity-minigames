using UnityEngine;

namespace FarWestBank {

  public class Client : MonoBehaviour {

    void Start() {
      Invoke("Deposit", 2f);
    }

    void Update() {

    }

    private void Deposit() {
      GameManager.instance.AddMoney();
      Destroy(gameObject);
    }
  }
}
