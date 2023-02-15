using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatically triggers a subtitle
public class ProximitySubtitle : MonoBehaviour
{

    public int layer_banned; // The layer that triggers this script
    public bool begins = false; // Has the trigger been activated?

    public SubtitleSystem my_system; // The subtitle system

    public string name;
    public string text;
    public float time = 3f;

    public bool has_nameless = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == layer_banned && !begins)
        {
            if (has_nameless) {my_system.NamedSubtitle(name, text, time);}
            if (!has_nameless) {my_system.NamelessSubtitle(text, time);}
            begins = true; // Triggers script if the correct layer goes through it
        }
    }
}