using UnityEngine;
using UnityEngine.AI;

namespace TurnBattle {

  public class Piece : MonoBehaviour {

    private GameObject target;
    private float distance;
    public GameObject bulletPrefab;
    public Transform attackPoint;
    private NavMeshAgent agent;
    private bool shot;

    void Start() {
      agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
      if (target == null) { return; }

      distance = Vector3.Distance(transform.position, target.transform.position);

      if (distance <= 2f && !shot) {
        Kill();
        shot = true;
      }
    }

    public void Attack(GameObject piece) {
      target = piece;
      shot = false;
    }

    private void Kill() {
      transform.LookAt(target.transform.position);
      Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
    }

    public bool HasArrived() {
      if (agent.velocity == Vector3.zero && agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending) {
        return true;
      }
      return false;
    }
  }
}
