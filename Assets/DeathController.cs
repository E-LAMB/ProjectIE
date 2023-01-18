using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{

    public Valve my_valve;
    public GameObject myself;
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
