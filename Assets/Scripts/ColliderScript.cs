using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script activates if the respective layer enters the trigger which can be accessed by other scripts
public class ColliderScript : MonoBehaviour
{

    public int layer_banned; // The layer to look out for

    public bool inside_object; // Is the layer currently inside?

    public int type; // What type of feedback with the script provide if any?

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == layer_banned)
        {
            inside_object = true; // Activates when the layer enters
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == layer_banned)
        {
            inside_object = false; // Deactivates when the player leaves
        }
    }

    void Update()
    {
        // Updates the "Mind" with a response
        if (type == 1) {Mind.player_is_inside_object = inside_object;}
        if (type == 2) {Mind.player_behind_object = inside_object;}
    }
}
