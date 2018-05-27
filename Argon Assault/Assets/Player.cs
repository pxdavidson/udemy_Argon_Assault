using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    // Variables
    [Tooltip("ms^-1")][SerializeField] float Speed = 10f;
    [SerializeField] float ScreenSizeX = 9;
    [SerializeField] float ScreenSizeY = 5;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveShipX();
        MoveShipY();
    }

    // Move ship on X axis
    private void MoveShipX()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(xRawPos, -ScreenSizeX, ScreenSizeX);

        transform.localPosition = new Vector3(xClampedPos, transform.localPosition.y, transform.localPosition.z);
    }

    // Move ship on Y axis
    private void MoveShipY()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float yRawPos = transform.localPosition.y + yOffset;
        float yClampedPos = Mathf.Clamp(yRawPos, -ScreenSizeY, ScreenSizeY);

        transform.localPosition = new Vector3(transform.localPosition.x, yClampedPos, transform.localPosition.z);
    }
}
