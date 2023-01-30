using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the camera's movement in the Blank Level
public class CameraControllerBlank : MonoBehaviour
{

    public Vector3 offset; // The offset to add
    public Transform self; // The camera's transform
    public Transform focus; // The player's transform

    void Update()
    {
        Vector3 ideal_location; // Makes a Vector3
        ideal_location = focus.position + offset; // Sets the Vector3 to the player's location with an offset
        ideal_location.y = 0.04182267f; // Locks the Y position at a specific value
        self.position = ideal_location; // Moves camera to location
    }
}
