using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCover : MonoBehaviour
{

    public bool closed;
    
    public ColliderScript my_collider;

    public Transform self;
    public Transform final_position;

    public Vector3 final_location;

    // Start is called before the first frame update
    void Start()
    {
        final_location = final_position.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (my_collider.inside_object) {closed = true;}
        if (closed)
        {
            self.position = Vector3.MoveTowards(self.position, final_location, 5f * Time.deltaTime);
        }
    }
}
