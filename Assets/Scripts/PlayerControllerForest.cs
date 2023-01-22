using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForest : MonoBehaviour
{

    public Rigidbody2D playerObject;

    public float speed;
    public float jumpforce;

    public GameObject groundChecker;
    public LayerMask ground;
    public bool on_ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        on_ground = Physics2D.OverlapCircle(groundChecker.transform.position, 0.2f, ground);

        playerObject.velocity = new Vector2 (speed, playerObject.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && on_ground) {playerObject.AddForce(new Vector2(0.0f,jumpforce * 10f));}

    }
}
