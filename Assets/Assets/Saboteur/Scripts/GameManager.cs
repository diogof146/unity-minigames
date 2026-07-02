using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Saboteur {
  public class GameManager : MonoBehaviour {

    [HideInInspector]
    public bool hasFirstKey;
    [HideInInspector]
    public bool hasSecondKey;

    public static GameManager instance;

    public TMP_Text firstKeyIndicator;
    public TMP_Text secondKeyIndicator;
    public TMP_Text openPrompt;
    public TMP_Text bombPrompt;
    public TMP_Text countdownTimer;

    private bool isPlanted;
    private float countdown;

    public GameObject robotPrefab;
    public Transform robotSpawn;

    [HideInInspector]
    public bool hasEscaped;

    void Awake() { instance = this; }

    void Start() {
      hasFirstKey = false;
      hasSecondKey = false;
      isPlanted = false;
      countdown = 10;
      hasEscaped = false;
      InvokeRepeating("SpawnRobot", 0f, 3f);
    }

    void Update() {
      if (isPlanted) {
        countdown -= Time.deltaTime;
        countdownTimer.text = Mathf.CeilToInt(countdown).ToString();
      }
      if (countdown <= 0) {
        SceneManager.LoadScene("SaboteurGameOver");
      }
    }

    public void CollectFirstKey() {
      hasFirstKey = true;
      firstKeyIndicator.gameObject.SetActive(true);
    }
    public void CollectSecondKey() {
      hasSecondKey = true;
      secondKeyIndicator.gameObject.SetActive(true);
    }

    public void ShowOpenPrompt() {
      openPrompt.gameObject.SetActive(true);
    }
    public void ShowBombPrompt() {
      bombPrompt.gameObject.SetActive(true);
    }
    public void HideOpenPrompt() {
      openPrompt.gameObject.SetActive(false);
    }
    public void HideBombPrompt() {
      bombPrompt.gameObject.SetActive(false);
    }
    public void StartBombCountdown() {
      isPlanted = true;
      countdownTimer.gameObject.SetActive(true);
    }
    public void Escape() {
      hasEscaped = true;
      SceneManager.LoadScene("SaboteurGameOver");
    }
    public void CatchPlayer() {
      SceneManager.LoadScene("SaboteurGameOver");
    }

    public void SpawnRobot() {
      Instantiate(robotPrefab, robotSpawn.position, robotSpawn.rotation);
    }
  }
}
