using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    
    public string save_file_path = "Assets/daily_stash.txt";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void butt_load()
    {
        LoadingFile();
    }
    public void butt_save()
    {
        SavingFile("MY_MIND_HAS_GONE_BLANK");
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
        StreamWriter writer = new StreamWriter(save_file_path, true);
        writer.Write(content);
        writer.Close();
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
        }

    }
}
