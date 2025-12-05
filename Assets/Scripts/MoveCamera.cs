using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move camera to follow a target position
// Reference: https://www.youtube.com/watch?v=f473C43s8nE

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
