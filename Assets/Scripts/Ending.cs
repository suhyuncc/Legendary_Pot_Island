using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{

    public GameObject EndingPanel;
    public SaveData Save_data;
    public Item[] items;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            EndingPanel.SetActive(true);
        }
    }
    public void OnClose()
    {
        EndingPanel.SetActive(false);
    }
    public void Restart()
    {
        EndingPanel.SetActive(false);
        End_to_NewStart();
    }

    public void End_to_NewStart()
    {
        Save_data.PhaseNum = 1;
        Save_data.Days = 1;
        Save_data.HungryCount = 0;
        Save_data.isSaved = false;

        for (int i = 0; i < items.Length; i++)
        {
            items[i].count = 0;
        }

        SceneManager.LoadScene("StartScene");
    }
}
