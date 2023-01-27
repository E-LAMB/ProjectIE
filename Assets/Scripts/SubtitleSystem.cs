using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script controls the subtitles that appear throughout the game
public class SubtitleSystem : MonoBehaviour
{

    public TextMeshProUGUI my_text; // Accessing the text component

    public string my_collect; // The "Collective" text that will be shown
    public float showman_time; // How long the text will be shown
    public GameObject text_object; // The Gameobject for the text, Which can be used to make it appear/disappear

    public void NamedSubtitle(string name, string text, float time) // The procedure called from other scripts to use/display subtitles
    {

        my_collect = "";
        my_collect = name;
        my_collect += ": ";
        my_collect += text;

        my_text.text = my_collect; // Sets the text to what we will show
        showman_time = time; // Sets the time to show the text

    }

    void Update()
    {
        if (showman_time > 0f) // If time is above zero, Count down and show the text. Otherwise, Hide it.
        {
            showman_time -= Time.deltaTime;
            text_object.SetActive(true);
        } else
        {
            text_object.SetActive(false);
        }
    }
}
