using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLooking : MonoBehaviour
{

    public bool player_on_right;
    public bool player_on_left;

    public ColliderScript left_checker;
    public ColliderScript right_checker;

    public bool facing_right;

    public bool player_hidden;

    public float looking_timer;
    public float time_switch_threshold;

    public Transform self;
    public Vector3 ideal_scale;

    void PlayerDied()
    {
        Debug.Log("YOU DIED");
    }

    // Start is called before the first frame update
    void Start()
    {
        ideal_scale = self.localScale;  
    }

    // Update is called once per frame
    void Update()
    {

        self.localScale = ideal_scale;
    
        looking_timer += Time.deltaTime;

        if (looking_timer > time_switch_threshold)
        {
            looking_timer = 0f;
            facing_right = !facing_right;
            ideal_scale.x = ideal_scale.x * -1;
        }

        player_on_left = left_checker.inside_object;
        player_on_right = right_checker.inside_object;

        player_hidden = Mind.player_is_hidden;

        if (facing_right && player_on_right && !player_hidden)
        {
            PlayerDied();
        }

        if (!facing_right && player_on_left && !player_hidden)
        {
            PlayerDied();
        }

    }
}
