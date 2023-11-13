using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Force player will move with
    public float force;

    // Directions
    private float y; // Vertical
    private float x; // Horizontal

    // Declare RigidBody
    private Rigidbody2D rb;

    // Destroy upon contact with asteroids
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Asteroid"))
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load in RigidBody2D into rb
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Initialize axes
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Movement
        rb.AddForce(new Vector2(x * force, y * force));
    }
}
