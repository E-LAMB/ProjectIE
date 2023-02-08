using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneway : MonoBehaviour
{

    public Transform self;
    public Transform player;

    public bool should_appear;

    public BoxCollider2D my_component;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > self.position.y)
        {
            should_appear = true;
        } else
        {
            should_appear = false;
        }

        my_component.enabled = should_appear;
    }
}
