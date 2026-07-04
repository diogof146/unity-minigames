using UnityEngine;
using UnityEngine.AI;

namespace Karts {

  public class EnemyKart : MonoBehaviour, Kart {

    private NavMeshAgent agent;
    public Transform[] waypoints;

    public int currentLap { get; set; }
    public int currentWaypoint { get; set; }
    public float distance { get; set; }

    void Start() {
      agent = GetComponent<NavMeshAgent>();
      currentWaypoint = 0;
      currentLap = 1;
      agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void Update() {
      distance = Vector3.Distance(waypoints[currentWaypoint].position, transform.position);
    }

    private void MoveToWaypoint(Transform waypoint) {
      agent.SetDestination(waypoint.position);
    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Waypoint") && col.gameObject.name == "Way" + (currentWaypoint + 1)) {
        currentWaypoint++;
        if (currentWaypoint >= 5) {
          currentWaypoint = 0;
          currentLap++;
          if (currentLap == 4) {
            GameManager.instance.GameOver(gameObject.name);
          }
        }
        agent.SetDestination(waypoints[currentWaypoint].position);
      }
    }
  }

}
