using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script shows the final poem all together allowing the player to read stanza by stanza
public class Pedistal4 : MonoBehaviour
{

    public int page = 1; // The part of the poem they are on

    // The different poems
    public GameObject obj_1;
    public GameObject obj_2;
    public GameObject obj_3;
    public GameObject obj_4;
    public GameObject obj_5;

    public void TurnOver() // A procedure to increment the page. This can be accessed by a button
    {
        page += 1;
    }

    void Update()
    {
        // Hides everything
        obj_1.SetActive(false);
        obj_2.SetActive(false);
        obj_3.SetActive(false);
        obj_4.SetActive(false);
        obj_5.SetActive(false);

        // Shows the right page
        if (page == 1) {obj_1.SetActive(true);}
        if (page == 2) {obj_2.SetActive(true);}
        if (page == 3) {obj_3.SetActive(true);}
        if (page == 4) {obj_4.SetActive(true);}
        if (page == 5) {obj_5.SetActive(true);}

        if (page == 6) {UnityEngine.SceneManagement.SceneManager.LoadScene(12);} // Takes the player to the end credits
    }
}
