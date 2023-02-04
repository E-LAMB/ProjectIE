using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [UNFINISHED SCRIPT]
public class Scrolling : MonoBehaviour
{

    public GameObject player;
    public Renderer rend;

    public float start_pos;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        start_pos = player.transform.position.x;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (player.transform.position.x - start_pos) * speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset,0f));
    }
}
