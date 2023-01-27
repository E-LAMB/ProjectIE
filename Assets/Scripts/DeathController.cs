using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls how the fluid's death collider either appears or not
public class DeathController : MonoBehaviour
{

    public Valve my_valve; // The script belonging to the death collider's valve

    public GameObject myself;
    public bool is_inverted;

    void Update()
    {
        if (!is_inverted) // If the collider should respond opposing the valve's state or not
        {
            if (my_valve.current_state) // The state of the valve
            {
                myself.SetActive(true);
            } else
            {
                myself.SetActive(false);
            }
        } else
        {
            if (my_valve.current_state)
            {
               myself.SetActive(false);
            } else
            {
                myself.SetActive(true);
            }
        }
    }
}
