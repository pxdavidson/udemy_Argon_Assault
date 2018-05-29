using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    // Variables
    [Tooltip("ms^-1")][SerializeField] float speed = 10f;
    [SerializeField] float screenSizeX = 9;
    [SerializeField] float screenSizeY = 5;

    [SerializeField] float positionalRotationFactorPitch = -2f;
    [SerializeField] float positionalRotationFactorYaw = 2f;

    [SerializeField] float throwRotationFactor = -15f;

    float xRawThrow;
    float yRawThrow;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveShipX();
        MoveShipY();
        RotateShip();
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
        float xOffset = xRawThrow * speed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(xRawPos, -screenSizeX, screenSizeX);

        transform.localPosition = new Vector3(xClampedPos, transform.localPosition.y, transform.localPosition.z);
    }

    // Move ship on Y axis
    private void MoveShipY()
    {
        yRawThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yRawThrow * speed * Time.deltaTime;
        float yRawPos = transform.localPosition.y + yOffset;
        float yClampedPos = Mathf.Clamp(yRawPos, -screenSizeY, screenSizeY);

        transform.localPosition = new Vector3(transform.localPosition.x, yClampedPos, transform.localPosition.z);
    }
}
