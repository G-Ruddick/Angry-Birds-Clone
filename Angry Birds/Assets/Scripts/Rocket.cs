using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Damage = 5;

    public LayerMask Ground;
    public LayerMask Enemy;

    public GameObject explosionRadius;
    public AudioClip explosion;

    void Start() {
        Ground = LayerMask.GetMask("Ground");
        Enemy = LayerMask.GetMask("Target");

        explosionRadius.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            explosionRadius.SetActive(true);
            AudioSource.PlayClipAtPoint(explosion, new Vector3(0, 0, 0));
            Destroy(this.gameObject, .05f);
        }
        if (((1 << collision.gameObject.layer) & Enemy) != 0)
        {
            explosionRadius.SetActive(true);
            AudioSource.PlayClipAtPoint(explosion, new Vector3(0, 0, 0));
            Destroy(this.gameObject, .05f);
        }
    }
}
