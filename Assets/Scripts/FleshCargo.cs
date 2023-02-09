using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshCargo : MonoBehaviour
{

    public GameObject my_lever;
    
    public LayerMask player_layer;
    public bool player_is_close;

    public bool activated;

    public GameObject my_prompt;

    public Transform my_cargo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        player_is_close = Physics2D.OverlapCircle(my_lever.transform.position, 2f, player_layer);

        if (activated) {my_cargo.position += Vector3.up * Time.deltaTime;}

        if (player_is_close && !activated) {my_prompt.SetActive(true);} else {my_prompt.SetActive(false);}

        if (player_is_close && Input.GetKeyDown(KeyCode.E) && !activated)
        {
            activated = true;
        }

    }
}
