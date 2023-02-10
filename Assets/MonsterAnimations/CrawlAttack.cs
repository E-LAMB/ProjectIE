using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlAttack : MonoBehaviour
{

    public Transform start_position;
    public ColliderScript my_activator;

    public Vector3 stored_position;

    public ColliderScript my_death;
    public bool is_active;

    public GameObject body_object;
    public Transform body_transform;

    public PlayerControllerFlesh player_controller;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        body_transform.position = stored_position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!is_active && my_activator.inside_object)
        {
            is_active = true;
            body_transform.position = start_position.position;
        }

        if (is_active)
        {
            body_transform.position += new Vector3(speed * Time.deltaTime,0f,0f);
        }

        if (is_active && my_death.inside_object)
        {
            player_controller.Died();
            is_active = false;
            body_transform.position = stored_position;
        }
    }
}
