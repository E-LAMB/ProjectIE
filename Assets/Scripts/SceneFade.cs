using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{
    public UnityEngine.UI.RawImage self;
    public Vector4 the_colour;
    public float trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        the_colour.w = trans;
        trans -= 0.3f * Time.deltaTime;
        self.color = the_colour;
    }
}
