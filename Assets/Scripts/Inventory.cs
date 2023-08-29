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
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(2).gameObject;
                myItem.gameObject.SetActive(true);

                Debug.Log("�����");
            }
            else if (item.name == "��")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(3).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("��");
            }
            else if (item.name == "����")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(0).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("����");
            }
            else if (item.name == "����")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(1).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("����");
            }
            else if (item.name == "���̹���")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(4).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("���̹���");
            }
            else if (item.name == "��")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(5).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("��");
            }
            else if (item.name == "������")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(6).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("������");
            }
            else if (item.name == "���")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(7).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("���");
            }
            else if (item.name == "������ ����")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(8).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("������ ����");
            }
            else if (item.name == "�ұ�")
            {
/*                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(2).gameObject;
                myItem.gameObject.SetActive(true);*/
                Debug.Log("�ұ��̹����� ����..");
            }
            else if (item.name == "����")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(9).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("����");
            }
            else if (item.name == "��")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(10).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("��");
            }
            else if (item.name == "����� ����")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(11).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("����� ����");
            }
            else if (item.name == "����")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(12).gameObject;

                myItem.gameObject.SetActive(true);
                Debug.Log("����");
            }
            else if (item.name == "��ġ")
            {
                GameObject myItem = selectedItemGroup[selectedCount].transform.GetChild(13).gameObject;
                myItem.gameObject.SetActive(true);
                Debug.Log("��ġ");
            }
            else
            {
                Debug.Log("item.name �߸���");
            }


        }
        //selectedCount++;

    }
}
