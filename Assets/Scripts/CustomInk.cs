using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the special flow of ink found in the blank level
public class CustomInk : MonoBehaviour
{

    public float time_delay;
    public bool valve_active;

    public Valve my_valve;

    public ParticleSystem my_fluid;
    public GameObject death_collider;

    public float delay_time;

    private void Update()
    {

        valve_active = my_valve.current_state;

        if (valve_active)
        {
            time_delay = 0f;
        } else
        {
            time_delay += Time.deltaTime;
        }

        if (time_delay > delay_time)
        {
            my_fluid.Play();
            if (time_delay > delay_time + 1f) { death_collider.SetActive(true); }
        } else
        {
            my_fluid.Stop();
            death_collider.SetActive(false);
        }

    }

}
