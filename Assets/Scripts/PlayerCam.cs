using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player camera controller
// Reference: https://www.youtube.com/watch?v=f473C43s8nE

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // rotate cam and orientation
        yRotation += mouseX;
        xRotation -= mouseY;

        // clamp x rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // apply rotations
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
