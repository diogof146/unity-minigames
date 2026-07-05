using UnityEngine;

namespace TableTennis {

  public class PlayerRacket : MonoBehaviour {

    public Rigidbody ballRb;
    public Ball ball;
    private float speed = 1.3f;
    private float distance;

    void Start() {
      ballRb = ballRb.GetComponent<Rigidbody>();
      ball = ball.GetComponent<Ball>();
    }

    void Update() {
      distance = Vector3.Distance(transform.position, ballRb.transform.position); ;

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.Space) && distance <= 0.3f) {
        ballRb.useGravity = true;
        ballRb.linearVelocity = new Vector3(-transform.position.x * 3f, 2f, 3f);
        ball.Hit(true);
      }
    }
  }
}
