using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject pauseMenu;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Pressed");
            if (gamePause) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        gamePause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    void Pause() {
        gamePause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
