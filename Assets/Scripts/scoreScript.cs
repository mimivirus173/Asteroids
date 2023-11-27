using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{
    // Score variables
    private int score;

    // TMP variable
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = asteroidScript.score;
        scoreText.text = "Score: " + score.ToString();
    }
}
