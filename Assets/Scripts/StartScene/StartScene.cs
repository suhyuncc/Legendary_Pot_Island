using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public GameObject ExplainPanel;
    public GameObject WarningPanel;
    public Button contine;
    public SaveData Save_data;
    public Item[] items;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExplainPanel.SetActive(false);
        }

        if (!Save_data.isSaved)
        {
            contine.interactable = false;
        }
        else 
        { 
            contine.interactable = true;
        }
    }
    public void PlayMainScene()
    {
        if (!Save_data.isSaved)
        {
            Save_data.isSaved = true;
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            WarningPanel.SetActive(true);
        }
        
    }

    public void ContinueScene()
    {
        if (Save_data.isSaved)
        {
            //이어서 하기
            SceneManager.LoadScene("MainScene");
        }
        
    }

    public void NewStart()
    {
        Save_data.PhaseNum = 1;
        Save_data.Days = 1;
        Save_data.HungryCount = 0;
        Save_data.isSaved = true;

        for(int i = 0; i < items.Length; i++)
        {
            items[i].count = 0;
        }

        SceneManager.LoadScene("MainScene");
    }

    public void ExplainBtn()
    {
        Debug.Log("게임 설명");
        ExplainPanel.SetActive(true);
    }

    public void ExitBtn()
    {
        ExplainPanel.SetActive(false);
    }

    public void FinBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
