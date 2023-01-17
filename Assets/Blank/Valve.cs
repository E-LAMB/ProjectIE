using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{

    public bool current_state;

    public Transform self;

    public Transform rotator;

    public LayerMask player_layer;

    public bool player_close;

    public Quaternion new_rotation;
    public Quaternion old_rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_close = Physics2D.OverlapCircle(self.position, 0.3f, player_layer);

        if (player_close && Input.GetKeyDown(KeyCode.E))
        {
            current_state = !current_state;
        }

        if (current_state)
        {
            rotator.rotation = new_rotation;
        } else
        {
            rotator.rotation = old_rotation;
        }
    }
}
