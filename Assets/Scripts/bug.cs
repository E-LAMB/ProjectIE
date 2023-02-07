using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour
{

    public float scale;
    public Transform self;
    public Vector3 forced_scale;

    public bool held;

    // Start is called before the first frame update
    void Start()
    {
        forced_scale = self.localScale;
        scale = forced_scale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            held = true;
        } 
        if (Input.GetKeyUp(KeyCode.A))
        {
            held = false;
        }

        if (held) {scale += 0.0005f;}
        forced_scale.x = scale;
        self.localScale = forced_scale;
    }
}
