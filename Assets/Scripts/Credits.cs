using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script controls the credits at the end of the game and allows for them to be customisable 
public class Credits : MonoBehaviour
{

    public string[] credits; // All the different text states for the credits

    public int current_credit; // The current credit on screen
    public int maximum_credit; // The last credit in the list

    // Controls how quickly credits switch
    public float interval;
    public float timer;

    public TextMeshProUGUI text_object; // The text to switch

    void Start()
    {
        // Calculates the length of the credits
        maximum_credit = credits.Length;
        maximum_credit -= 1;

    }

    void Update()
    {

        //  The timer changes the credits to the next one unless it is the last one
        timer += Time.deltaTime; 
        if (timer > interval && current_credit != maximum_credit)
        {
            timer = 0f;
            current_credit += 1;
        }

        text_object.text = credits[current_credit]; // Changes the text to the current credit

        // Takes you to the menu once you have finished the credits
        if (current_credit == maximum_credit && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Return to menu");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
}
