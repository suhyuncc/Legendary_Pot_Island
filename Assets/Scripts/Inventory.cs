using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI Tcount;

    public GameObject[] selectedItemGroup = new GameObject[5];
    private int selectedCount = 0;
    //Inventory 밖으로 빼야함

    private Color orign;

    // Start is called before the first frame update
    void Start()
    {
        orign = new Color(image.color.r, image.color.g, image.color.b, 1);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
        CheckingItem();

        
    }

    // Update is called once per frame
    void Update()
    {
        CheckingItem();

    }

    void CheckingItem()
    {
        if(item.count > 0)
        {
            image.color = orign;
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
        }

        Tcount.text = $"X{item.count}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        ClickItem();
    }
    void ClickItem()
    {
        //Debug.Log(item.name);
        if (item.count != 0&& selectedCount<5)
        {
            item.count--;
            
            if (item.name == "고등어")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(2).gameObject;
                myItem.gameObject.SetActive(true);

                Debug.Log("고등어예요");
            }
            else if (item.name == "꿀")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(3).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("꿀");
            }
            else if (item.name == "딸기")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(0).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("딸기");
            }
            else if (item.name == "레몬")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(1).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("레몬");
            }
            else if (item.name == "목이버섯")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(4).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("목이버섯");
            }
            else if (item.name == "밀")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(5).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("밀");
            }
            else if (item.name == "복숭아")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(6).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("복숭아");
            }
            else if (item.name == "사과")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(7).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("사과");
            }
            else if (item.name == "새송이 버섯")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(8).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("새송이 버섯");
            }
            else if (item.name == "소금")
            {
/*                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(2).gameObject;
                myItem.gameObject.SetActive(true);*/
                Debug.Log("소금이미지가 없다..");
            }
            else if (item.name == "수박")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(9).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("수박");
            }
            else if (item.name == "쌀")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(10).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("쌀");
            }
            else if (item.name == "양송이 버섯")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(11).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("양송이 버섯");
            }
            else if (item.name == "연어")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(12).gameObject;

                myItem.gameObject.SetActive(true);
                Debug.Log("연어");
            }
            else if (item.name == "참치")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(13).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("참치");
            }
            else
            {
                Debug.Log("item.name 잘못됨");
            }


        }
        //selectedCount++;

    }
}
