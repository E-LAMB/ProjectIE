 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the scripted appearence in the TEMP flesh level
public class MonsterMoves : MonoBehaviour
{

    public ColliderScript the_collider; // The collider that triggers this script
    public bool should_begin; // Has the script been triggered

    public float existence_time; // How long has the script been triggered for (how long has the monster existed?)

    // The different positions the monster should move to
    public Transform pos_spawn;
    public Transform rise_spawn;
    public Transform run_spawn;

    // The body as an object and transform
    public GameObject body_object;
    public Transform body_trans;

    public SubtitleSystem my_system; // The subtitle system

    void Start()
    {
        body_object.SetActive(false); // Hides body (what the player sees)
    }

    void Update()
    {
        if (the_collider.inside_object && !should_begin) // Begins if it hasn't before
        {
            should_begin = true;

            // Spawns body and moves it to spawning position (behind the terrain)
            body_object.SetActive(true);
            body_trans.position = pos_spawn.position;

            my_system.NamedSubtitle("Jean","I heard something, I should hide quickly!",5f); // Subtitle
        }

        if (should_begin)
        {
            existence_time += Time.deltaTime; // Increases timer
        }

        if (existence_time > 6f && 9f > existence_time) // Moves towards the rising position
        {
            body_trans.position = Vector3.MoveTowards(body_trans.position, rise_spawn.position, 15f * Time.deltaTime);
        }

        if (existence_time > 6f && 8f > existence_time)
        {
            my_system.NamedSubtitle("Facefull","Where are those faces? I need more... MORE!!",2f); // Subtitle
        }

        if (existence_time > 10f) // Moves quickly towards the offscreen position
        {
            body_trans.position = Vector3.MoveTowards(body_trans.position, run_spawn.position, 95f * Time.deltaTime);
        }

        if (existence_time > 14f) // Hides body when offscreen
        {
            body_object.SetActive(false);
        }

    }
}
