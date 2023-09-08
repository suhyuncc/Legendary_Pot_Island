using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Broken : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private Item item;
    [SerializeField]
    private TextMeshProUGUI Tcount;

    public GameObject gettingPool;

    public int Num;

    private void OnEnable()
    {
        switch (item.name)
        {
            case "밀":
                Num = Random.Range(1, 7);
                break;
            case "쌀":
                Num = Random.Range(1, 5);
                break;
            case "소금":
                Num = Random.Range(1, 3);
                break;
        }
        
    }

    void Update()
    {
        Tcount.text = $"X{Num}";

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        item.count += Num;
        for (int i = 0; i < gettingPool.transform.childCount; i++)
        {
            if (!gettingPool.transform.GetChild(i).gameObject.activeSelf)
            {
                gettingPool.transform.GetChild(i).gameObject.SetActive(true);
                gettingPool.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text
                    = $"{item.name}을 획득하였습니다!!";
                break;
            }
        }
        this.gameObject.SetActive(false);
    }
    
    public void OnButton()
    {
        for(int i  = 0; i < images.Length; i++)
        {
            images[i].SetActive(true);
        }

        Boat.instance.boatSpeed = 6;
        Panel.SetActive(false);
    }
}
