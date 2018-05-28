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

    [SerializeField] float rotationPitchFactor = 2;
    [SerializeField] float throwPitchFactor = 10;

    [SerializeField] float rotationYawFactor = -2;
    [SerializeField] float throwYawFactor = 10;

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

    private void RotateShip()
    {
        float xThrow = xRawThrow * throwPitchFactor;
        float yThrow = yRawThrow * throwYawFactor;

        float rawPitch = -transform.localPosition.y * rotationPitchFactor;
        float rawYaw = transform.localPosition.x * rotationYawFactor;

        float pitch = rawPitch + yThrow;
        float yaw = rawYaw + xThrow;
        float roll = 0f;



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
