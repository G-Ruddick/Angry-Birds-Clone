using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int NumofEnemies;

    public WinLoseScreen winLoseScreen;

    void Start()
    {
        winLoseScreen = GameObject.Find("Canvas").GetComponent<WinLoseScreen>();
    }

    void Update () {
        if (NumofEnemies == 0) {
            winLoseScreen.WinScreen.SetActive(true);
        }
    }
}
