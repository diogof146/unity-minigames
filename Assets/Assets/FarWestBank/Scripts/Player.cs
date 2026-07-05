using UnityEngine;

namespace FarWestBank {

  public class Player : MonoBehaviour {

    private Rigidbody rb;
    private float speed = 10f;
    private bool grounded;
    private bool jumping;
    private float shotCooldown;
    public Animator gun;
    [HideInInspector]
    public int bullets;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    private Camera cam;
    private bool reloading;

    void Start() {
      rb = GetComponent<Rigidbody>();
      bullets = 6;
      cam = Camera.main;
      shotCooldown = 0;
      Physics.gravity = new Vector3(0, -40f, 0);
    }

    void Update() {
      if (Input.GetKey(KeyCode.W)) {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.A)) {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.D)) {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.S)) {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.Space) && grounded) {
        jumping = true;
      }
      if (Input.GetKeyDown(KeyCode.Mouse0) && shotCooldown <= 0 && bullets > 0 && !reloading) {
        Shoot();
      }
      if (Input.GetKeyDown(KeyCode.R) && bullets <= 5) {
        Reload();
      }
      shotCooldown -= Time.deltaTime;
    }

    private void Reload() {
      gun.SetTrigger("reload");
      bullets = 6;
      reloading = true;
      Invoke("FinishReload", 1f);
    }

    private void Shoot() {
      gun.SetTrigger("shoot");
      bullets--;
      Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
      Vector3 target;
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit)) {
        target = hit.point;
      }
      else {
        target = ray.GetPoint(50f);
      }
      GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
      bullet.transform.LookAt(target);
      shotCooldown = 0.5f;
    }

    void FinishReload() { reloading = false; }

    void FixedUpdate() {
      if (jumping) {
        rb.AddForce(Vector3.up * 8f, ForceMode.Impulse);
        jumping = false;
      }
    }

    void OnCollisionEnter(Collision col) {
      if (col.collider.CompareTag("Floor")) {
        grounded = true;
      }
    }

    void OnCollisionExit(Collision col) {
      if (col.collider.CompareTag("Floor")) {
        grounded = false;
      }
    }
  }
}
