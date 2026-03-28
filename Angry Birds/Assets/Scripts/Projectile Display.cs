using UnityEngine;

public class ProjectileDisplay : MonoBehaviour
{
    public ProjectileManager projectileManager;

    public GameObject RocketPNG;
    public GameObject CannonBallPNG;
    public GameObject[] proj;
    
    void Start() {
        projectileManager = GameObject.Find("Projectile Manager").GetComponent<ProjectileManager>();

        int projNum = projectileManager.projectiles.Length;

        proj = new GameObject[projNum];

        for (int i = 0; i < projNum; i++) {
            if (projectileManager.projectiles[i] == 0) {
                proj[i] = Instantiate(CannonBallPNG, this.transform);
            }
            else if (projectileManager.projectiles[i] == 1) {
                proj[i] = Instantiate(RocketPNG, this.transform);
            }
            proj[i].transform.localPosition = new Vector3(40 * i, 0 ,0);
        }
    }
}
