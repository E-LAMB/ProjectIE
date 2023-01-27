using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the camera's movement in the Forest Level
public class CameraControllerForest : MonoBehaviour
{

    public Vector3 offset; // Offset from player
    public Transform self;
    public Transform focus; // Object to focus on (ie. the player)

    void Update()
    {
        Vector3 ideal_location; // Makes a Vector3
        ideal_location = focus.position + offset; // Finds the position with offset
        ideal_location.y = 3.5f; // Locks the Y axis at a specific height (3.5)
        self.position = ideal_location; // Moves the camera to that location
    }
}
