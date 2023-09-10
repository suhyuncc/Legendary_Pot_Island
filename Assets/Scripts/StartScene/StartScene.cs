using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class StartScene : MonoBehaviour
{
    public GameObject ExplainPanel;
    public GameObject WarningPanel;
    public Button contine;
    public SaveData Save_data;
    public Item[] items;

    private SaveData1 saveData = new SaveData1();

    private string SAVE_DATA_DIRECTORY;  // 저장할 폴더 경로
    private string SAVE_FILENAME = "/SaveFile.txt"; // 파일 이름

    private void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // 전체 읽어오기
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData1>(loadJson);

            Save_data.isSaved = saveData.saveisSaved;
        }
    }

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
            NewStart();
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
            LoadData();
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

    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // 전체 읽어오기
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData1>(loadJson);

            Save_data.PhaseNum = saveData.savePhase;
            Save_data.Days = saveData.saveDays;
            Save_data.HungryCount = saveData.saveHungry;
            Save_data.isSaved = saveData.saveisSaved;

            // 인벤토리 로드
            for (int i = 0; i < saveData.itemCounts.Count; i++)
                items[i].count = saveData.itemCounts[i];

            Debug.Log("로드 완료");
        }
        else
            Debug.Log("세이브 파일이 없습니다.");
    }
}
