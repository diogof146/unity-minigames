using UnityEngine;
using UnityEngine.AI;

namespace Assault {

  public class Player : MonoBehaviour {

    private NavMeshAgent agent;
    private Camera cam;
    public GameObject bulletPrefab;
    public Transform attackPoint;
    public Transform spawnPoint;

    void Start() {
      agent = GetComponent<NavMeshAgent>();
      cam = Camera.main;
    }

    void Update() {
      if (Input.GetKeyDown(KeyCode.Mouse0)) {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
          if (hit.collider.CompareTag("Floor")) {
            agent.SetDestination(hit.point);
            agent.transform.LookAt(hit.point);
          }
        }
      }

      if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.hasBullets) {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
      }
    }

    void OnTriggerEnter(Collider col) {
      if (col.CompareTag("Waypoint")) {
        GameManager.instance.isInSecondFloor = true;
      }
      else if (col.CompareTag("Finish")) {
        GameManager.instance.GameOver();
      }
    }

    void OnTriggerExit(Collider col) {
      if (col.CompareTag("Waypoint")) {
        GameManager.instance.isInSecondFloor = false;
      }
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Bullet")) {
        agent.Warp(spawnPoint.position);
      }
    }

  }
}
