using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    // Destroy upon contact with wall
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WallUp")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "WallDown")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "WallLeft")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "WallRight")
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
