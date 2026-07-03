using UnityEngine;

namespace MobHouse {

  public class Enemy : MonoBehaviour {

    public Transform[] waypoints;
    private int currentWaypoint;
    private float distance;

    public GameObject bulletPrefab;
    public Transform attackPoint;

    private float speed = 1f;
    private Vector3 lookPoint;

    private bool seesPlayer;
    private float shotCooldown = 0f;

    void Start() {
      currentWaypoint = 0;
      seesPlayer = false;
    }

    void Update() {
      distance = Vector3.Distance(transform.position, waypoints[currentWaypoint].position);

      if (distance <= 1f) { currentWaypoint++; }
      if (currentWaypoint >= 2) { currentWaypoint = 0; }

      lookPoint = new Vector3(waypoints[currentWaypoint].position.x, transform.position.y, waypoints[currentWaypoint].position.z);
      transform.LookAt(lookPoint);
      transform.Translate(Vector3.forward * speed * Time.deltaTime);

      RaycastHit hit;
      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f)) {
        if (hit.collider.CompareTag("Player")) {
          seesPlayer = true;
        }
      }
      else {
        seesPlayer = false;

      }

      if (seesPlayer && shotCooldown <= 0) {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        shotCooldown = 0.5f;
      }

      shotCooldown -= Time.deltaTime;

    }
  }
}
