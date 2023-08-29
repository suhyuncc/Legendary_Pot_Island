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
    [SerializeField]
    private GameObject SelectItem;

    private int selectedCount = 0;
    //Inventory ������ ������

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
            
            if (item.name == "����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 0;
                SelectItem.GetComponent<Cooking>().isClick = true;

                Debug.Log("�����");
            }
            else if (item.name == "��")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 14;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("��");
            }
            else if (item.name == "����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 5;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("����");
            }
            else if (item.name == "����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 6;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("����");
            }
            else if (item.name == "���̹���")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 10;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("���̹���");
            }
            else if (item.name == "��")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 12;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("��");
            }
            else if (item.name == "������")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 4;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("������");
            }
            else if (item.name == "���")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 3;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("���");
            }
            else if (item.name == "������ ����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 9;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("������ ����");
            }
            else if (item.name == "�ұ�")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 13;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("�ұ��̹����� ����..");
            }
            else if (item.name == "����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 7;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("����");
            }
            else if (item.name == "��")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 11;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("��");
            }
            else if (item.name == "����� ����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 8;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("����� ����");
            }
            else if (item.name == "����")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 1;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("����");
            }
            else if (item.name == "��ġ")
            {
                SelectItem.GetComponent<Cooking>().ImageNum = 2;
                SelectItem.GetComponent<Cooking>().isClick = true;
                Debug.Log("��ġ");
            }
            else
            {
                Debug.Log("item.name �߸���");
            }


        }

    }
}
