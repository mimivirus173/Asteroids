using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject asteroid;

    System.Random rnd = new System.Random();

    // Delete self when colliding with bullet or outer wall
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Bullet
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(this.gameObject);
        }

        // Outer walls
        if (collision.gameObject.name == "OuterWallUp")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "OuterWallDown")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "OuterWallLeft")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "OuterWallRight")
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Start in a random position
        transform.position = new Vector2(rnd.Next(-20, 20), rnd.Next(-9, 9));

        // Edit shape
        transform.localScale = new Vector3(rnd.Next(1, 5), rnd.Next(1, 5));

        // Move self
        rb.AddForce(new Vector2(200, 200));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
