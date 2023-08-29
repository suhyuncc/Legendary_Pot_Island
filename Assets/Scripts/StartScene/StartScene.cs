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
        //�̾ �ϱ�
        SceneManager.LoadScene("MainScene");
    }

    public void ExplainBtn()
    {
        Debug.Log("���� ����");
        ExplainPanel.SetActive(true);
    }

    public void ExitBtn()
    {
        ExplainPanel.SetActive(false);
    }
}
