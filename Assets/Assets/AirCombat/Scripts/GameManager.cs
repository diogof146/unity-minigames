using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public static GameManager instance;
  [HideInInspector]
  public static int score;

  public Transform[] waypoints;

  public GameObject ovniPrefab;

  public TMP_Text scoreText;

  void Awake() { instance = this; }

  void Start() {
    score = 0;
    InvokeRepeating("SpawnOvni", 1f, 1f);
  }

  void Update() {
    scoreText.text = "Score: " + score;
  }

  public void EndGame() {
    SceneManager.LoadScene("AirCombatGameOver");
  }

  public void KillOvni() {
    score += 10;
  }

  private void SpawnOvni() {
    float randomX = Random.Range(waypoints[0].rotation.x, waypoints[1].position.x);
    float randomZ = Random.Range(waypoints[0].rotation.z, waypoints[1].position.z);
    Vector3 position = new Vector3(randomX, waypoints[0].position.y, randomZ);
    Instantiate(ovniPrefab, position, waypoints[0].rotation);
  }

}
