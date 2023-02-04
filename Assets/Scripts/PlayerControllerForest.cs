using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the player's movement in the Forest Level
public class PlayerControllerForest : MonoBehaviour
{

    public Rigidbody2D playerObject; // Reference to Rigidbody

    // Speed and Jump height
    public float speed; 
    float using_speed;
    public float jumpforce;

    // Ground checking related variables
    public GameObject groundChecker;
    public LayerMask ground;
    public bool on_ground;

    void Update()
    {

        on_ground = Physics2D.OverlapCircle(groundChecker.transform.position, 0.2f, ground); // Checks if the player is on the ground
        // using_speed = speed + (Input.GetAxis("Horizontal") * 3);
        using_speed = speed;
        playerObject.velocity = new Vector2 (using_speed, playerObject.velocity.y); // Moves the player in a single direction
        if (Input.GetKeyDown(KeyCode.Space) && on_ground) 
        {playerObject.AddForce(new Vector2(0.0f,jumpforce * 10f));} // Causes the player to jump if they meet the requirements
    }
}
