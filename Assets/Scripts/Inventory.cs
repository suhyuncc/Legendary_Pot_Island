using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;


public class Inventory : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI Tcount;
    [SerializeField]
    private GameObject SelectItem;

    private int selectedCount = 0;
    //Inventory 밖으로 빼야함
    
    private Color orign;


    // Start is called before the first frame update
    void Start()
    {
        item = ItemManager.Instance.ItemList.Find(x => x.name == image.sprite.name);
        //item.count = item.count + 10;
        //테스트 하려고 개수 늘리는 코드~

        if (item == null)
        {
            Debug.Log("오류발생");
            Debug.Log(image.sprite.name);
        }

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
        GameManager.instance.audio.clip = GameManager.instance.clips[2];
        GameManager.instance.audio.Play();
        ClickItem();
    }
    void ClickItem()
    {
        if (Cafeteria.instance.isFeeding == false && CookingPot.instance.isCooking == false)
        {
            if(item.count != 0)
            {
                Debug.Log(item.name + "를 선택했다. " + item.health + " "+item.description);
                GameManager.instance.ItemPanel.SetActive(true);
                GameManager.instance.ItemTitle.text = $"{item.Name}";
                GameManager.instance.ItemDescription.text = $"{item.description}";
                GameManager.instance.ItemImage.GetComponent<Image>().sprite= item.image;

                GameManager.instance.TempHp = item.health;

                GameManager.instance.eatenItem = item;
            }
            //그 외의 경우에 인벤토리를 열어서 아이템을 클릭했을 경우
            
        }

        if (item.count != 0&& selectedCount<5&& CookingPot.instance.isCooking==true)
        {
            item.count--;
            SelectItem.GetComponent<Cooking>().SelectedItem = item;
            SelectItem.GetComponent<Cooking>().isClick = true;

            /*if (item.name == "고등어")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 0;
                SelectItem.GetComponent<Cooking>().isClick = true;

                Debug.Log("고등어예요");
            }
            else if (item.name == "꿀")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 14;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("꿀");
            }
            else if (item.name == "딸기")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 5;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("딸기");
            }
            else if (item.name == "레몬")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 6;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("레몬");
            }
            else if (item.name == "목이버섯")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 10;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("목이버섯");
            }
            else if (item.name == "밀")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 12;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("밀");
            }
            else if (item.name == "복숭아")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 4;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("복숭아");
            }
            else if (item.name == "사과")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 3;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("사과");
            }
            else if (item.name == "새송이 버섯")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 9;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("새송이 버섯");
            }
            else if (item.name == "소금")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 13;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("소금이미지가 없다..");
            }
            else if (item.name == "수박")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 7;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("수박");
            }
            else if (item.name == "쌀")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 11;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("쌀");
            }
            else if (item.name == "양송이 버섯")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 8;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("양송이 버섯");
            }
            else if (item.name == "연어")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 1;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("연어");
            }
            else if (item.name == "참치")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 2;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("참치");
            }
            else
            {
                Debug.Log("item.name 잘못됨");
            }*/

        }

        if (item.count != 0&&Cafeteria.instance.isFeeding == true)
        {
            
            if (item.name == "수박 참치 초밥")
            {
                if (GameManager.instance.phase == 4)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "이거야!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "그게 아니야!";
                }
            } 
            else if (item.name == "참치파이")
            {
                if (GameManager.instance.phase == 2)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "이거야!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "그게 아니야!";
                }
            }
            else if (item.name == "물고기 한상")
            {
                if(GameManager.instance.phase == 1)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "이거야!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "그게 아니야!";
                }
            }
            else if (item.name == "버섯 수프")
            {
                if (GameManager.instance.phase == 3)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "이거야!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "그게 아니야!";
                }
            }
            else
            {
                CafeteriaPanel.instance.Cafeteria_text.text = "그게 아니야!";
            }

            
        }

    }
}
