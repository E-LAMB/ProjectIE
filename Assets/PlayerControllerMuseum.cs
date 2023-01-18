using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMuseum : MonoBehaviour
{

    public Rigidbody2D playerObject;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementValueX = Input.GetAxis("Horizontal");
        playerObject.velocity = new Vector2 (movementValueX*speed, playerObject.velocity.y);
    }
}
