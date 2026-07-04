using UnityEngine;

namespace Karts {

  public class PlayerKart : MonoBehaviour, Kart {

    private Rigidbody rb;

    private float acceleration = 25f;
    private float maxSpeed = 55f;
    private float turnSpeed = 40f;
    private float tireGrip = 0.95f;

    public Transform[] waypoints;

    public int currentLap { get; set; }
    public int currentWaypoint { get; set; }
    public float distance { get; set; }

    [HideInInspector]
    public float lastLapTimer;

    private float lapStart;

    void Start() {
      rb = GetComponent<Rigidbody>();
      rb.linearDamping = 0f;
      currentWaypoint = 0;
      currentLap = 1;
      lastLapTimer = 0;
      lapStart = Time.time;
    }

    void Update() {
      distance = Vector3.Distance(waypoints[currentWaypoint].position, transform.position);
    }

    void FixedUpdate() {
      Vector3 localVelocity = transform.InverseTransformDirection(rb.linearVelocity);
      localVelocity.x *= (1f - tireGrip);
      rb.linearVelocity = transform.TransformDirection(localVelocity);

      float currentSpeed = Vector3.Dot(rb.linearVelocity, transform.forward);

      if (Input.GetKey(KeyCode.W)) {
        if (currentSpeed < maxSpeed) {
          rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);
        }
      }
      else if (Input.GetKey(KeyCode.S)) {
        if (currentSpeed > 1f) {
          rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime * 4f);
        }
        else if (currentSpeed > -maxSpeed) {
          rb.AddForce(-transform.forward * acceleration, ForceMode.Acceleration);
        }
      }
      else {
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime * 1.5f);
      }

      if (Input.GetKey(KeyCode.A)) {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, -turnSpeed * Time.fixedDeltaTime, 0));
      }
      if (Input.GetKey(KeyCode.D)) {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnSpeed * Time.fixedDeltaTime, 0));
      }
    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Waypoint") && col.transform == waypoints[currentWaypoint].transform) {
        currentWaypoint++;
        if (currentWaypoint >= 5) {
          currentWaypoint = 0;
          currentLap++;
          lastLapTimer = Time.time - lapStart;
          lapStart = Time.time;
          if (currentLap == 4) {
            GameManager.instance.GameOver(gameObject.name);
          }
        }
      }
    }
  }
}
