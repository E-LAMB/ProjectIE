using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBlank : MonoBehaviour
{

    // The speeds of the player
    public float normal_speed = 1;
    public float running_speed = 5;
    float playerspeed = 0; // (this is the only speed that changes during the runtime of script)

    public bool running; // Should the player be running?

    public float jumpforce = 1; // How high does the player jump

    public float movementValueX; // The movement of the player on the X axis

    // Ground related checking
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    bool isOnGround = false; 

    // Which layers are death, Which layers are a checkpoint?
    public LayerMask death;
    public LayerMask save;

    Rigidbody2D playerObject; // The rigidbody of the player

    public Vector3 safe_location; // The last location the player was safe (that was a checkpoint)

    public Transform self; // The player's transform

    public ParticleSystem respawn; // The particle system the player uses to respawn

    public Animator my_anim;
    public bool is_moving;

    public Vector3 ideal_scale;
    public float ideal_x_scale;

    public void SaveSpace()
    {
        safe_location = self.position; // Sets the respawn point
    }
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>(); // Assigns Rigidbody
        SaveSpace(); // Immediatly sets a spawnpoint to prevent weird spawn shenanigans
    }

    public void PlayerJump(float howmuch) // Initally made as a procedure to allow external jump sources such as steam vents
    {
        playerObject.AddForce(new Vector2(0.0f,jumpforce * howmuch)); // Jumps
        my_anim.SetTrigger("JustJumped");
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !running) // Controls running state (ie. sets bool to true while Left Shift is held down)
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && running)
        {
            running = false;
        }

        running = false; // Cancels run automatically - Run will not be used anymore

        if (running) // Controls running speed
        {
            playerspeed = running_speed;
        } else
        {
            playerspeed = normal_speed;
        }

        // Applies speed to player
        movementValueX = Input.GetAxis("Horizontal");
        playerObject.velocity = new Vector2 (movementValueX*playerspeed, playerObject.velocity.y);
        if (movementValueX == 0f) {is_moving = false;} else {is_moving = true;}
    
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            ideal_scale.x = ideal_x_scale * Input.GetAxisRaw("Horizontal");
        }

        self.localScale = ideal_scale;

        // Checks if the player is on the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true) // Allows the player to jump if the player is on the ground 
        {
            PlayerJump(100f);
        }

        if (Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, death)) // Respawns the player if they hit a death collider
        {
            self.position = safe_location;
            respawn.Play();
        }

        if (Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, save)) // Sets the player's spawn if they are in a save collider
        {
            SaveSpace();
        }

        my_anim.SetBool("IsMoving", is_moving);

    }
}
