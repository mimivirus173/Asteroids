using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Force player will move with
    public float force = 5;

    // Directions
    private float y; // Vertical
    private float x; // Horizontal

    // Declare RigidBody
    private Rigidbody2D rb;

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
