using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls interactive prompts where the player is usually teleported to another scene, But is sometimes utilised in the levels themselves
public class Interactable_Pedistal : MonoBehaviour
{

    // Accesses two systems found in each level, Subtitles and Level switchers
    public SubtitleSystem subtitle_system;
    public LevelSwitcher level_switcher;

    // Controls what to show and for how long before teleporting
    public string text_to_use;
    public float time_to_use;

    public int scene_to_warp; // Which scene to switch to?

    public float player_distance; // Distance to player

    public bool interacted_with; // Has the player used this before

    // Transforms of the interactable and the player
    public Transform self;
    public Transform player;

    // By default set to -20. When activated it is set to 0 and then increases from there.
    public float warp_time = -20f;

    public GameObject my_prompt; // The prompt to show

    public float interaction_range; // How far away the player can actually use this prompt

    public bool should_warp; // Should this script actually change scenes?

    public bool should_freeze;

    void Update()
    {

        player_distance = Vector3.Distance(self.position, player.position); // Finds distance to player

        if (player_distance < interaction_range && !interacted_with && Input.GetKeyDown(KeyCode.E))
        {
            interacted_with = true;
            subtitle_system.NamedSubtitle("Jean", text_to_use, time_to_use); // Makes a Subtitle
            warp_time = 0f;
            if (should_freeze) {Mind.moving_museum = false;}
        }

        if (player_distance < interaction_range && !interacted_with) // Controls if prompt should appear
        {
            my_prompt.SetActive(true);
        } else
        {
            my_prompt.SetActive(false);
        }

        if (warp_time > -2f) // Increases warp time (a timer for when to warp)
        {
            warp_time += Time.deltaTime;
        }

        if (warp_time > time_to_use && should_warp) // Controls the time to switch scenes
        {
            level_switcher.SceneSwitch(scene_to_warp);
        }

    }
}
