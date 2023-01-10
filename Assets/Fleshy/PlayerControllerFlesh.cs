using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFlesh : MonoBehaviour
{

    public float normal_speed = 8;
    public float crouching_speed = 2;

    public float jumpforce = 1;
    bool isOnGround = false;

    public float movementValueX;

    float playerspeed = 0;

    public GameObject groundChecker;
    public LayerMask whatIsGround;

    public GameObject backwallChecker;
    public LayerMask whatIsBackwall;

    public bool is_in_cover;

    Rigidbody2D playerObject; 

    public bool crouching;

    public GameObject crouching_collider;
    public GameObject standing_collider;

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

        if (Input.GetKeyDown(KeyCode.LeftControl) && !crouching)
        {
            crouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && crouching)
        {
            crouching = false;
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

        float movementValueX = Input.GetAxis("Horizontal");
        playerObject.velocity = new Vector2 (movementValueX*playerspeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.3f, whatIsGround);
        is_in_cover = Physics2D.OverlapCircle(backwallChecker.transform.position, 0.1f, whatIsBackwall);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            PlayerJump(100f);
        }

    }
}
