using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerFlesh : MonoBehaviour
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
        self.position = focus.position + offset;
    }
}
