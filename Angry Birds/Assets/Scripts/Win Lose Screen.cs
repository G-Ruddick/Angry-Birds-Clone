using UnityEngine;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;

    void Awake() {
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
    }
}
