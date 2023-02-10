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

    public PlayerControllerFlesh the_player;

    public bool should_flip = true;

    void PlayerDied() // Script should trigger death, Currently non-functional
    {
        Debug.Log("YOU DIED");
        the_player.Died();
    }
    void Start()
    {
        ideal_scale = self.localScale; // Sets scale of monster
        the_player = GameObject.Find("FleshyPlayerCollective").GetComponent<PlayerControllerFlesh>();
    }

    void Update()
    {

        self.localScale = ideal_scale; // Sets scale of monster

        looking_timer += Time.deltaTime; // Counts up to switch directions

        if (looking_timer > time_switch_threshold) 
        {
            looking_timer = 0f; // Resets timer
            facing_right = !facing_right; // Switches the side it is checking
            if (should_flip) {ideal_scale.x = ideal_scale.x * -1;} // Switches orientation
        }

        // Sets booleans
        player_on_left = left_checker.inside_object; 
        player_on_right = right_checker.inside_object;
        player_hidden = Mind.player_is_hidden;

        // Should the player die? They can only die if they are on the side the monster is looking and are not hidden.
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
