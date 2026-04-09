using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public static bool gamePause = false;
    public GameObject pauseMenu;

    public Slider sfxSlider; 
    public Slider musicSlider; 
    public static float sfxVolume = 1f;
    public static float musicVolume = 1f;

    void Awake() {
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;
        Resume();
    }

    void Update() {
        sfxVolume = sfxSlider.value;
        musicVolume = musicSlider.value;


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace)) {
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
