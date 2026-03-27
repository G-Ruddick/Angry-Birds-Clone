using UnityEngine;

public class Brick : MonoBehaviour
{
    public float Health = 3;
    
    public LayerMask cannonball;
    public LayerMask rocket;

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
        }
        if (((1 << collision.gameObject.layer) & rocket) != 0)
        {
            Health -= collision.gameObject.GetComponent<Rocket>().Damage;
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
