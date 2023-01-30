using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This script automatically saves the player's progress to a text file
public class AutoSave : MonoBehaviour
{

    public string path = "Assets/daily_stash.txt"; // The location of the save file
    public string content = "NEVER_RAN_SO_YOURE_NEW"; // The text that should be written in the save file

    public float icon_time = 3f; // How long to show the save icon for
    public GameObject icon; // The icon to show

    void Start()
    {
        path = Mind.save_path; // Sets the Save File's Path to the one saved in MIND

        StreamWriter writer = new StreamWriter(path, false); // Writes the progress to the file when the scene is loaded
        writer.Write(content);
        writer.Close();
        Debug.Log("Saved progress");
    }

    void Update()
    {
        if (icon_time > 0f) // Controls the icon showing (In game, The logo has been set to transparent so nothing actually happens)
        {
            icon_time -= Time.deltaTime;
            icon.SetActive(false);
        } else
        {
            icon.SetActive(false);
        }
    }
}
