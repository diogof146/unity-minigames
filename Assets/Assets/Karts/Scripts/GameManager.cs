using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Karts {

  public class GameManager : MonoBehaviour {

    public Transform[] waypoints;
    public Transform[] startPoints;
    public Transform[] karts;

    public TMP_Text positionText;
    public TMP_Text lapTimerText;
    public TMP_Text currentLapText;

    public Camera mainCam;
    public Camera backCam;

    public static GameManager instance;

    [HideInInspector]
    public string winner;

    void Awake() {
      instance = this;
      int[] used = { 5, 5, 5, 5 };
      int random;

      for (int i = 0; i < 4; i++) {
        random = Random.Range(0, 4);

        while (used.Contains(random)) {
          random = Random.Range(0, 4);
        }
        used[i] = random;
        if (i <= 2) {
          NavMeshAgent agent = karts[i].GetComponent<NavMeshAgent>();
          agent.Warp(startPoints[random].position);
        }
        else {
          karts[i].position = startPoints[random].position;
        }
      }
    }

    void Update() {
      SortPositions();
      positionText.text = "Position: " + PlayerPosition() + "/4";
      currentLapText.text = "CurrentLap: " + PlayerLap();
      int lapTime = PlayerLapTimer();
      lapTimerText.text = lapTime > 0 ? "Last Lap Time: " + lapTime : "";
      if (Input.GetKeyDown(KeyCode.Space)) {
        mainCam.gameObject.SetActive(false);
        backCam.gameObject.SetActive(true);
      }
      if (Input.GetKeyUp(KeyCode.Space)) {
        backCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
      }
    }

    private void SortPositions() {
      for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 3; j++) {

          Kart kartA = karts[j].GetComponent<Kart>();
          Kart kartB = karts[j + 1].GetComponent<Kart>();

          bool shouldSwap = false;

          if (kartB.currentLap > kartA.currentLap) {
            shouldSwap = true;
          }
          else if (kartB.currentLap == kartA.currentLap && kartB.currentWaypoint > kartA.currentWaypoint) {
            shouldSwap = true;
          }
          else if (kartB.currentLap == kartA.currentLap && kartB.currentWaypoint == kartA.currentWaypoint && kartB.distance < kartA.distance) {
            shouldSwap = true;
          }

          if (shouldSwap) {
            Transform temp = karts[j];
            karts[j] = karts[j + 1];
            karts[j + 1] = temp;
          }
        }
      }
    }

    public int PlayerPosition() {
      for (int i = 0; i < karts.Length; i++) {
        if (karts[i].gameObject.name == "Blue") {
          return i + 1;
        }
      }
      return 4;
    }

    public int PlayerLap() {
      for (int i = 0; i < karts.Length; i++) {
        if (karts[i].gameObject.name == "Blue") {
          return karts[i].GetComponent<Kart>().currentLap;
        }
      }
      return 0;
    }

    public int PlayerLapTimer() {
      for (int i = 0; i < karts.Length; i++) {
        if (karts[i].gameObject.name == "Blue") {
          float timer = karts[i].GetComponent<PlayerKart>().lastLapTimer;
          return Mathf.RoundToInt(timer);
        }
      }
      return 0;
    }

    public void GameOver(string w) {
      winner = w;
      SceneManager.LoadScene("KartsGameOver");
    }
  }
}
