using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

  public Texture2D backgroundImage;

  void OnGUI() {
    if (backgroundImage != null) {
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundImage, ScaleMode.ScaleAndCrop);
    }

    GUI.skin.label.fontSize = 50;
    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
    GUI.skin.label.hover.textColor = Color.cyan;

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150, 500, 100), "Play Fruits", GUI.skin.label)) {
      SceneManager.LoadScene("Fruits");
    }

    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 + 50, 500, 100), "Quit", GUI.skin.label)) {
      Application.Quit();
    }
  }
}
