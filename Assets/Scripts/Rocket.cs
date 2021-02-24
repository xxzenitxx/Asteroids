using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public Transform shootSpawn;
    public GameObject shoot;
    public float shootRate;
    private float shootTime;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >shootTime)
        {
            shootTime = Time.time + shootRate;
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = transform.rotation * Vector2.up;
        rb.AddForce(movement * moveVertical * speed);
        rb.AddTorque(-moveHorizontal * speed);

        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, xMin, xMax), 
            Mathf.Clamp(rb.position.y, yMin, yMax)
            );
    }
    public void ResetRocket()
    {
        transform.position = new Vector2(0f, 0f);
        rb.velocity = new Vector2(0f, 0f);
    }
}