using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the player movement in the Museum level
public class PlayerControllerMuseum : MonoBehaviour
{

    public Rigidbody2D playerObject; // Reference to Rigidbody
    public float speed; // The speed at which the player moves

    public float is_facing_left;
    
    public Animator my_anim;

    void Update()
    {
        // Uses an input and moves the player with account to their speed
        float movementValueX = Input.GetAxis("Horizontal");
        playerObject.velocity = new Vector2 (movementValueX*speed, playerObject.velocity.y);

        if (movementValueX != 0f) { my_anim.SetBool("IsMoving",true); } else { my_anim.SetBool("IsMoving", false); }
        if (movementValueX > 0) { my_anim.SetBool("IsFacingLeft", false); }
        if (movementValueX < 0) { my_anim.SetBool("IsFacingLeft", true); }
    }
}
