using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Pedistal : MonoBehaviour
{

    public SubtitleSystem subtitle_system;
    public LevelSwitcher level_switcher;

    public string text_to_use;
    public float time_to_use;

    public int scene_to_warp;

    public float player_distance;

    public bool interacted_with;

    public Transform self;
    public Transform player;

    public float warp_time = -20f;

    public GameObject my_prompt;

    public float interaction_range;

    public bool should_warp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        player_distance = Vector3.Distance(self.position, player.position);

        if (player_distance < interaction_range && !interacted_with && Input.GetKeyDown(KeyCode.E))
        {
            interacted_with = true;
            subtitle_system.NamedSubtitle("Jean", text_to_use, time_to_use);
            warp_time = 0f;
        }

        if (player_distance < interaction_range && !interacted_with)
        {
            my_prompt.SetActive(true);
        } else
        {
            my_prompt.SetActive(false);
        }

        if (warp_time > -2f)
        {
            warp_time += Time.deltaTime;
        }

        if (warp_time > time_to_use && should_warp)
        {
            level_switcher.SceneSwitch(scene_to_warp);
        }

    }
}
