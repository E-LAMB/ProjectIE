using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This controls the camera's movement in the museum
public class CameraControllerMuseum : MonoBehaviour
{

    public Transform self; // The camera's own position

    // These control how far left or right the camera can move before stopping
    public Transform right_boundary;
    public Transform left_boundary;
    public float right_float;
    public float left_float;

    public Transform focus_on; // The object to focus on

    public Vector3 target_location; // Where the camera should be looking at
    public float speed; // How fast the camera should move

    public float y_lock; // The height the camera is locked at

    void Update()
    {

        // Sets the boundaries as floats
        right_float = right_boundary.position.x;
        left_float = left_boundary.position.x;

        target_location = focus_on.position; // Sets the target to the player's position

        // Stops the camera if it goes too far
        if (target_location.x > right_float)
        {
            target_location.x = right_float;
        }
        if (target_location.x < left_float)
        {
            target_location.x = left_float;
        }

        target_location.y = y_lock; // Locks the Y position

        self.position = target_location; // Moves camera to final position
        
    }
}
