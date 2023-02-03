using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{

    public Transform self;

    public float time;

    public float strength;

    public GameObject self_ob;

    public Vector3 scales;

    public float show_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time < show_time)
        {
            scales.x = Random.Range(3f,strength);
            scales.y = Random.Range(3f,strength);
            scales.z = Random.Range(3f,strength);
            self.localScale = scales;
        } else
        {
            self_ob.SetActive(false);
        }
    }
}
