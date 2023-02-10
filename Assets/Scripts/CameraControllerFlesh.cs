using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the camera's movement in the Forest Level
public class CameraControllerFlesh : MonoBehaviour
{

    public Vector3 offset; // Offset from player
    public Transform self;
    public Transform focus; // Object to focus on (ie. the player)

    public Vector3 final;
    public bool should_lock;

    public Transform right_boundary;
    public Transform left_boundary;
    public float right_float;
    public float left_float;

    void Update()
    {
        right_float = right_boundary.position.x;
        left_float = left_boundary.position.x;
        final = focus.position + offset; // Moves the camera to that location (ie. an offset from the player)
        if (should_lock) {final.y = 0f;}
        if (final.x > right_float)
        {
            final.x = right_float;
        }
        if (final.x < left_float)
        {
            final.x = left_float;
        }
        self.position = final;
    }
}
