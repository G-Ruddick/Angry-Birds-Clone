using UnityEngine;

public class Brick : MonoBehaviour
{
    public float Health = 3;
    
    public LayerMask cannonball;
    public LayerMask rocket;

    public AudioClip hit;

    void Start()
    {
        cannonball = LayerMask.GetMask("cannonball");
        rocket = LayerMask.GetMask("rocket");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & cannonball) != 0)
        {
            Health -= collision.gameObject.GetComponent<CannonBall>().Damage;
            AudioSource.PlayClipAtPoint(hit, new Vector3(0, 0, 0));
        }
        if (((1 << collision.gameObject.layer) & rocket) != 0)
        {
            Health -= collision.gameObject.GetComponent<Rocket>().Damage;
            AudioSource.PlayClipAtPoint(hit, new Vector3(0, 0, 0));
        }
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject, .2f);
        }
    }
}
