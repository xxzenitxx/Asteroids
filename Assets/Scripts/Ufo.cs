using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public GameObject explosion;
    public Gameplay gameplay;
    public GameObject ufo;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float speed;

    void Start()
    {
        rb.velocity = transform.rotation * Random.insideUnitSphere * speed;
        StartCoroutine(ChangeRotation());
    }

    // Update is called once per frame
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

    public IEnumerator SpawnUfo()
    {
        while(true)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-10, 10), 10);
            GameObject asteroidClone = Instantiate(ufo, spawnPos, Quaternion.identity);
            asteroidClone.SetActive(true);
            yield return new WaitForSeconds(15.0f);
        }
    }

    public IEnumerator ChangeRotation()
    {
        while (true)
        {
            rb.velocity = transform.rotation * Random.insideUnitSphere * speed;
            yield return new WaitForSeconds(4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rocket")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameplay.UpdateLives();
        }
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            gameplay.UpdateScore();
        }
    }
}
