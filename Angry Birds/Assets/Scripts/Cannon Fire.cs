using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {
    public GameObject cannon;
    public Camera camera;
    public ProjectileManager projectileManager;
    public ProjectileDisplay projDisplay;

    public GameObject cannonBall;
    public GameObject rocket;
    public GameObject currentProjectile;
    public GameObject PathMarker;

    public Vector3 mousePosition;
    public Vector3 direction;
    public float angle;

    public int projectilesUsed;
    public int numOfProjectiles;

    void Awake() {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        projectileManager = GameObject.Find("Projectile Manager").GetComponent<ProjectileManager>();
        projDisplay = GameObject.Find("Projectiles").GetComponent<ProjectileDisplay>();

        projectilesUsed = 0;
        numOfProjectiles = projectileManager.projectiles.Length;

        StartCoroutine(projectilePath());
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
                
                Destroy(projDisplay.proj[projectilesUsed]);
                projDisplay.transform.position -= new Vector3(40, 0 ,0);

                projectilesUsed++;
            }  
        }
    }

    void fireCannon() {
        GameObject projectile = Instantiate(currentProjectile, cannon.transform.position, cannon.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);
    }

    IEnumerator projectilePath()
    {
        while (true)
        {
            Vector3 oldDirection = direction;
            GameObject marker = Instantiate(PathMarker, cannon.transform.position, cannon.transform.rotation);
            marker.GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);
            
            Destroy(marker, 1f);

            yield return new WaitForSeconds(.15f);
        }
    }
}
