using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEye : MonoBehaviour
{

    public Transform self;
    public Transform player;
    public Transform fix;

    public float bound;

    public Vector3 target;

    public bool should_be_scripted = false;
    public AnimationCurve scripted_curve;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (should_be_scripted) 
        {
            timer += Time.deltaTime * 2f;
            if (timer > 1f) {timer -= 1f;}
        }

        target = player.position;
        target.y = fix.position.y;

        if (should_be_scripted) {target.x = fix.position.x;}
        
        if (should_be_scripted)
        {
            target.x += scripted_curve.Evaluate(timer);
        }

        if (target.x > fix.position.x + bound) 
        {
            target.x = fix.position.x + bound;
        } else if (target.x < fix.position.x - bound) 
        {
            target.x = fix.position.x - bound;
        }

        self.position = target;

    }
}
