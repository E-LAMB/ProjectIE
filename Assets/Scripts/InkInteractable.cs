using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This script ends the Blank Level with three ink fountains
public class InkInteractable : MonoBehaviour
{

    // Level systems
    public SubtitleSystem subtitle_system;
    public LevelSwitcher level_switcher;

    // Variables that control the subtitle
    public string text_to_use;
    public float time_to_use;

    public int scene_to_warp; // The scene the player is sent to once the ink ends

    public float interaction_range; // How far the player can use the object from
    public float player_distance; // The distacne the player is

    public bool interacted_with; // Has the player used this before?

    public Transform self; // The interaction point
    public Transform player; // The player's transform

    public float warp_time = -20f; // Timer for teleporting

    public GameObject my_prompt; // The prompt to interact with the point

    public bool should_warp; // Should the prompt teleport?

    // Particle systems
    public ParticleSystem sys_1;
    public ParticleSystem sys_2;
    public ParticleSystem sys_3;

    public string content;

    void Start()
    {
        string path = Mind.save_path; // Sets the Save File's Path to the one saved in MIND
        StreamWriter writer = new StreamWriter(path, false); // Writes the progress to the file when the scene is loaded
        writer.Write(content);
        writer.Close();
        Debug.Log("Saved progress");
    }

    void Update()
    {

        player_distance = Vector3.Distance(self.position, player.position); // Calculates the distance to the player

        if (player_distance < interaction_range && !interacted_with && Input.GetKeyDown(KeyCode.E)) // If the player is close and hasn't interacted then it does the script
        {
            interacted_with = true;
            subtitle_system.NamedSubtitle("Jean", text_to_use, time_to_use); // Makes a subtitle
            warp_time = 0f; // Begins teleporting timer

            // Triggers all the particle systems
            sys_1.Play();
            sys_2.Play();
            sys_3.Play();
        }

        if (player_distance < interaction_range && !interacted_with) // Shows or hide prompt 
        {
            my_prompt.SetActive(true);
        }
        else
        {
            my_prompt.SetActive(false);
        }

        if (warp_time > -2f) // Counts up teleport
        {
            warp_time += Time.deltaTime;
        }

        if (warp_time > time_to_use && should_warp) // Teleports to the next scene
        {
            level_switcher.SceneSwitch(scene_to_warp);
        }

    }
}
