using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class asteroidSummon : MonoBehaviour
{
    public GameObject[] asteroids;
    private int spawnSide;

    // Start is called before the first frame update
    void Start()
    {
        // Start coroutine for summoning
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to spawn asteroids
    IEnumerator Spawn()
    {
        while (true)
        {
            spawnSide = Random.Range(1, 4);
            
            // Top side
            if (spawnSide == 1)
            {
                Vector2 randomPos = new Vector2(Random.Range(-20, 20), Random.Range(7, 10));
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], randomPos, Quaternion.identity);
            } 
            
            // Right side
            else if (spawnSide == 2)
            {
                Vector2 randomPos = new Vector2(Random.Range(12, 20), Random.Range(-10, 10));
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], randomPos, Quaternion.identity);
            } 
            
            // Bottom side
            else if (spawnSide == 3)
            {
                Vector2 randomPos = new Vector2(Random.Range(-20, 20), Random.Range(-10, -7));
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], randomPos, Quaternion.identity);
            } 
            
            // Left side
            else if (spawnSide == 4)
            {
                Vector2 randomPos = new Vector2(Random.Range(-20, -12), Random.Range(-10, 10));
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], randomPos, Quaternion.identity);
            }

            // Delay until next spawn (1-5s)
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
