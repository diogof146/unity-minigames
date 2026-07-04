using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

  public Texture2D backgroundImage;

  void Start() {
    Cursor.lockState = CursorLockMode.None;
  }

  void OnGUI() {
    if (backgroundImage != null) {
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundImage, ScaleMode.ScaleAndCrop);
    }

    GUI.skin.label.fontSize = 50;
    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
    GUI.skin.label.hover.textColor = Color.cyan;

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 700, 500, 100), "Play TurnBattle", GUI.skin.label)) {
      SceneManager.LoadScene("TurnBattle");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 550, 500, 100), "Play AirCombat", GUI.skin.label)) {
      SceneManager.LoadScene("AirCombat");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 400, 500, 100), "Play Fruits", GUI.skin.label)) {
      SceneManager.LoadScene("Fruits");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 100), "Play Saboteur", GUI.skin.label)) {
      SceneManager.LoadScene("Saboteur");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 100, 500, 100), "Play MobHouse", GUI.skin.label)) {
      SceneManager.LoadScene("MobHouse");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 + 50, 500, 100), "Play Robots", GUI.skin.label)) {
      SceneManager.LoadScene("Robots");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 + 200, 500, 100), "Play Karts", GUI.skin.label)) {
      SceneManager.LoadScene("Karts");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 + 350, 500, 100), "Quit", GUI.skin.label)) {
      Application.Quit();
    }
  }
}
