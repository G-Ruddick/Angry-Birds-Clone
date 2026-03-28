using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public int NumofEnemies;

    public WinLoseScreen winLoseScreen;
    public ProjectileManager projectileManager;
    public CannonFire cannonFire;

    void Start()
    {
        winLoseScreen = GameObject.Find("Canvas").GetComponent<WinLoseScreen>();
        projectileManager = GameObject.Find("Projectile Manager").GetComponent<ProjectileManager>();
        cannonFire = GameObject.Find("Cannon").GetComponent<CannonFire>();
    }

    void Update () {
        if (NumofEnemies == 0) {
            winLoseScreen.WinScreen.SetActive(true);
        }
        else {
            if (cannonFire.projectilesUsed == projectileManager.projectiles.Length) {
                StartCoroutine(loseScreen());
            }
        }
    }
    
    IEnumerator loseScreen() {
        yield return new WaitForSeconds(5f);
        if (NumofEnemies != 0) {
            winLoseScreen.LoseScreen.SetActive(true);
        }
    }
}
