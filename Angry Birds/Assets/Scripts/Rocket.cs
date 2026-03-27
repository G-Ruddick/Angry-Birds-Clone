using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Damage = 5;

    public LayerMask Ground;
    public LayerMask Enemy;

    public GameObject explosionRadius;

    void Start()
    {
        Ground = LayerMask.GetMask("Ground");
        Enemy = LayerMask.GetMask("Target");

        explosionRadius.SetActive(false);

    }

    void OnCollisionEnter(Collision collision)
    {
        explosionRadius.SetActive(true);

        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            Destroy(this.gameObject, .05f);
        }
        if (((1 << collision.gameObject.layer) & Enemy) != 0)
        {
            Destroy(this.gameObject, .05f);
        }
    }
}
