using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fruits {

  public class GameOver : MonoBehaviour {
    void Start() {
      Invoke("MainMenu", 3f);
    }

    private void MainMenu() {
      SceneManager.LoadScene("MainMenu");
    }

    void OnGUI() {
      GUI.skin.label.fontSize = 70;
      GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 350, 500, 500), "Game Over\n\nScore: " + GameManager.score, GUI.skin.label);
    }
  }

}
