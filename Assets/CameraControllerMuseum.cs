using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMuseum : MonoBehaviour
{

    public Transform self;

    public Transform right_boundary;
    public Transform left_boundary;

    public Transform focus_on;

    public Vector3 target_location;

    public float right_float;
    public float left_float;

    public float y_lock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        right_float = right_boundary.position.x;
        left_float = left_boundary.position.x;

        target_location = focus_on.position;

        if (target_location.x > right_float)
        {
            target_location.x = right_float;
        }

        if (target_location.x < left_float)
        {
            target_location.x = left_float;
        }

        target_location.y = y_lock;

        self.position = target_location;
        
    }
}
