using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingStatusBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // For stabilizing
    private Camera camera;                                  // Removed SerializeField
    [SerializeField] private Transform target;

    void Start()
    {
        camera = Camera.main;                               // Assign the main camera at the start of the game
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = camera.transform.rotation;     // Fixes rotation to that of the camera
        transform.position = target.position;               // Makes it so that the bar stays below the asteroid
    }
}
