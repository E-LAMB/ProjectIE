using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggledFluids : MonoBehaviour
{

    public GameObject fluid_A;
    public GameObject fluid_B;
    public GameObject death_A;
    public GameObject death_B;

    public bool active_pipe;

    public float timer;

    public Valve my_valve;
    public bool my_state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_state = my_valve.current_state;

        timer += Time.deltaTime;

        if (timer > 2f)
        {
            timer = 0f;
            active_pipe = !active_pipe;
        }

        if (active_pipe)
        {
            if (!my_state)
            {
                fluid_A.SetActive(true);
                death_A.SetActive(true);
            } 
            if (my_state)
            {
                fluid_A.SetActive(false);
                death_A.SetActive(false);
            }
        } else
        {
            death_A.SetActive(false);
        }

    }
}
