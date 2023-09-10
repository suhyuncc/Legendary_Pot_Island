using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject soundManager;
    [SerializeField]
    private Slider soundBar;
    [SerializeField]
    private TextMeshProUGUI soundtext;

    private bool isActive;
    private float volume;

    private SaveData1 saveData = new SaveData1();

    private string SAVE_DATA_DIRECTORY;  // 저장할 폴더 경로
    private string SAVE_FILENAME = "/SaveFile.txt"; // 파일 이름

    // Start is called before the first frame update
    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // 해당 경로가 존재하지 않는다면
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // 폴더 생성(경로 생성)

        isActive = false;
        soundBar.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        soundManager.GetComponent<AudioSource>().volume = soundBar.value;
        soundtext.text = $"{(int)(soundBar.value * 100)}";

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

    public void SaveAndExit()
    {
        SaveData();
        SceneManager.LoadScene("StartScene");
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
    }

    public void SaveData()
    {
        saveData.savePhase = ItemManager.Instance.save.PhaseNum;
        saveData.saveDays = ItemManager.Instance.save.Days;
        saveData.saveHungry = ItemManager.Instance.save.HungryCount;
        saveData.saveisSaved = ItemManager.Instance.save.isSaved;

        // 인벤토리 정보 저장
        for (int i = 0; i < ItemManager.Instance.ItemList.Count; i++)
        {
            saveData.itemCounts.Add(ItemManager.Instance.ItemList[i].count);
        }

        // 최종 전체 저장
        string json = JsonUtility.ToJson(saveData); // 제이슨화

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);
    }
}
