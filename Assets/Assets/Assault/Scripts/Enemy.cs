using UnityEngine;
using UnityEngine.AI;

namespace Assault {

  public class Enemy : MonoBehaviour {

    [HideInInspector]
    public Transform[] waypoints;
    private int current;
    private NavMeshAgent agent;
    private Transform player;
    private float distance;
    public GameObject bulletPrefab;
    public Transform attackPoint;
    private float shotCooldown;
    private float wpDistance;

    void Start() {
      agent = GetComponent<NavMeshAgent>();
      player = GameObject.FindWithTag("Player").transform;
      current = 0;
    }

    void Update() {
      distance = Vector3.Distance(transform.position, player.position);
      wpDistance = Vector3.Distance(transform.position, waypoints[current].position);

      if (wpDistance <= 2f) { current++; }
      if (current >= 4) { current = 0; }

      if (GameManager.instance.isInSecondFloor && distance <= 5f) {
        agent.SetDestination(player.position);
        transform.LookAt(player);
      }
      else {
        agent.SetDestination(waypoints[current].position);
      }

      if (distance <= 3f && shotCooldown <= 0) {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        shotCooldown = 1f;
      }

      shotCooldown -= Time.deltaTime;
    }
  }
}
