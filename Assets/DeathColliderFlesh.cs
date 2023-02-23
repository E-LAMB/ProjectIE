using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathColliderFlesh : MonoBehaviour
{

    public PlayerControllerFlesh player_controller;
    public ColliderScript my_death;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (my_death.inside_object)
        {
            player_controller.Died();
        }
    }
}
