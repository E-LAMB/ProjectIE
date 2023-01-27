using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the valve and allows it to switch between two states
public class Valve : MonoBehaviour
{

    public bool current_state; // Current state of the switch

    public Transform self; // The valve's actual position

    public LayerMask player_layer; // The player's layer

    public bool player_close; // Is the player close?

    // Rotations for the valve's turning
    public Quaternion new_rotation; 
    public Quaternion old_rotation;
    public Transform rotator; // The rotation point's position

    void Update()
    {
        player_close = Physics2D.OverlapCircle(self.position, 0.3f, player_layer); // Checks if the player is close

        if (player_close && Input.GetKeyDown(KeyCode.E)) // Toggles the state of the switch
        {
            current_state = !current_state;
        }

        if (current_state) // Rotates the switch accordingly (currently instantly)
        {
            rotator.rotation = new_rotation;
        } else
        {
            rotator.rotation = old_rotation;
        }
    }
}
