using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBlank : MonoBehaviour
{

    public float normal_speed = 1;
    public float running_speed = 5;

    public float jumpforce = 1;
    bool isOnGround = false;

    public float movementValueX;

    float playerspeed = 0;

    public GameObject groundChecker;
    public LayerMask whatIsGround;

    Rigidbody2D playerObject; 

    public bool running;

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && !running)
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && running)
        {
            running = false;
        }

        if (running)
        {
            playerspeed = running_speed;
        } else
        {
            playerspeed = normal_speed;
        }

        float movementValueX = Input.GetAxis("Horizontal");
        playerObject.velocity = new Vector2 (movementValueX*playerspeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {

            PlayerJump(100f);

        }

    }
}
