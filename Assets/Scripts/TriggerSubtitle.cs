using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSubtitle : MonoBehaviour
{

    public int layer_banned;

    public bool inside_object;

    public float leaving;

    public bool begins = false;

    public SubtitleSystem my_system;

    public int to_go;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == layer_banned)
        {
            begins = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (begins)
        {
            leaving += Time.deltaTime;
        }
        if (leaving > 3f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(to_go);
        }
    }
}
