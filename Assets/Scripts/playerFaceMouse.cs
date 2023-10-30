using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFaceMouse : MonoBehaviour
{
    void faceMouse()
    {
        // Get mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Define direction vector
        Vector2 direction = new Vector2
            (
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
            );
        
        // Point player towards direction
        transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
    }
}
