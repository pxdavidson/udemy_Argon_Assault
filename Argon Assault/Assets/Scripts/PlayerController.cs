using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Variables
    [Header("General")]
    [Tooltip("ms^-1")][SerializeField] float controlSpeed = 10f;
    [SerializeField] float screenSizeX = 9;
    [SerializeField] float screenSizeY = 5;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject[] guns;

    [Header("Player Position")]
    [SerializeField] float positionalRotationFactorPitch = -2f;
    [SerializeField] float positionalRotationFactorYaw = 2f;

    [Header("Player Rotation")]
    [SerializeField] float throwRotationFactor = -15f;

    [Header("VFX")]
    [SerializeField] GameObject deathFX;

    // These are set from MoveshipX() and MoveshipY()
    float xRawThrow;
    float yRawThrow;

    // States
    bool Dead = false;

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update ()
    {
        if (Dead == false)
            {
            MoveShipX();
            MoveShipY();
            RotateShip();
            FireWeapons();
            }
    }

    // Rotates the ship based on screen position and input (via Throw)
    private void RotateShip()
    {
        float pitchThrow = yRawThrow * throwRotationFactor;
        float pitchRotation = transform.localPosition.y * positionalRotationFactorPitch;

        float rollThrow = xRawThrow * throwRotationFactor;
        float yawRotation = transform.localPosition.x * positionalRotationFactorYaw;

        float pitch = pitchRotation + pitchThrow;
        float yaw = yawRotation;
        float roll = rollThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    // Move ship on X axis
    private void MoveShipX()
    {
        xRawThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xRawThrow * controlSpeed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(xRawPos, -screenSizeX, screenSizeX);

        transform.localPosition = new Vector3(xClampedPos, transform.localPosition.y, transform.localPosition.z);
    }

    // Move ship on Y axis
    private void MoveShipY()
    {
        yRawThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yRawThrow * controlSpeed * Time.deltaTime;
        float yRawPos = transform.localPosition.y + yOffset;
        float yClampedPos = Mathf.Clamp(yRawPos, -screenSizeY, screenSizeY);

        transform.localPosition = new Vector3(transform.localPosition.x, yClampedPos, transform.localPosition.z);
    }
    
    // Player is dead
    public void PlayerDead()
    {
        Dead = true;
        deathFX.SetActive(true);
        Invoke("LoadStartOfLevel", levelLoadDelay);
    }

    // Load Level. NOTE: Held in string in PlayedDead()
    void LoadStartOfLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Turn particle effects on and off
    private void FireWeapons()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    // Make the particle effects for weapons set to active
    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    // Make the particle effects for weapons set to inactive
    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}
