using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TableTennis {

  public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public int playerScore;
    [HideInInspector]
    public int npcScore;

    public Ball ball;

    public TMP_Text playerText;
    public TMP_Text npcText;
    public TMP_Text pointText;

    [HideInInspector]
    public string winner;

    void Awake() { instance = this; }

    void Start() {
      ball = ball.GetComponent<Ball>();
    }

    void Update() {
      playerText.text = "Player Score: " + playerScore;
      npcText.text = "NPC Score: " + npcScore;
      if (playerScore == 5 || npcScore == 5) { GameOver(); }
    }

    public void AddPoint(bool player) {
      if (player) {
        playerScore++;
        pointText.text = "Player Scored!";
      }
      else {
        npcScore++;
        pointText.text = "NPC Scored!";
      }
      pointText.gameObject.SetActive(true);
      StartCoroutine(SpawnBall(player));
    }

    private IEnumerator SpawnBall(bool player) {
      yield return new WaitForSeconds(1f);
      pointText.gameObject.SetActive(false);
      ball.Spawn(player);
    }


    private void GameOver() {
      if (playerScore >= 5) winner = "Player";
      else winner = "NPC";
      SceneManager.LoadScene("TableTennisGameOver");
    }
  }
}
