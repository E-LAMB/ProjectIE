using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float running_time = 0f;
    public int running_stage = 1;
    // 0 - 30
    // 31 - 60
    // 61 - 90
    // 91 - 120
    // 120 +      (Does not spawn)

    public GameObject[] set_1;
    public GameObject[] set_2;
    public GameObject[] set_3;
    public GameObject[] set_4;

    public GameObject[] spawn_set;

    public int maximum_spawn;
    public int random_spawn;

    public Transform self;
    public GameObject selected_object;

    public float wait_time_max;
    public float wait_time_decrease;
    public float wait_time;
    public float timer;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

        running_time += Time.deltaTime;

        Vector3 new_pos;
        new_pos = self.position;
        new_pos.x += speed * Time.deltaTime;
        self.position = new_pos;

        if (running_time > 0f && running_time < 15f)
        {
            running_stage = 1;
        }
        if (running_time > 15f && running_time < 30f)
        {
            running_stage = 2;
        }
        if (running_time > 30f && running_time < 45f)
        {
            running_stage = 3;
        }
        if (running_time > 45f && running_time < 60f)
        {
            running_stage = 4;
        }

        if (running_time > 60f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        }

        wait_time = wait_time_decrease * running_stage;
        wait_time = wait_time * -1f;
        wait_time = wait_time + wait_time_max;

        timer += Time.deltaTime;

        if (running_stage == 1)
        {
            spawn_set = set_1;
        }
        if (running_stage == 2)
        {
            spawn_set = set_2;
        }
        if (running_stage == 3)
        {
            spawn_set = set_3;
        }
        if (running_stage == 4)
        {
            spawn_set = set_4;
        }

        maximum_spawn = spawn_set.Length;
        //maximum_spawn -= 1;

        random_spawn = Random.Range(0,maximum_spawn);

        selected_object = spawn_set[random_spawn];

        if (timer > wait_time)
        {
            timer = 0f;
            Instantiate(selected_object, self.position, self.rotation);
        }

    }
}
