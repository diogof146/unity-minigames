using UnityEngine;
using UnityEngine.SceneManagement;

namespace FarWestBank {

  public class GameOver : MonoBehaviour {
    void Start() {
      Invoke("MainMenu", 3f);
    }

    private void MainMenu() {
      SceneManager.LoadScene("MainMenu");
    }

    void OnGUI() {
      Physics.gravity = new Vector3(0, -9.81f, 0);
      GUIStyle style = new GUIStyle(GUI.skin.label);
      style.fontSize = 70;
      style.alignment = TextAnchor.MiddleCenter;

      Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

      if (GameManager.instance.wasSuccessful) {
        GUI.Label(screenRect, "Game Over\n\nCongratulations You Collected 1000$", style);
      }
      else {
        GUI.Label(screenRect, "Game Over\n\nYou Killed an Innocent Person!", style);
      }
    }
  }

}


