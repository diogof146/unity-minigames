using UnityEngine;

namespace TableTennis {

  public class NPCRacket : MonoBehaviour {

    public Rigidbody ballRb;
    public Ball ball;
    private float distance;

    void Start() {
      ballRb = ballRb.GetComponent<Rigidbody>();
      ball = ballRb.GetComponent<Ball>();
    }

    void Update() {
      distance = Vector3.Distance(transform.position, ballRb.transform.position);
      float x = Mathf.Clamp(ballRb.position.x, -1f, 1f);
      float y = Mathf.Clamp(ballRb.position.y, 0f, 2f);
      Vector3 targetPosition = new Vector3(x, y, transform.position.z);
      transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1.5f * Time.deltaTime);
      if (distance <= 0.1f) {
        ballRb.useGravity = true;
        float randomX = -transform.position.x + Random.Range(-1.5f, 1.5f);
        ballRb.linearVelocity = new Vector3(randomX, 3f, -3f);
        ball.Hit(false);
      }
    }
  }
}
