using UnityEngine;

namespace AirCombat {
  public class MoveCamera : MonoBehaviour {

    public float sensitivity = 2f;
    private float x = 0f;
    private float y = 0f;

    void Start() {
      Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
      y += Input.GetAxis("Mouse X") * sensitivity;
      x -= Input.GetAxis("Mouse Y") * sensitivity;

      x = Mathf.Clamp(x, -90f, 90f);

      transform.eulerAngles = new Vector3(x, y, 0f);
    }
  }
}

