using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject ExplainPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExplainPanel.SetActive(false);
        }
    }
    public void PlayMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ContinueScene()
    {
        //이어서 하기
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
}
