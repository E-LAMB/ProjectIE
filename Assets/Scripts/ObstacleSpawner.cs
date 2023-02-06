using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the spawning of obstacles in the Forest level
public class ObstacleSpawner : MonoBehaviour
{

    public float running_time = 0f; // How long the player has been in the level for
    public int running_stage = 1; // This controls the group of platforms it will pull from
    // 0 - 30
    // 31 - 60
    // 61 - 90
    // 91 - 120
    // 120 +      (Does not spawn)

    public int maximum_spawn; // The largest item in the array (of spawn items)
    public int random_spawn; // The item picked in the array (of spawn items)

    public Transform self; // Own position

    public float wait_time_max; // The maximum delay between platform spawns
    public float wait_time_decrease; // The delay decrease as time progresses (ie. spawns faster after longer time)
    public float wait_time; // The current delay time
    public float timer; // A timer that always increases

    public float speed; // The speed which the spawner itself moves

    [Header("Spawn Groups")]
    public GameObject selected_object; // Object selected from list
    public GameObject[] set_1;
    public GameObject[] set_2;
    public GameObject[] set_3;
    public GameObject[] set_4;
    public GameObject[] empty_set;
    public GameObject[] spawn_set;

    void Update()
    { 

        running_time += Time.deltaTime; // Timer in seconds

        // Controls movement of spawner
        Vector3 new_pos;
        new_pos = self.position;
        new_pos.x += speed * Time.deltaTime;
        self.position = new_pos;

        // Controls the "stage" the player is on and which spawn group to draw from
        if (running_time > 0f && running_time < 10f)
        {
            running_stage = 1;
        }
        if (running_time > 10f && running_time < 20f)
        {
            running_stage = 2;
        }
        if (running_time > 20f && running_time < 30f)
        {
            running_stage = 3;
        }
        if (running_time > 30f && running_time < 40f)
        {
            running_stage = 4;
        }
        if (running_time > 60f)
        {
            running_stage = 5;
        }

        // Takes the player to the next scene
        if (running_time > 46f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(13);
        }

        // Calculates the delay between spawning based on the stage
        wait_time = wait_time_decrease * running_stage;
        wait_time = wait_time * -1f;
        wait_time = wait_time + wait_time_max;

        timer += Time.deltaTime; // Counts the timer to spawn in seconds

        // Decides which set to spawn from
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
        if (running_stage == 5)
        {
            spawn_set = empty_set;
        }

        maximum_spawn = spawn_set.Length; // Finds the highest item in the list
        // maximum_spawn -= 1; (removed)

        random_spawn = Random.Range(0,maximum_spawn); // Picks a random item in the list
        selected_object = spawn_set[random_spawn]; // Finds the relvant Gameobject

        timer += Random.Range(0.1f * Time.deltaTime, 0.3f * Time.deltaTime);

        if (timer > wait_time) // Once the time is over, Spawns the respective object
        {
            timer = 0f;
            Instantiate(selected_object, self.position, self.rotation);
        }

    }
}
