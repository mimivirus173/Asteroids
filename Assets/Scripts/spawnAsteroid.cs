using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class asteroidSummon : MonoBehaviour
{
    public GameObject[] asteroids;

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
            // Summon clone of a random asteroid from the array
            Instantiate(asteroids[Random.Range(0, asteroids.Length)]);

            // Delay until next spawn (1-5s)
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
