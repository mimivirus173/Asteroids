using UnityEngine;
using Random = UnityEngine.Random;

public class asteroidScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;

    public static int score = 0;
    
    // Variables for asteroid
    private int hp;
    private int area;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Edit shape and declare area variable
        int sizeX = Random.Range(1, 5);
        int sizeY = Random.Range(1, 5);
        transform.localScale = new Vector3(sizeX, sizeY);
        area = sizeX * sizeY;

        // Constants
        hp = area * 5;
        speed = 750 / Mathf.Sqrt(area);
        rb.mass = area;

        // Movement and rotation
        player = GameObject.FindGameObjectWithTag("Player");                // Declare for player
        transform.LookAt(player.transform.position, transform.forward);     // Face towards player
        rb.AddForce(this.transform.forward * speed);                        // Add force to "push" self towards player
        transform.rotation = Quaternion.Euler(0, 0, 0);                     // Reset y-axis so the asteroid faces the correct way
        
        // Rotation
        rb.AddTorque
            (
                Random.Range(-50, 50) * (3 + (area / 10))
            );

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
            // Reduce HP
            hp -= Random.Range(5, 10);

            // Delete object when HP = 0
            if (hp <= 0)
            {
                score += (area * 100);
                Debug.Log("Score: " + score);
                Destroy(this.gameObject);
            }
        }

        // Delete upon contact with outer walls
        if (collision.gameObject.name.StartsWith("OuterWall"))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
