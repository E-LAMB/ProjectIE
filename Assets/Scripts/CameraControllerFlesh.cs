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

    void Update()
    {
        final = focus.position + offset; // Moves the camera to that location (ie. an offset from the player)
        if (should_lock) {final.y = 0f;}
        self.position = final;
    }
}
