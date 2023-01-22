using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{

    public string[] credits;

    public int current_credit;
    public int maximum_credit;

    public float interval;
    public float timer;

    public TextMeshProUGUI text_object;

    // Start is called before the first frame update
    void Start()
    {

        maximum_credit = credits.Length;
        maximum_credit -= 1;

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > interval && current_credit != maximum_credit)
        {
            timer = 0f;
            current_credit += 1;
        }

        text_object.text = credits[current_credit];

        if (current_credit == maximum_credit && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Return to menu");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}
