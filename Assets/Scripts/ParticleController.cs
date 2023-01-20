using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    public ParticleSystem my_system;
    public Valve my_valve;
    public bool is_inverted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_inverted)
        {
            if (my_valve.current_state)
            {
                my_system.Play();
            } else
            {
                my_system.Stop();
            }
        } else
        {
            if (my_valve.current_state)
            {
                my_system.Stop();
            } else
            {
                my_system.Play();
            }
        }

        // # Is this a comment too?
    }
}
