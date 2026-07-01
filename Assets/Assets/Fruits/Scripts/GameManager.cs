using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fruits {

  public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Transform left;
    public Transform right;

    [HideInInspector]
    public static int score;
    private int lives = 3;
    private float nextTire = 5f;

    public GameObject applePrefab;
    public GameObject tirePrefab;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    void Awake() { instance = this; }

    void Start() {
      score = 0;
      InvokeRepeating("SpawnApple", 2f, 2f);
    }

    void Update() {
      if (nextTire <= 0) { SpawnTire(); }
      nextTire -= Time.deltaTime;

      scoreText.text = "Score: " + score.ToString();
      livesText.text = "Lives: " + lives.ToString();
    }

    public void AddScore(int s) {
      score += s;
    }

    public void LoseLife() {
      lives--;

      if (lives <= 0) { GameOver(); }
    }

    public void GameOver() {
      SceneManager.LoadScene("FruitsGameOver");
    }

    private void SpawnApple() {
      float x = Random.Range(left.position.x, right.position.x);
      Vector3 position = new Vector3(x, left.position.y, left.position.z);
      Instantiate(applePrefab, position, left.rotation);
    }

    private void SpawnTire() {
      int rand = Random.Range(0, 2);
      Vector3 tirePos;

      if (rand == 0) {
        tirePos = left.position;
        GameObject tire = Instantiate(tirePrefab, tirePos, left.rotation);
        tire.GetComponent<Tire>().Rotate("left");
      }
      else {
        tirePos = right.position;
        GameObject tire = Instantiate(tirePrefab, tirePos, right.rotation);
        tire.GetComponent<Tire>().Rotate("right");
      }

      nextTire += Random.Range(3f, 5f);
    }
  }
}
