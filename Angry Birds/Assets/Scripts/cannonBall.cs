using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float Damage = 2;

    public LayerMask Ground;
    public LayerMask Enemy;

    void Start()
    {
        Ground = LayerMask.GetMask("Ground");
        Enemy = LayerMask.GetMask("Target");
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
