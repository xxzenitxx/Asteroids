using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb.velocity = (transform.rotation * Vector2.up * speed);
    }
}