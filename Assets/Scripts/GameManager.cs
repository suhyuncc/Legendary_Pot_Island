using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Inventroy;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Inventroy.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && Inventroy.activeSelf == false)
        {
            if(Inventroy.activeSelf == false) { 
                Inventroy.SetActive(true);
            }
            else
            {
                Inventroy.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape)&& Inventroy.activeSelf == true)
        {
            Inventroy.SetActive(false);
        }
    }
}
