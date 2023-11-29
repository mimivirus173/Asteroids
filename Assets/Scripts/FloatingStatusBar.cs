using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingStatusBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // For stabilizing
    private new Camera camera;                              // Removed SerializeField
    [SerializeField] private Transform target;
    // [SerializeField] private Vector3 offset;
    private Vector3 offset;

    void Start()
    {
        camera = Camera.main;                               // Assign the main camera at the start of the game
        offset = new Vector3(0, -0.5f, 0);                  // Assign offset of the healthbar
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.rotation = camera.transform.rotation;     // Fixes rotation to that of the camera
        transform.position = target.position + offset;             // Makes it so that the bar stays below the asteroid
    }
}
