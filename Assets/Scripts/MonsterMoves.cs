 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the scripted appearence in the TEMP flesh level
public class MonsterMoves : MonoBehaviour
{

    public ColliderScript the_collider; // The collider that triggers this script
    public ColliderScript the_box_collider; // The collider that detects if they're in the box
    public BoxCollider2D blocker; // Detects if they're inside of the box
    public BoxCollider2D other_blocker; // Detects if they're inside of the box
    public bool should_begin; // Has the script been triggered
    public bool has_hidden;

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
        other_blocker.enabled = false;
    }

    void Update()
    {
        if (the_collider.inside_object && !has_hidden) // Begins if it hasn't before
        {
            should_begin = true;

            other_blocker.enabled = false;
            blocker.enabled = true;

            // Spawns body and moves it to spawning position (behind the terrain)
            body_object.SetActive(true);
            body_trans.position = pos_spawn.position;

            my_system.NamedSubtitle("Jean", "I heard something, I should hide quickly!", 5f); // Subtitle
        }

        if (the_box_collider.inside_object && !has_hidden) // Begins if it hasn't before
        {
            has_hidden = true;

            other_blocker.enabled = true;
            blocker.enabled = true;
        }

        if (should_begin)
        {
            existence_time += Time.deltaTime; // Increases timer
            if (existence_time > 5.5f && !has_hidden)
            {
                existence_time = 5.5f;
            }
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

        if (existence_time > 11.2f) // Hides body when offscreen
        {
            blocker.enabled = false;
            other_blocker.enabled = false;
        }

        if (existence_time > 13f) // Hides body when offscreen
        {
            body_object.SetActive(false);
        }

    }
}
