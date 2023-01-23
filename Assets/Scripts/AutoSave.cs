using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AutoSave : MonoBehaviour
{

    public string path = "Assets/daily_stash.txt";
    public string content = "NEVER_RAN_SO_YOURE_NEW";

    public float icon_time = 3f;
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        path = Mind.save_path;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(content);
        writer.Close();
        Debug.Log("Saved progress");
    }

    // Update is called once per frame
    void Update()
    {

        if (icon_time > 0f)
        {
            icon_time -= Time.deltaTime;
            icon.SetActive(false);
        } else
        {
            icon.SetActive(false);
        }
    }
}
