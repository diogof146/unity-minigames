using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Robots {

  public class GameManager : MonoBehaviour {

    [HideInInspector]
    public bool isCaught;

    public static GameManager instance;

    public TMP_Text openPrompt;

    void Awake() { instance = this; }

    void Start() {
      isCaught = false;
    }

    void Update() {

    }

    public void CatchPlayer() {
      isCaught = true;
      GameOver();
    }

    public void GameOver() {
      SceneManager.LoadScene("RobotsGameOver");
    }

    public void ShowOpenPrompt() {
      openPrompt.gameObject.SetActive(true);
    }

    public void HideOpenPrompt() {
      if (openPrompt.gameObject.activeSelf) {
        openPrompt.gameObject.SetActive(false);
      }
    }
  }
}
