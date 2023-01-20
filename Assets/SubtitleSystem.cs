using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleSystem : MonoBehaviour
{

    public TextMeshProUGUI my_text;
    public string my_collect;

    public float showman_time;
    public GameObject text_object;

    public void NamedSubtitle(string name, string text, float time)
    {

        my_collect = "";
        my_collect = name;
        my_collect += ": ";
        my_collect += text;

        my_text.text = my_collect;
        showman_time = time;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showman_time > 0f)
        {
            showman_time -= Time.deltaTime;
            text_object.SetActive(true);
        } else
        {
            text_object.SetActive(false);
        }
    }
}
