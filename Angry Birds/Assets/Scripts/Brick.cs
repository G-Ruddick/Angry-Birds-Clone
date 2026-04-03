using UnityEngine;

public class Brick : MonoBehaviour
{
    public float Health = 3;
    
    public LayerMask cannonball;
    public LayerMask rocket;

    public Transform cameraPos;

    public AudioClip hit;

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
            AudioSource.PlayClipAtPoint(hit, cameraPos.position, PauseMenu.sfxVolume * .5f);
        }
        if (((1 << collision.gameObject.layer) & rocket) != 0)
        {
            Health -= collision.gameObject.GetComponent<Rocket>().Damage;
            AudioSource.PlayClipAtPoint(hit, cameraPos.position, PauseMenu.sfxVolume * .5f);
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
