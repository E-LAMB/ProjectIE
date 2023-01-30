using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the player movement in the Museum level
public class PlayerControllerMuseum : MonoBehaviour
{

    public Rigidbody2D playerObject; // Reference to Rigidbody
    public float speed; // The speed at which the player moves

    void Update()
    {
        // Uses an input and moves the player with account to their speed
        float movementValueX = Input.GetAxis("Horizontal");
        playerObject.velocity = new Vector2 (movementValueX*speed, playerObject.velocity.y);
    }
}
