using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MobHouse {

  public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [HideInInspector]
    public bool hasKey;
    [HideInInspector]
    public bool hasGun;
    [HideInInspector]
    public int bulletCount;

    public TMP_Text bulletText;
    public TMP_Text keyText;
    public TMP_Text prompt;

    [HideInInspector]
    public bool playerDied;

    public GameObject gun;

    void Awake() { instance = this; }

    void Start() {
      hasKey = false;
      hasGun = false;
      bulletCount = 0;
      keyText.text = "";
      playerDied = false;
    }

    void Update() {
      bulletText.text = "Bullets: " + bulletCount;
      if (hasKey) {
        keyText.text = "Key Collected";
      }
    }

    public void CollectKey() {
      hasKey = true;
    }

    public void CollectGun() {
      gun.SetActive(true);
      hasGun = true;
    }

    public void CollectBullet() {
      bulletCount++;
    }

    public void KillPlayer() {
      playerDied = true;
      EndGame();
    }

    public void EndGame() {
      SceneManager.LoadScene("MobHouseGameOver");
    }

    public void ShowPrompt() {
      prompt.gameObject.SetActive(true);
    }
    public void HidePrompt() {
      prompt.gameObject.SetActive(false);
    }
  }
}
