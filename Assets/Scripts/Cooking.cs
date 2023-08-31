using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class Cooking : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    //private Item[] Cookeditem = new Item[23];

    public int ImageNum;
    public bool isClick;

    private Item Cooked;

    public Item SelectedItem;
    List<string> SelectList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
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

    public void CookingBtn()
    {
        Player.Instance.moveSpeed = 10;

        Debug.Log("��ŷ��ư ����");
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].gameObject.activeSelf == true)
            {
                SelectList.Add(images[i].sprite.name);
            }
        }

        //������ ��°� count++�� ���

        if (SelectList.Contains("��") && SelectList.Contains("�ұ�") && SelectList.Contains("����") && SelectList.Contains("��ġ"))
        {
            Cooked = Cookeditem("���� ��ġ �ʹ�");
        }
        else if (SelectList.Contains("��") && SelectList.Contains("�ұ�") && SelectList.Contains("����� ����") && SelectList.Contains("������ ����") && SelectList.Contains("���� ����"))
        {
            Cooked = Cookeditem("���� ����");
        }
        else if (SelectList.Contains("��") && SelectList.Contains("�ұ�") && SelectList.Contains("��ġ"))
        {
            Cooked = Cookeditem("��ġ����");
        }
        else if (SelectList.Contains("����") && SelectList.Contains("����") && SelectList.Contains("��ġ"))
        {
            Cooked = Cookeditem("����� �ѻ�");
        }
        else if (SelectList.Contains("��"))
        {
            if(SelectList.Contains("���") && SelectList.Contains("����")|| SelectList.Contains("������")|| SelectList.Contains("����") || SelectList.Contains("����"))
            {
                Cooked = Cookeditem("���� ����");
            }else if (SelectList.Contains("����") && SelectList.Contains("������") || SelectList.Contains("����") || SelectList.Contains("����"))
            {
                Cooked = Cookeditem("���� ����");
            }
            else if (SelectList.Contains("������") && SelectList.Contains("����") || SelectList.Contains("����"))
            {
                Cooked = Cookeditem("���� ����");
            }
            else if (SelectList.Contains("����") && SelectList.Contains("����"))
            {
                Cooked = Cookeditem("���� ����");
            }
        }
        else if (SelectList.Contains("����� ����") && SelectList.Contains("������ ����") && SelectList.Contains("���� ����"))
        {
            Cooked = Cookeditem("���� ����");
        }
        else if (SelectList.Contains("����")&& SelectList.Contains("��"))
        {
            Cooked = Cookeditem("���� �ʹ�");
        }
        else if (SelectList.Contains("����")&& SelectList.Contains("��"))
        {
            Cooked = Cookeditem("�����ʹ�");
        }
        else if (SelectList.Contains("��ġ")&& SelectList.Contains("��"))
        {
            Cooked = Cookeditem("��ġ �ʹ�");
        }
        else if (SelectList.Contains("����") && SelectList.Contains("�ұ�"))
        {
            Cooked = Cookeditem("�ұ� ���� ����");
        }
        else if (SelectList.Contains("����") && SelectList.Contains("�ұ�"))
        {
            Cooked = Cookeditem("�ұ� �����");
        }
        else if (SelectList.Contains("��ġ") && SelectList.Contains("�ұ�"))
        {
            Cooked = Cookeditem("�ұ� ��ġ����");
        }
        else if (SelectList.Contains("��") && SelectList.Contains("�ұ�"))
        {
            Cooked = Cookeditem("��");
        }
        else if (SelectList.Contains("����"))
        {
            Cooked = Cookeditem("�����"); //���� ����;
            Debug.Log("�����");
        }
        else if (SelectList.Contains("����"))
        {
            Cooked = Cookeditem("�����");
        }
        else if (SelectList.Contains("��ġ"))
        {
            Cooked = Cookeditem("��ġ����");
            Debug.Log("��ġ���̰� �������");
        }
        else if (SelectList.Contains("���"))
        {
            Cooked = Cookeditem("���� ���");
            Debug.Log("���� ����� �������");
        }
        else if (SelectList.Contains("����"))
        {
            Cooked = Cookeditem("���� ����");
            Debug.Log(Cooked.Name);
        }
        else if (SelectList.Contains("����"))
        {
            Cooked = Cookeditem("���� ����");
        }
        else if (SelectList.Contains("������"))
        {
            Cooked = Cookeditem("���� ������");
        }
        else if (SelectList.Contains("����� ����") || SelectList.Contains("������ ����") || SelectList.Contains("���� ����"))
        {
            Cooked = Cookeditem("���� ����");
        }
        else
        {
            Cooked = null;
            Debug.Log("�丮�� �����ߴ�..");
        }


        //�丮 ��!
        if (Cooked != null) {
            //�ϼ��� �丮 ���� ����
            GameManager.instance.ItemPanel.SetActive(true);
            GameManager.instance.ItemTitle.text = $"{Cooked.Name}";
            GameManager.instance.ItemDescription.text = $"{Cooked.description}";
            GameManager.instance.ItemImage.GetComponent<Image>().sprite = Cooked.image;
        }
        
        CookingPot.instance.CookingPanel.SetActive(false);
        CookingPot.instance.isCooking = false;

        //Debug.Log(SelectList.Contains("����"));
        SelectList.Clear();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

    }

    public Item Cookeditem(string itemName)
    {
        Item Cooked = (Item)AssetDatabase.LoadAssetAtPath("Assets/Resorce/" + itemName + ".asset", typeof(Item));
        Cooked.count++;
        return Cooked;
    }
}
