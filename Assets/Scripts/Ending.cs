using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{

    public GameObject EndingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        SceneManager.LoadScene("StartScene");
    }
}
