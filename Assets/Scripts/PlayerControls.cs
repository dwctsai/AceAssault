using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")] 
    [SerializeField] float controlSpeed = 30f;
    [Tooltip("How fast player moves horizontally")] 
    [SerializeField] float xRange = 15f;
    [Tooltip("How fast player moves vertically")] 
    [SerializeField] float yRange = 10f;

    [Header("Laser Gun Array")]
    [Tooltip("Add all player lasers")] 
    [SerializeField] GameObject[] lasers;

    [Header("Screen Position Based Tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;     // multiply by Time.deltaTime to make frame rate independent
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);  // restrict horizontal movement between a min and max range

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        // https://en.wikipedia.org/wiki/Quaternion
        // https://en.wikipedia.org/wiki/Leonhard_Euler
        //
        // Pitch, yaw, and roll can affect each other.
        //
        //          Position On Screen      Control Throw   
        // Pitch    Coupled                 Coupled
        // Yaw      Coupled                 -
        // Roll     -                       Coupled

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            //laser.SetActive(isActive);
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
            
        }
    }

}
