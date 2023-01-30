using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the buttons in the game and other scripts to change the scene
public class LevelSwitcher : MonoBehaviour
{
    
    public void SceneSwitch(int scene_id) // Procedure available to buttons that teleports the player to the right scene
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_id);
    }

    public void GameQuit() // Procedure available to buttons that closes the game
    {
        Application.Quit();
    }

}
