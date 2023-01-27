using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the monster looking left and right for the player, Triggering a death if the player is caught out of cover
public class MonsterLooking : MonoBehaviour
{

    // Is the player on either side?
    public bool player_on_right; 
    public bool player_on_left;

    // Accesses the triggers for checking player position
    public ColliderScript left_checker;
    public ColliderScript right_checker;

    public bool facing_right; // Is the monster facing right? If not then they are facing left.

    public bool player_hidden; // Is the player hiding?

    // Timers that control the monster looking around
    public float looking_timer; 
    public float time_switch_threshold;

    // Scales control the body looking left and right
    public Transform self;
    public Vector3 ideal_scale;

    void PlayerDied() // Script should trigger death, Currently non-functional
    {
        Debug.Log("YOU DIED");
    }
    void Start()
    {
        ideal_scale = self.localScale; // Sets scale of monster
    }

    void Update()
    {

        self.localScale = ideal_scale;
    
        looking_timer += Time.deltaTime;

        if (looking_timer > time_switch_threshold) // Switches orientation
        {
            looking_timer = 0f;
            facing_right = !facing_right;
            ideal_scale.x = ideal_scale.x * -1;
        }

        // Sets booleans
        player_on_left = left_checker.inside_object; 
        player_on_right = right_checker.inside_object;
        player_hidden = Mind.player_is_hidden;

        // Should the player die?
        if (facing_right && player_on_right && !player_hidden)
        {
            PlayerDied();
        }

        if (!facing_right && player_on_left && !player_hidden)
        {
            PlayerDied();
        }

    }
}
