using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal4 : MonoBehaviour
{

    public int page = 1;

    public GameObject obj_1;
    public GameObject obj_2;
    public GameObject obj_3;
    public GameObject obj_4;
    public GameObject obj_5;

    public void TurnOver()
    {
        page += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        obj_1.SetActive(false);
        obj_2.SetActive(false);
        obj_3.SetActive(false);
        obj_4.SetActive(false);
        obj_5.SetActive(false);

        if (page == 1) {obj_1.SetActive(true);}
        if (page == 2) {obj_2.SetActive(true);}
        if (page == 3) {obj_3.SetActive(true);}
        if (page == 4) {obj_4.SetActive(true);}
        if (page == 5) {obj_5.SetActive(true);}
        if (page == 6) {UnityEngine.SceneManagement.SceneManager.LoadScene(12);}
    }
}
