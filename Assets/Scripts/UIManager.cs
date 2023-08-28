using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Setting;

    private bool settingActive;

    // Start is called before the first frame update
    void Start()
    {
        settingActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!settingActive)
            {
                Setting.SetActive(true);
                settingActive = true;
            }
            else
            {
                Setting.SetActive(false);
                settingActive = false;
            }
        }
    }

    public void OnClose()
    {
        Setting.SetActive(false);
        settingActive = false;
    }
}
