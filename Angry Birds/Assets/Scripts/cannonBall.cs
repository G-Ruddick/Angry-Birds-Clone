using UnityEngine;

public class cannonBall : MonoBehaviour
{
    public Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();

        FireProjectile();
    }

    void FireProjectile() {
        rb.AddForce(Vector3.up * 30, ForceMode.Impulse);
    }
}
