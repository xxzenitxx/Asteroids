using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public Gameplay gameplay;
    public GameObject asteroid;
    public Rigidbody2D rb;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float speed;
    private int generation;
    private float scale = 1f;

    void Start()
    {
        rb.velocity = transform.rotation * Random.insideUnitSphere * speed;
    }
    void Update()
    {
        var position = transform.position;
        if (position.x < xMin)
            position.x = xMax;
        if (position.y < yMin)
            position.y = yMax;
        if (position.x > xMax)
            position.x = xMin;
        if (position.y > yMax)
            position.y = yMin;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rocket")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameplay.UpdateLives();
        }
        if (collision.tag =="Bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            scale = scale / 2f;
            Destroy(gameObject, 0.01f);
            if (generation < 2)
            {
                int newGeneration = generation + 1;
                for (int i = 0; i < 2; i++)
                {
                    GameObject asteroidClone = Instantiate(asteroid, transform.position, Quaternion.identity);
                    asteroidClone.transform.localScale = new Vector2(asteroidClone.transform.localScale.x * 0.5f, asteroidClone.transform.localScale.y * 0.5f);
                    asteroidClone.GetComponent<Asteroid>().SetGeneration(newGeneration);
                    asteroidClone.SetActive(true);
                }
            }
            Destroy(gameObject, 0.001f);
            gameplay.UpdateScore();
        }
    }
    public void SetGeneration(int newgeneration)
    {
        generation = newgeneration;
    }
}