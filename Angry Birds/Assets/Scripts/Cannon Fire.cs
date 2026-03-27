using UnityEngine;

public class CannonFire : MonoBehaviour {
    public GameObject cannon;
    public Camera camera;
    public ProjectileManager projectileManager;

    public GameObject cannonBall;
    public GameObject rocket;
    public GameObject currentProjectile;

    public Vector3 mousePosition;
    public Vector3 direction;
    public float angle;

    int projectilesUsed;
    int numOfProjectiles;

    void Awake() {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        projectileManager = GameObject.Find("Projectile Manager").GetComponent<ProjectileManager>();

        projectilesUsed = 0;
        numOfProjectiles = projectileManager.projectiles.Length;
    }

    void FixedUpdate() {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        
        direction = mousePosition - cannon.transform.position;
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
        cannon.transform.rotation = Quaternion.Euler(angle, 90, 90);
    }
    void Update() {
        if (projectilesUsed != numOfProjectiles)
        {
            if (projectileManager.projectiles[projectilesUsed] == 1)
            {
                currentProjectile = rocket;        
            }
            else if (projectileManager.projectiles[projectilesUsed] == 0)
            {
                currentProjectile = cannonBall;        
            }

            if (Input.GetMouseButtonDown(0)) {
                fireCannon();
                projectilesUsed++;
            }  
        }
    }

    void fireCannon() {
        GameObject projectile = Instantiate(currentProjectile, cannon.transform.position, cannon.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(5f * direction, ForceMode.Impulse);


    }
}
