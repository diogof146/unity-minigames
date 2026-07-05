using UnityEngine;

namespace TableTennis {

  public class Ball : MonoBehaviour {

    private Rigidbody rb;
    private Transform player;
    private Transform npc;
    private bool playerHit;
    private bool bounced;
    private bool scored;

    public Transform playerSpawn;
    public Transform npcSpawn;

    void Start() {
      rb = GetComponent<Rigidbody>();
      rb.useGravity = false;
      player = GameObject.FindWithTag("Player").transform;
      npc = GameObject.FindWithTag("Enemy").transform;
      bounced = false;
      int rand = Random.Range(0, 2);
      if (rand == 0) Spawn(true);
      else Spawn(false);
    }

    void Update() {

    }

    void OnCollisionEnter(Collision col) {
      if (scored) return;
      if (col.gameObject.name == "Net") {
        scored = true;
        if (playerHit) GameManager.instance.AddPoint(false);
        else GameManager.instance.AddPoint(true);
      }
      else if (col.collider.CompareTag("Floor")) {
        bounced = true;
      }
    }

    void OnTriggerEnter(Collider col) {
      if (scored) return;
      if (col.gameObject.name == "NpcVoid") {
        scored = true;
        if (bounced) GameManager.instance.AddPoint(true);
        else GameManager.instance.AddPoint(false);
      }
      else if (col.gameObject.name == "PlayerVoid") {
        scored = true;
        if (bounced) GameManager.instance.AddPoint(false);
        else GameManager.instance.AddPoint(true);
      }
    }

    public void Spawn(bool player) {
      rb.useGravity = false;
      rb.linearVelocity = Vector3.zero;
      rb.angularVelocity = Vector3.zero;
      scored = false;
      if (player) transform.position = playerSpawn.position;
      else transform.position = npcSpawn.position;
    }

    public void Hit(bool player) {
      playerHit = player;
      bounced = false;
      scored = false;
    }
  }
}
