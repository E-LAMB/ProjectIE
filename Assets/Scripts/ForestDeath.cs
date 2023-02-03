using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDeath : MonoBehaviour
{

    public int layer_banned;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == layer_banned)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
    }

}
