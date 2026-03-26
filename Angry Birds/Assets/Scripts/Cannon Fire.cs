using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public GameObject cannon;
    public Camera camera;

    public Vector3 mousePosition;
    public Vector3 direction;
    public float angle;

    void Start() {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void FixedUpdate() {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        
        direction = mousePosition - cannon.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
        cannon.transform.rotation = Quaternion.Euler(angle, 90, 90);
    }
}
