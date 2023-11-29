using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class asteroidScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public static int score = 0;

    // Healthbar
    [SerializeField] FloatingStatusBar healthBar;

    // Variables for asteroid
    [SerializeField] float hp, maxHP;
    private int area;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<FloatingStatusBar>();

        // Initialize asteroid
        AsteroidInit(Random.Range(1, 5), Random.Range(1, 5));

        // Find inner walls via tag
        GameObject[] innerWalls = GameObject.FindGameObjectsWithTag("InnerWall");
        foreach (GameObject InnerWall in innerWalls)
        {
            // Ignore collision between asteroid and inner wall
            Physics2D.IgnoreCollision(InnerWall.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
        }
    }

    // Collisions
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Bullet
        if (collision.gameObject.name.StartsWith("Bullet"))
        {
            TakeDamage(Random.Range(5, 10));
        }

        // Delete upon contact with outer walls
        if (collision.gameObject.name.StartsWith("OuterWall"))
        {
            Destroy(this.gameObject);
        }
    }

    // Set up asteroid
    public void AsteroidInit(int sizeX, int sizeY)
    {
        // Edit shape and declare area variable
        transform.localScale = new Vector3(sizeX, sizeY);
        area = sizeX * sizeY;

        // Constants
        maxHP = area * 5;
        rb.mass = area;

        // Health management
        hp = maxHP;
        healthBar.UpdateHealthBar(hp, maxHP);

        // Movement of asteroid
        AsteroidMovement
        (
            750 / Mathf.Sqrt(area), 
            Random.Range(-50, 50) * (3 + (area / 10))
        );
    }

    // Asteroid initial movement
    public void AsteroidMovement(float speed, float rotation)
    {
        player = GameObject.FindGameObjectWithTag("Player");                // Declare for player
        transform.LookAt(player.transform.position, transform.forward);     // Face towards player
        rb.AddForce(this.transform.forward * speed);                        // Add force to "push" self towards player
        transform.rotation = Quaternion.Euler(0, 0, 0);                     // Reset y-axis so the asteroid faces the correct way
        rb.AddTorque(rotation);                                             // Rotate asteroid
    }

    // Damage script
    public void TakeDamage(int damageAmount)
    {
        // Reduce HP and update healthbar
        hp -= damageAmount;
        healthBar.UpdateHealthBar(hp, maxHP);

        // Delete object when HP = 0
        if (hp <= 0)
        {
            score += (area * 100);
            Debug.Log("Score: " + score);
            Destroy(this.gameObject);
        }
    }

    /*// Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        if (hp < maxHP)
        {
            healthBarUI.SetActive(true);
        }
        else
        {
            healthBarUI.SetActive(false);
        }
    }

    float CalculateHealth()
    {
        return hp / maxHP;
    }*/
}
