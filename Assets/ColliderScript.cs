using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{

    public int layer_banned;

    public bool inside_object;

    public int type;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == layer_banned)
        {
            inside_object = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == layer_banned)
        {
            inside_object = false;        
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1) {Mind.player_is_inside_object = inside_object;}
        if (type == 2) {Mind.player_behind_object = inside_object;}
    }
}
