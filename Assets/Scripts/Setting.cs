using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isActive)
            {
                this.gameObject.SetActive(true);
                isActive = true;
            }
            else
            {
                this.gameObject.SetActive(false);
                isActive = false;
            }
        }
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
    }
}
