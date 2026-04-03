using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Damage = 5;

    public LayerMask Ground;
    public LayerMask Enemy;
    

    public GameObject explosionRadius;
    public AudioClip explosion;
    public AudioSource cannonFireSFX;

    public Transform cameraPos;
    

    void Awake() {
        Ground = LayerMask.GetMask("Ground");
        Enemy = LayerMask.GetMask("Target");

        cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
        
        cannonFireSFX = GetComponent<AudioSource>();
        cannonFireSFX.volume = PauseMenu.sfxVolume * 0.354f;

        explosionRadius.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            explosionRadius.SetActive(true);
            AudioSource.PlayClipAtPoint(explosion, cameraPos.position, PauseMenu.sfxVolume * .3f);
            Destroy(this.gameObject, .05f);
        }
        if (((1 << collision.gameObject.layer) & Enemy) != 0)
        {
            explosionRadius.SetActive(true);
            AudioSource.PlayClipAtPoint(explosion, cameraPos.position, PauseMenu.sfxVolume * .3f);
            Destroy(this.gameObject, .05f);
        }
    }
}
