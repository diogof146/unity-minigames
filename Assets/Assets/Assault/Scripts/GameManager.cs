using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assault {

  public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [HideInInspector]
    public bool hasBullets;
    [HideInInspector]
    public bool isInSecondFloor;

    public Door door;
    public Transform enemySpawn;
    public GameObject enemyPrefab;

    public Transform[] waypoints;

    void Awake() { instance = this; }

    void Start() {
      hasBullets = false;
      SpawnEnemy();
    }

    void Update() {

    }

    public void CollectBullets() {
      hasBullets = true;
    }

    public void GameOver() {
      SceneManager.LoadScene("AssaultGameOver");
    }

    public void SpawnEnemy() {
      if (door != null) { door.Open(); }

      GameObject enemy = Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
      enemy.GetComponent<Enemy>().waypoints = waypoints;
      Invoke("CloseDoor", 3f);
    }

    private void CloseDoor() {
      if (door != null) {
        door.Close();
      }
    }
  }
}
