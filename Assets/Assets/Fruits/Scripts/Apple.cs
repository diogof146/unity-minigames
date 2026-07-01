using UnityEngine;

namespace Fruits {

  public class Apple : MonoBehaviour {

    public int weight = 250;

    void Start() {
      int random = Random.Range(0, 3);

      switch (random) {
        case 0:
          break;
        case 1:
          transform.localScale *= 1.5f;
          weight = (int)(weight * 1.5);
          break;
        case 2:
          transform.localScale *= 2f;
          weight *= 2;
          break;
      }

      Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Basket")) {
        GameManager.instance.AddScore(weight);
        Destroy(gameObject);
      }
      else if (col.collider.CompareTag("Floor")) {
        GameManager.instance.LoseLife();
        Destroy(this);
      }
    }
  }
}
