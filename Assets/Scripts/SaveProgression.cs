using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This script advances the save state of the game to it's next state
public class SaveProgression : MonoBehaviour
{

    public string path;

    public string current_position;

    public string content;

    // "NEVER_RAN_SO_YOURE_NEW" - You haven't played the game before
    // "MY_MIND_HAS_GONE_BLANK" - You entered the blank level
    // "OUT_OF_ART_TO_MAKE" - You exited the blank level
    // "WANNA_PLAY_SCORN_ANYONE" - You entered the fleshy level
    // "FLESH_BLOOD_AND_DONE" - You exited the fleshy level
    // "ITS_A_MAD_MAD_WORLD" - You entered the asylum level
    // "THE_VOICES_ARE_SILENCED" - You exited the asylum level
    // "PART_OF_PAINTING_IS_THE_END" - You saw the ending of the game

    void Start()
    {
        path = Mind.save_path; // Sets the Save File's Path to the one saved in MIND

        StreamReader reader = new StreamReader(path);
        current_position = reader.ReadToEnd(); // Reads the content in the file
        reader.Close();

        if (current_position == "MY_MIND_HAS_GONE_BLANK") {content = "OUT_OF_ART_TO_MAKE";} // Changes the content
        if (current_position == "WANNA_PLAY_SCORN_ANYONE") {content = "FLESH_BLOOD_AND_DONE";} // Changes the content
        if (current_position == "ITS_A_MAD_MAD_WORLD") {content = "THE_VOICES_ARE_SILENCED";} // Changes the content

        StreamWriter writer = new StreamWriter(path, false); // Writes the progress to the file when the scene is loaded
        writer.Write(content);
        writer.Close();
        Debug.Log("Updated progress");
    }
}
