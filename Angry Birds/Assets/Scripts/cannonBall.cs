using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float Damage = 2;

    public LayerMask Ground;
    public LayerMask Enemy;
    public AudioSource cannonFireSFX;

    void Awake()
    {
        Ground = LayerMask.GetMask("Ground");
        Enemy = LayerMask.GetMask("Target");
        cannonFireSFX = GetComponent<AudioSource>();
        cannonFireSFX.volume = PauseMenu.sfxVolume * 0.354f;
    }

    void OnCollisionEnter(Collision collision)
    {
       if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            Damage = 1;
            Destroy(this.gameObject, 5f);
        }
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            Destroy(this.gameObject, 5f);
        }
    }
}
