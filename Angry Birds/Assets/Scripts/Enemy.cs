using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 2;

    public LayerMask cannonball;
    public LayerMask rocket;
    public LayerMask ground;

    void Start()
    {
        cannonball = LayerMask.GetMask("cannonball");
        rocket = LayerMask.GetMask("rocket");
        ground = LayerMask.GetMask("Ground");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & cannonball) != 0)
        {
            Health -= collision.gameObject.GetComponent<CannonBall>().Damage;
        }
        if (((1 << collision.gameObject.layer) & rocket) != 0)
        {
            Health -= collision.gameObject.GetComponent<Rocket>().Damage;
        }
        if (((1 << collision.gameObject.layer) & ground) != 0)
        {
            Health--;
        }
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject, .01f);
        }
    }
}
