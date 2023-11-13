using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class asteroidScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject asteroid;
    private GameObject player;
    private int hp;

    // Collisions
    public void OnCollisionEnter2D(Collision2D collision)
    {
        /* // Ignore inner walls
        if (collision.gameObject.tag == "InnerWall")
        {
            var innerWallCollider = collision.gameObject.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(innerWallCollider, GetComponent<PolygonCollider2D>());
        } */

        // Bullet
        if (collision.gameObject.name.StartsWith("Bullet"))
        {
            // Reduce HP
            hp -= 2;

            // Delete object when HP = 0
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        // Delete upon contact with outer walls
        if (collision.gameObject.name.StartsWith("OuterWall"))
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize rigidbody
        rb = GetComponent<Rigidbody2D>();
        
        // Start in a random position
        transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-9, 9));

        // Edit shape
        int sizeX = Random.Range(1, 5);
        int sizeY = Random.Range(1, 5);
        transform.localScale = new Vector3(sizeX, sizeY);

        // HP and mass set to size
        hp = sizeX * sizeY;
        rb.mass = sizeX * sizeY;

        // Movement and rotation
        player = GameObject.FindGameObjectWithTag("Player");                // Declare for player
        transform.LookAt(player.transform.position, transform.forward);     // Face towards player
        rb.AddForce(this.transform.forward * (5000 / (sizeX * sizeY)));      // Add force to "push" self towards player
        transform.rotation = Quaternion.Euler(0, 0, 0);                     // Reset y-axis so the asteroid faces the correct way

        /*rb.AddForce(new Vector2
            (
                Random.Range(-200 * (2 + (sizeX / 10)), 200 * (2 + (sizeX / 10))),
                Random.Range(-200 * (2 + (sizeY / 10)), 200 * (2 + (sizeY / 10)))
            ));*/
        
        // Rotation
        rb.AddTorque
            (
                Random.Range(-30, 30) * (3 + ((sizeX * sizeY) / 10))
            );

        // Find inner walls via tag
        GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
        foreach (GameObject InnerWall in innerWalls)
        {
            // Ignore collision between asteroid and inner wall
            Physics2D.IgnoreCollision(InnerWall.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
