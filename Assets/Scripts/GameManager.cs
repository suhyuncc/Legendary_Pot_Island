using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private SaveData save;

    public AudioClip[] clips;

    public int day;
    public int phase;

    private bool isActive;
    private bool CookActive;

    public GameObject Inventroy;
    public GameObject Ingredient;
    public GameObject Cook;
    
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI phaseText;

    public AudioSource audio;

    public GameObject ItemPanel;
    public TextMeshProUGUI ItemTitle;
    public TextMeshProUGUI ItemDescription;
    public Image ItemImage;

    public GameObject FailCookPanel;

    public Item eatenItem;

    public int TempHp;

    private void Awake()
    {
        instance = this;
        day = save.Days;
        phase = save.PhaseNum;
    }

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;

        
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
                audio.clip = clips[0];
                audio.pitch = 1.3f;
                audio.Play();
            }
            else
            {
                Inventroy.SetActive(false);
                isActive = false;
                audio.clip = clips[0];
                audio.pitch = 1f;
                audio.Play();
            }
        }

        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!CookActive)
                {
                    Ingredient.SetActive(false);
                    Cook.SetActive(true);
                    CookActive = true;
                }
                else
                {
                    Ingredient.SetActive(true);
                    Cook.SetActive(false);
                    CookActive = false;
                }
                
            }
        }

        dayText.text = $"Day {day}";
        phaseText.text = $"Phase {phase}";

        save.Days = day;
        save.PhaseNum = phase;

        if (phase == 5)
        {
            SceneManager.LoadScene("GoodEnding");
        }
    }

    public void Eat()
    {

        if(Hungry.instance.HungryCount - TempHp < 0)
        {
            Hungry.instance.HungryCount = 0;
            Hungry.instance.EatChecking();
            eatenItem.count--;
        }
        else
        {
            Hungry.instance.HungryCount -= TempHp;
            Hungry.instance.EatChecking();
            eatenItem.count--;

        }

        CookingPot.instance.isCooking = false;
        ItemPanel.SetActive(false);
    }

    public void NoEat()
    {
        CookingPot.instance.isCooking = false;
        eatenItem = null;
        ItemPanel.SetActive(false);
    }

    public void CloseFailCookPanel()
    {
        CookingPot.instance.isCooking = false;
        FailCookPanel.SetActive(false);
    }

}
