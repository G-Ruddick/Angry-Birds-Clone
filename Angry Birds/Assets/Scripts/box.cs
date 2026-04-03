using UnityEngine;

public class box : MonoBehaviour
{
    public float Health = 2;

    public LayerMask cannonball;
    public LayerMask rocket;

    public AudioClip hit;

    public Transform cameraPos;

    void Start()
    {
        cannonball = LayerMask.GetMask("cannonball");
        rocket = LayerMask.GetMask("rocket");
        cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & cannonball) != 0)
        {
            Health -= collision.gameObject.GetComponent<CannonBall>().Damage;
            AudioSource.PlayClipAtPoint(hit, cameraPos.position, .4f);
        }
        if (((1 << collision.gameObject.layer) & rocket) != 0)
        {
            Health -= collision.gameObject.GetComponent<Rocket>().Damage;
            AudioSource.PlayClipAtPoint(hit, cameraPos.position, .4f);
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
