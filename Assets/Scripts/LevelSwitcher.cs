using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    
    public void SceneSwitch(int scene_id)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_id);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
