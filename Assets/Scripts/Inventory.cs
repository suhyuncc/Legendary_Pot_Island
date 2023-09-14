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

        if (item.count != 0&& Cooking.instance.selectedCount < 5&& CookingPot.instance.isCooking==true)
        {
            Cooking.instance.selectedCount++;
            //5개 이상 시 아이템 클릭 안되게
            item.count--;
            SelectItem.GetComponent<Cooking>().SelectedItem = item;
            SelectItem.GetComponent<Cooking>().isClick = true;

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
