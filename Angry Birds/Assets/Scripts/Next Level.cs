using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.GetActiveScene().name == "Lv_1") {
            LevelManager.completeLv1 = true;
        }
        else if (SceneManager.GetActiveScene().name == "Lv_2") {
            LevelManager.completeLv2 = true;
        }
    }
}
