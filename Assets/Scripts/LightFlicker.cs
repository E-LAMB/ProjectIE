using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light my_light;

    public float max_brightness;
    public float min_brightness;

    public float chosen_brightness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chosen_brightness = Random.Range(min_brightness,max_brightness);
        my_light.intensity = chosen_brightness;
    }
}
