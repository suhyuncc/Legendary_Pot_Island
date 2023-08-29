using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private SaveData save;

    public int day;
    public int phase;

    private bool isActive;
    private bool CookActive;

    public GameObject Inventroy;
    public GameObject Ingredient;
    public GameObject Cook;
    
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI phaseText;

    public GameObject ItemPanel;
    public TextMeshProUGUI ItemTitle;
    public TextMeshProUGUI ItemDescription;
    public Image ItemImage;
    
    public int TempHp;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isActive = false;
        Debug.Log(Inventroy.activeSelf);
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
            }
            else
            {
                Inventroy.SetActive(false);
                isActive = false;
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
    }

    public void Eat()
    {

        if(Hungry.instance.HungryCount - TempHp < 0)
        {
            Hungry.instance.HungryCount = 0;
            Hungry.instance.EatChecking();
        }
        else
        {
            Hungry.instance.HungryCount -= TempHp;
            Hungry.instance.EatChecking();
        }
       
        ItemPanel.SetActive(false);
    }

    public void NoEat()
    {
        ItemPanel.SetActive(false);
    }
}
