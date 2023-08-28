using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Inventroy;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        Debug.Log(Inventroy.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(!isActive)
            {
                Inventroy.SetActive(true);
                isActive = true;
            }
            else
            {
                Inventroy.SetActive(false);
                isActive = false;
            }
        }
    }
}
