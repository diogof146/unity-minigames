using UnityEngine;

namespace AirCombat {
  public class AirPlane : MonoBehaviour {

    private float speed = 100f;
    private float rotationSpeed = 100f;
    private Transform cam;

    private float rotation = 0f;

    public Transform attackPoint;
    public GameObject bulletPrefab;

    void Start() {
      cam = Camera.main.transform;
    }

    void Update() {
      if (Input.GetKey(KeyCode.A)) rotation += rotationSpeed * Time.deltaTime;
      if (Input.GetKey(KeyCode.D)) rotation -= rotationSpeed * Time.deltaTime;

      transform.rotation = cam.rotation;
      transform.Rotate(0, 0, rotation);

      if (Input.GetKey(KeyCode.W)) {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.Space)) {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
      }

      if (Input.GetKeyDown(KeyCode.Mouse0)) {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Vector3 target;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
          target = hit.point;
        }
        else {
          target = ray.GetPoint(10000f);
        }
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        bullet.transform.LookAt(target);
      }
    }

    void OnCollisionEnter(Collision col) {
      if (!col.collider.CompareTag("Bullet")) {
        GameManager.instance.EndGame();
      }
    }
  }
}
