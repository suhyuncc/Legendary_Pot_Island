using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Cooking : MonoBehaviour
{
    public static Cooking instance;

    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Sprite[] sprites;

    public int ImageNum;
    public bool isClick;

    private Item Cooked;

    public Item SelectedItem;
    public int selectedCount;
    public List<string> SelectList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isClick = false;
        for(int i  = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    
    }


    // Update is called once per frame
    void Update()
    {
        if(isClick)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (!images[i].gameObject.activeSelf)
                {
                    //images[i].sprite = sprites[ImageNum];
                    images[i].sprite = SelectedItem.image;
                    images[i].gameObject.SetActive(true);

                    break;
                }
            }

            //ImageNum = 0;
            isClick = false;
        }
    }

    public void CancelBtn()
    {
        CookingPot.instance.CookingPanel.SetActive(false);

        SelectList.Clear();

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].gameObject.activeSelf)
            {
                Cooked = ItemManager.Instance.ItemList.Find(x => x.name == images[i].sprite.name);
                Cooked.count++;
            }
            images[i].gameObject.SetActive(false);
        }

        CookingPot.instance.isCooking = false;
        //요리를 취소한 후 인벤토리 재료/요리들을 누르면 설명이 뜨지 않고 개수가 소모되는 버그 수정
        selectedCount = 0;

    }

    public void CookingBtn()
    {
        Player.Instance.moveSpeed = 10;

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].gameObject.activeSelf == true)
            {
                SelectList.Add(images[i].sprite.name);
            }
        }

        //아이템 얻는건 count++로 얻기

        if (SelectList.Contains("쌀") && SelectList.Contains("소금") && SelectList.Contains("수박") && SelectList.Contains("참치"))
        {
            Cooked = Cookeditem("수박 참치 초밥");
        }
        else if (SelectList.Contains("쌀") && SelectList.Contains("소금") && SelectList.Contains("양송이 버섯") && SelectList.Contains("새송이 버섯") && SelectList.Contains("목이 버섯"))
        {
            Cooked = Cookeditem("버섯 수프");
        }
        else if (SelectList.Contains("밀") && SelectList.Contains("소금") && SelectList.Contains("참치"))
        {
            Cooked = Cookeditem("참치파이");
        }
        else if (SelectList.Contains("고등어") && SelectList.Contains("연어") && SelectList.Contains("참치"))
        {
            Cooked = Cookeditem("물고기 한상");
        }
        else if(SelectList.Contains("꿀")&&SelectList.Contains("사과") && (SelectList.Contains("레몬")|| SelectList.Contains("복숭아")|| SelectList.Contains("딸기") || SelectList.Contains("수박")))
        {
            Cooked = Cookeditem("과일 조림");
        }else if (SelectList.Contains("꿀") && SelectList.Contains("레몬") && (SelectList.Contains("복숭아") || SelectList.Contains("딸기") || SelectList.Contains("수박")))
        {
                Cooked = Cookeditem("과일 조림");
        }
        else if (SelectList.Contains("꿀") && SelectList.Contains("복숭아") && (SelectList.Contains("딸기") || SelectList.Contains("수박")))
        {
                Cooked = Cookeditem("과일 조림");
        }
        else if (SelectList.Contains("꿀") && SelectList.Contains("딸기") && SelectList.Contains("수박"))
        {
                Cooked = Cookeditem("과일 조림");
        }
        else if (SelectList.Contains("양송이 버섯") && SelectList.Contains("새송이 버섯") && SelectList.Contains("목이 버섯"))
        {
            Cooked = Cookeditem("버섯 전골");
        }
        else if (SelectList.Contains("고등어")&& SelectList.Contains("쌀"))
        {
            Cooked = Cookeditem("고등어 초밥");
        }
        else if (SelectList.Contains("연어")&& SelectList.Contains("쌀"))
        {
            Cooked = Cookeditem("연어초밥");
        }
        else if (SelectList.Contains("참치")&& SelectList.Contains("쌀"))
        {
            Cooked = Cookeditem("참치 초밥");
        }
        else if (SelectList.Contains("고등어") && SelectList.Contains("소금"))
        {
            Cooked = Cookeditem("소금 고등어 구이");
        }
        else if (SelectList.Contains("연어") && SelectList.Contains("소금"))
        {
            Cooked = Cookeditem("소금 연어구이");
        }
        else if (SelectList.Contains("참치") && SelectList.Contains("소금"))
        {
            Cooked = Cookeditem("소금 참치구이");
        }
        else if (SelectList.Contains("밀") && SelectList.Contains("소금"))
        {
            Cooked = Cookeditem("빵");
        }
        else if (SelectList.Contains("고등어"))
        {
            Cooked = Cookeditem("고등어구이"); //띄어쓰기 주의;
        }
        else if (SelectList.Contains("연어"))
        {
            Cooked = Cookeditem("연어구이");
        }
        else if (SelectList.Contains("참치"))
        {
            Cooked = Cookeditem("참치구이");
        }
        else if (SelectList.Contains("사과"))
        {
            Cooked = Cookeditem("구운 사과");
        }
        else if (SelectList.Contains("레몬"))
        {
            Cooked = Cookeditem("구운 레몬");
        }
        else if (SelectList.Contains("딸기"))
        {
            Cooked = Cookeditem("구운 딸기");
        }
        else if (SelectList.Contains("복숭아"))
        {
            Cooked = Cookeditem("구운 복숭아");
        }
        else if (SelectList.Contains("양송이 버섯") || SelectList.Contains("새송이 버섯") || SelectList.Contains("목이버섯"))
        {
            Cooked = Cookeditem("버섯 구이");
        }
        else
        {
            Cooked = null;
            GameManager.instance.FailCookPanel.SetActive(true);
        }


        //요리 끝!
        if (Cooked != null) {
            GameManager.instance.audio.clip = GameManager.instance.clips[1];
            GameManager.instance.audio.Play();
            //완성한 요리 설명 띄우기
            GameManager.instance.ItemPanel.SetActive(true);
            GameManager.instance.ItemTitle.text = $"{Cooked.Name}";
            GameManager.instance.ItemDescription.text = $"{Cooked.description}";
            GameManager.instance.ItemImage.GetComponent<Image>().sprite = Cooked.image;
            
        }
        
        CookingPot.instance.CookingPanel.SetActive(false);

        SelectList.Clear();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

        CookingPot.instance.isCooking = false;
        //요리를 취소한 후 인벤토리 재료/요리들을 누르면 설명이 뜨지 않고 개수가 소모되는 버그 수정

        selectedCount = 0;

    }

    public Item Cookeditem(string itemName)
    { 
        Cooked =ItemManager.Instance.ItemList.Find(x => x.name == itemName);
        Cooked.count++;
        return Cooked;
    }
}
