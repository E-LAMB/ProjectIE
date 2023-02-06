using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to read lines of the poem, Although it can be used for other uses such as dialouge
public class InteractablePoem : MonoBehaviour
{

    // Referencing systems in the level
    public SubtitleSystem subtitle_system;

    // Controls what the subtitles will show
    public string text_to_use;
    public float time_to_use;

    public float interaction_range; // How close the player has to be
    public float player_distance; // How close the player actually is

    public bool interacted_with; // If the player has interacted with this before

    // Transforms of the poem and the player used for finding system
    public Transform self;
    public Transform player;

    public GameObject my_prompt; // The prompt

    void Update()
    {

        player_distance = Vector3.Distance(self.position, player.position); // Finds distance to player

        if (player_distance < interaction_range && !interacted_with && Input.GetKeyDown(KeyCode.E)) // If the player is close enough and they haven't interacted, Then show a subtitle
        {
            interacted_with = true;
            subtitle_system.NamedSubtitle("Jean", text_to_use, time_to_use);
        }

        if (player_distance < interaction_range && !interacted_with) // Shows prompt if player is close and they have not interacted
        {
            my_prompt.SetActive(true);
        }
        else
        {
            my_prompt.SetActive(false);
        }

    }
}
