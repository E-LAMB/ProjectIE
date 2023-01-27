using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An automatic trigger that forces a subtitle and scene change
public class TriggerSubtitle : MonoBehaviour
{

    public int layer_banned; // The layer that triggers this script

    public bool inside_object; // The remains from an old version of this script

    public float leaving; // Time until the scene changes

    public bool begins = false; // Has the trigger been activated?

    public SubtitleSystem my_system; // The subtitle system

    public int to_go; // The scene to go to

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == layer_banned)
        {
            begins = true; // Triggers script if the correct layer goes through it
        }
    }

    void Update()
    {
        if (begins)
        {
            leaving += Time.deltaTime; // Increases timer if script is active
        }
        if (leaving > 2f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(to_go); // Switches scene
        }
    }
}
