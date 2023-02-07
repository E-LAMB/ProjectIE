using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is the Player Controller for the Fleshy level
public class PlayerControllerFlesh : MonoBehaviour
{

    // Speeds for the player
    public float normal_speed = 8;
    public float crouching_speed = 2;
    float playerspeed = 0; // (this is the only speed that changes during the runtime of script)
    public float movementValueX; // The calculated movement

    public float jumpforce = 1; // How high should the player jump?

    // Checks if the player is grounded
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    bool isOnGround = false; // Are they on the ground

    // Checks if the player is in cover
    public GameObject backwallChecker;
    public LayerMask whatIsBackwall;
    public bool is_in_cover; // Are they in cover / behind an object

    Rigidbody2D playerObject; // Reference to the player's Rigidbody

    public bool crouching; // Are they crouching?

    // Hitboxes that allow the player to switch between a crouching and standing height
    public GameObject crouching_collider; 
    public GameObject standing_collider; 

    // These control the sprite's direction
    public float last_direction = 0f;
    public float x_scale = 1f;
    public Vector3 scale;

    public Transform manager; // The gameobject that houses all the objects such as the colliders

    public ColliderScript standing_checker; // A collider that checks if the player has something above them that would stop them from standing

    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>(); // Gets component
    }

    public void PlayerJump(float howmuch) // A procedure that was copied over from the Blank Movement Script
    {
        playerObject.AddForce(new Vector2(0.0f,jumpforce * howmuch));
    }

    void Update()
    {

        // Refer to the "Mind" script for details behind "Mind." variables

        if (Mind.player_behind_object && crouching) // If the player is crouching and hidden
        {
            Mind.player_is_hidden = true;
        } else
        {
            Mind.player_is_hidden = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) // Lets you crouch / uncrouch. 
        {
            if (crouching && Mind.player_is_inside_object) // If you are inside an object, Nothing happens
            {
                // do nothing
            } else
            {
                crouching = !crouching;
            }
        }

        if (crouching) // Sets the speed and activates the correct hitbox to use
        {
            playerspeed = crouching_speed;
            standing_collider.SetActive(false);
            crouching_collider.SetActive(true);
        } else
        {
            playerspeed = normal_speed;
            standing_collider.SetActive(true);
            crouching_collider.SetActive(false);
        }

        float movementValueX = Input.GetAxisRaw("Horizontal");

        // Stores the last facing direction and faces the player in the right direction
        if (movementValueX == 1 || movementValueX == -1)
        {
            last_direction = movementValueX;
            scale.x = -x_scale * last_direction;
            manager.localScale = scale;
        }

        playerObject.velocity = new Vector2 (movementValueX*playerspeed, playerObject.velocity.y); // Applies speeds

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, whatIsGround); // Are they on the ground?
        is_in_cover = Physics2D.OverlapCircle(backwallChecker.transform.position, 0.1f, whatIsBackwall); // Is there a back wall behind the player?

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !crouching) // Does a normal jump if the player is not crouching
        {
            PlayerJump(100f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && crouching && !Mind.player_is_inside_object) // Uncrouches the player if they jump
        {
            crouching = false;
            PlayerJump(100f);
        }

    }
}
