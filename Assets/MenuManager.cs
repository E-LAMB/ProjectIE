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

    public void LoadingFile(string name)
    {
        StreamReader reader = new StreamReader(name);
        string content;
        content = reader.ReadToEnd();
        reader.Close();
        //return content;
    }

    public void SavingFile(string name)
    {
        /*StreamWriter writer = new StreamWriter(name, true);
        writer.WriteLine(content);
        writer.Close();*/
    }

    // Update is called once per frame
    void Update()
    {

        if (!Mind.startup_script_ran)
        {
           /* Mind.startup_script_ran = true;
            string extracted;
            extracted = LoadingFile(save_file_path);

            if (extracted == "NEVER_RAN_SO_YOURE_NEW") {Mind.saved_game_point = 0;}
            if (extracted == "MY_MIND_HAS_GONE_BLANK") {Mind.saved_game_point = 1;}
            if (extracted == "WANNA_PLAY_SCORN_ANYONE") {Mind.saved_game_point = 2;}
            if (extracted == "ITS_A_MAD_MAD_WORLD") {Mind.saved_game_point = 3;}
            if (extracted == "PART_OF_PAINTING_IS_THE_END") {Mind.saved_game_point = 4;}
            Debug.Log(Mind.saved_game_point);
*/
        }

    }
}
