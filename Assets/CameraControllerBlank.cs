using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBlank : MonoBehaviour
{

    public Vector3 offset;
    public Transform self;
    public Transform focus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ideal_location;
        ideal_location = focus.position + offset;
        ideal_location.y = 0.04182267f;
        self.position = ideal_location;
    }
}
