using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class asteroidSummon : MonoBehaviour
{
    public GameObject[] asteroids;
    /*float timer = 0;
    bool timerReached = false;*/

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        /*spawnAsteroid();
        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > 5)
        {
            spawnAsteroid();

            // Set to false so that We don't run this again
            timerReached = true;
        }*/
    }

    /*void spawnAsteroid()
    {
        StartCoroutine(Spawn());  
    }*/

    IEnumerator Spawn()
    {
        while (true)
        {
            // Summon clone of a random asteroid from the array
            Instantiate(asteroids[Random.Range(0, asteroids.Length)]);

            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
