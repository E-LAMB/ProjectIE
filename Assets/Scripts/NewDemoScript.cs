using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDemoScript : MonoBehaviour 
{

    // WELL DONE GUYS!!

    // Our method which returns a Vector3
    // Our method takes in two parameters, The incident ray and the normal. 
    Vector3 Reflection(Vector3 incident_ray, Vector3 normal) 
    {

        // Create a new Vector3
        Vector3 result; 

        // Find the numerator
        float numerator = Vector3.Dot(incident_ray, normal) * 2; 

        // Find the denominator
        float denominator = normal.magnitude; // Find the magnitude of the normal
        denominator = denominator * denominator; // Square the denominator

        // Calcualting the final result
        result = incident_ray - ((numerator / denominator) * normal);

        // Returns result
        return result; 

    }

    void Start()
    {
        
        Debug.Log(Reflection(new Vector3(1f,1f,0f), Vector3.up)); // Outputs to the console

    }

    void Update()
    {
        


    }

}
