using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FarWestBank {

  public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [HideInInspector]
    public int moneyCollected;

    public TMP_Text robbedText;
    public TMP_Text moneyText;
    public TMP_Text earnedText;
    public TMP_Text bulletsText;

    public GameObject burglarPrefab;
    public GameObject clientPrefab;
    [HideInInspector]
    public bool wasSuccessful;

    private Player player;

    public Door[] doors;

    void Awake() { instance = this; }

    void Start() {
      moneyCollected = 0;
      player = GameObject.Find("Player").GetComponent<Player>();
      InvokeRepeating("SpawnRandom", 3f, 3f);
    }

    void Update() {
      moneyText.text = "Total Money: " + moneyCollected + "$";
      bulletsText.text = player.bullets + "/6";
      if (moneyCollected >= 1000) {
        wasSuccessful = true;
        GameOver();
      }
    }

    private void SpawnRandom() {
      int rand = Random.Range(0, 2);
      int door = Random.Range(0, doors.Length);
      if (rand == 0) {
        doors[door].Spawn(burglarPrefab);
      }
      else {
        doors[door].Spawn(clientPrefab);
      }
    }

    public void GetRobbed() {
      robbedText.gameObject.SetActive(true);
      moneyCollected = 0;
      Invoke("HideRobbed", 1f);
    }

    public void AddMoney() {
      earnedText.gameObject.SetActive(true);
      moneyCollected += 100;
      Invoke("HideEarned", 1f);
    }

    public void GameOver() {
      SceneManager.LoadScene("FarWestBankGameOver");
    }

    private void HideEarned() { earnedText.gameObject.SetActive(false); }
    private void HideRobbed() { robbedText.gameObject.SetActive(false); }
  }
}
