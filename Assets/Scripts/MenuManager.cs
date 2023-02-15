using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This script manages the Main Menu's Variants and the loading system
public class MenuManager : MonoBehaviour
{
    
    // Controls the player's progress
    public string save_file_path = "Assets/daily_stash.txt";
    public int pick_up_location;

    // The two sets of buttons that can appear
    public GameObject new_menu;
    public GameObject previous_menu;

    // The different menus that can appear
    public GameObject collection_0;
    public GameObject collection_1;
    public GameObject collection_2;
    public GameObject collection_3;
    public GameObject collection_4;

    void Start()
    {
        Mind.save_path = Application.persistentDataPath + "/daily_stash.txt"; // Finds a "Persistant" data path which exists on all computers. This allows save files to work anywhere!

        if (!File.Exists(Mind.save_path)) { File.Create(Mind.save_path);} else { Debug.Log("Exists!"); } // Creates a file if one does not already exist

        Debug.Log(Mind.save_path); // Returns path prevents script running until returning to this menu
        Mind.startup_script_ran = false;

        collection_0.SetActive(false);
        collection_1.SetActive(false);
        collection_2.SetActive(false);
        collection_3.SetActive(false);
        collection_4.SetActive(false);
    }

    public void butt_load()
    {
        LoadingFile(); // Allows the button to use the Load Function. Originally the Load function had parameters that could not be met.
    }

    public void butt_form()
    {
        Application.OpenURL("https://forms.gle/GGGUQAtLeD7Ud9yp7"); // URL
    }

    public void reset_game()
    {
        StreamWriter writer = new StreamWriter(save_file_path, false); // Writes the progress to the file when the scene is loaded
        writer.Write("NEVER_RAN_SO_YOURE_NEW");
        writer.Close();
        Debug.Log("Saved progress");
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);

    }

    public string LoadingFile() // A function for finding the contents of the file and returning it as a string.
    {
        StreamReader reader = new StreamReader(save_file_path);
        string content;
        content = reader.ReadToEnd(); // Reads the content in the file
        reader.Close();
        Debug.Log(content); 
        return content; // Returns the content
    }

    public void SavingFile(string content) // A procedure for saving content into a file, Used for the save file
    {
        StreamWriter writer = new StreamWriter(save_file_path, false);
        writer.Write(content);
        writer.Close();
    }

    public void pick_up_switch() // Loads the correct scene due to progress
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(pick_up_location);
    }

    // Update is called once per frame
    void Update()
    {

        save_file_path = Mind.save_path; // Loads the path saved in Mind

        if (!Mind.startup_script_ran)
        {
            Mind.startup_script_ran = true;
            string extracted;
            extracted = LoadingFile(); // Loads save data

            // Converts the respective file data into a specific number representing points of the game

            // "NEVER_RAN_SO_YOURE_NEW" - You haven't played the game before
            // "MY_MIND_HAS_GONE_BLANK" - You entered the blank level
            // "OUT_OF_ART_TO_MAKE" - You exited the blank level
            // "WANNA_PLAY_SCORN_ANYONE" - You entered the fleshy level
            // "FLESH_BLOOD_AND_DONE" - You exited the fleshy level
            // "ITS_A_MAD_MAD_WORLD" - You entered the asylum level
            // "THE_VOICES_ARE_SILENCED" - You exited the asylum level
            // "PART_OF_PAINTING_IS_THE_END" - You saw the ending of the game

            if (extracted == "NEVER_RAN_SO_YOURE_NEW") {Mind.saved_game_point = 0;}
            if (extracted == "MY_MIND_HAS_GONE_BLANK") {Mind.saved_game_point = 1;}
            if (extracted == "OUT_OF_ART_TO_MAKE") {Mind.saved_game_point = 2;}
            if (extracted == "WANNA_PLAY_SCORN_ANYONE") {Mind.saved_game_point = 3;}
            if (extracted == "FLESH_BLOOD_AND_DONE") {Mind.saved_game_point = 4;}
            if (extracted == "ITS_A_MAD_MAD_WORLD") {Mind.saved_game_point = 5;}
            if (extracted == "THE_VOICES_ARE_SILENCED") {Mind.saved_game_point = 6;}
            if (extracted == "PART_OF_PAINTING_IS_THE_END") {Mind.saved_game_point = 7;}
 
            Debug.Log(Mind.saved_game_point); // Outputs the point
            Debug.Log(extracted);

            // Sets the scene in relation to the progress of the player's game
            if (Mind.saved_game_point == 0) {pick_up_location = 4;}
            if (Mind.saved_game_point == 1) {pick_up_location = 1;}
            if (Mind.saved_game_point == 2) {pick_up_location = 8;}
            if (Mind.saved_game_point == 3) {pick_up_location = 2;}
            if (Mind.saved_game_point == 4) {pick_up_location = 9;}
            if (Mind.saved_game_point == 5) {pick_up_location = 3;}
            if (Mind.saved_game_point == 6) {pick_up_location = 10;}
            if (Mind.saved_game_point == 7) {pick_up_location = 11;}
        }

        // Controls which set of buttons appear
        if (Mind.saved_game_point == 0)
        {
            new_menu.SetActive(true);
            previous_menu.SetActive(false);
        } else
        {
            new_menu.SetActive(false);
            previous_menu.SetActive(true);
        }

        // ----- The menus ----- //
        // Controls which menu appears

        if (Mind.saved_game_point == 0) {collection_0.SetActive(true);} 
        if (Mind.saved_game_point == 1) {collection_1.SetActive(true);} 
        if (Mind.saved_game_point == 2) {collection_1.SetActive(true);} 
        if (Mind.saved_game_point == 3) {collection_2.SetActive(true);} 
        if (Mind.saved_game_point == 4) {collection_2.SetActive(true);} 
        if (Mind.saved_game_point == 5) {collection_3.SetActive(true);} 
        if (Mind.saved_game_point == 6) {collection_3.SetActive(true);} 
        if (Mind.saved_game_point == 7) {collection_4.SetActive(true);} 



    }
}
