using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodle : MonoBehaviour
{

    public Transform self;

    public float x_max_screen;
    public float x_min_screen;
    public float y_max_screen;
    public float y_min_screen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        self.position = new Vector2(mousePos.x, mousePos.y);
    }
}
