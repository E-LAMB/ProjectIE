using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoves : MonoBehaviour
{

    public ColliderScript the_collider;

    public bool should_begin;

    public float existence_time;

    public Transform pos_spawn;
    public Transform rise_spawn;
    public Transform run_spawn;

    public GameObject body_object;
    public Transform body_trans;

    public SubtitleSystem my_system;

    // Start is called before the first frame update
    void Start()
    {
        body_object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (the_collider.inside_object && !should_begin)
        {
            should_begin = true;
            body_object.SetActive(true);
            body_trans.position = pos_spawn.position;
            my_system.NamedSubtitle("Jean","I heard something, I should hide quickly!",5f);
        }

        if (should_begin)
        {
            existence_time += Time.deltaTime;
        }

        if (existence_time > 6f && 9f > existence_time)
        {
            body_trans.position = Vector3.MoveTowards(body_trans.position, rise_spawn.position, 15f * Time.deltaTime);
        }

        if (existence_time > 6f && 8f > existence_time)
        {
            my_system.NamedSubtitle("Facefull","Where are those faces? I need more... MORE!!",2f);
        }

        if (existence_time > 10f)
        {
            body_trans.position = Vector3.MoveTowards(body_trans.position, run_spawn.position, 95f * Time.deltaTime);
        }

        if (existence_time > 14f)
        {
            body_object.SetActive(false);
        }



    }
}
