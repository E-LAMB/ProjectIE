using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    
    public string save_file_path = "Assets/daily_stash.txt";
    public int pick_up_location;

    public GameObject new_menu;
    public GameObject previous_menu;

    public GameObject collection_0;
    public GameObject collection_1;
    public GameObject collection_2;
    public GameObject collection_3;
    public GameObject collection_4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void butt_load()
    {
        LoadingFile();
    }
    public void reset_game()
    {
        SavingFile("NEVER_RAN_SO_YOURE_NEW");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }

    public string LoadingFile()
    {
        StreamReader reader = new StreamReader(save_file_path);
        string content;
        content = reader.ReadToEnd();
        reader.Close();
        Debug.Log(content);
        return content;
    }

    public void SavingFile(string content)
    {
        StreamWriter writer = new StreamWriter(save_file_path, false);
        writer.Write(content);
        writer.Close();
    }

    public void pick_up_switch()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(pick_up_location);
    }

    // Update is called once per frame
    void Update()
    {

        if (!Mind.startup_script_ran)
        {
            Mind.startup_script_ran = true;
            string extracted;
            extracted = LoadingFile();

            if (extracted == "NEVER_RAN_SO_YOURE_NEW") {Mind.saved_game_point = 0;}
            if (extracted == "MY_MIND_HAS_GONE_BLANK") {Mind.saved_game_point = 1;}
            if (extracted == "WANNA_PLAY_SCORN_ANYONE") {Mind.saved_game_point = 2;}
            if (extracted == "ITS_A_MAD_MAD_WORLD") {Mind.saved_game_point = 3;}
            if (extracted == "PART_OF_PAINTING_IS_THE_END") {Mind.saved_game_point = 4;}

            Debug.Log(Mind.saved_game_point);

            if (Mind.saved_game_point == 0) {pick_up_location = 4;}
            if (Mind.saved_game_point == 1) {pick_up_location = 1;}
            if (Mind.saved_game_point == 2) {pick_up_location = 5;}
            if (Mind.saved_game_point == 3) {pick_up_location = 6;}
            if (Mind.saved_game_point == 4) {pick_up_location = 7;}
        }

        if (Mind.saved_game_point == 0)
        {
            new_menu.SetActive(true);
            previous_menu.SetActive(false);
        } else
        {
            new_menu.SetActive(false);
            previous_menu.SetActive(true);
        }

        if (Mind.saved_game_point == 0)
        {
            collection_0.SetActive(true);
        } else
        {
            collection_0.SetActive(false);
        }

        // --------------------------------------------- //

        if (Mind.saved_game_point == 1)
        {
            collection_1.SetActive(true);
        } else
        {
            collection_1.SetActive(false);
        }

        // --------------------------------------------- //

        if (Mind.saved_game_point == 2)
        {
            collection_2.SetActive(true);
        } else
        {
            collection_2.SetActive(false);
        }

        // --------------------------------------------- //

        if (Mind.saved_game_point == 3)
        {
            collection_3.SetActive(true);
        } else
        {
            collection_3.SetActive(false);
        }

        // --------------------------------------------- //

        if (Mind.saved_game_point == 4)
        {
            collection_4.SetActive(true);
        } else
        {
            collection_4.SetActive(false);
        }

    }
}
