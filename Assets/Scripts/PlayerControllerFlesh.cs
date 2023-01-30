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
    bool isOnGround = false; // Are they on the ground

    // Checks if the player is grounded
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    public GameObject backwallChecker;
    public LayerMask whatIsBackwall;

    public bool is_in_cover;

    Rigidbody2D playerObject; 

    public bool crouching;

    public GameObject crouching_collider;
    public GameObject standing_collider;

    public float last_direction = 0f;
    public Vector3 scale;

    public Transform manager;

    public ColliderScript standing_checker;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
    }

    public void PlayerJump(float howmuch)
    {
        playerObject.AddForce(new Vector2(0.0f,jumpforce * howmuch));
    }

    // Update is called once per frame 
    void Update()
    {

        if (Mind.player_behind_object && crouching)
        {
            Mind.player_is_hidden = true;
        } else
        {
            Mind.player_is_hidden = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouching && Mind.player_is_inside_object)
            {
                // do nothing
            } else
            {
                crouching = !crouching;
            }
        }

        if (crouching)
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
        if (movementValueX == 1 || movementValueX == -1)
        {
            last_direction = movementValueX;
            scale.x = -1 * last_direction;
            manager.localScale = scale;
        }

        playerObject.velocity = new Vector2 (movementValueX*playerspeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, whatIsGround);
        is_in_cover = Physics2D.OverlapCircle(backwallChecker.transform.position, 0.1f, whatIsBackwall);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !crouching)
        {
            PlayerJump(100f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && crouching && !Mind.player_is_inside_object)
        {
            crouching = false;
            PlayerJump(100f);
        }

    }
}
