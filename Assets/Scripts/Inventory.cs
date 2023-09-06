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
    //Inventory ������ ������
    
    private Color orign;


    // Start is called before the first frame update
    void Start()
    {

        Item thisItem = (Item)AssetDatabase.LoadAssetAtPath("Assets/Resorce/" 
            + image.sprite.name + ".asset", typeof(Item));

/*        GameObject thisItem = Resources.Load<GameObject>(image.sprite.name);
        Item item = thisItem.GetComponent<Item>();
*/
        item = thisItem;
        //item.count = item.count + 10;
        //�׽�Ʈ �Ϸ��� ���� �ø��� �ڵ�~

        if (item == null)
        {
            Debug.Log("�����߻�");
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

        ClickItem();
    }
    void ClickItem()
    {
        if (Cafeteria.instance.isFeeding == false && CookingPot.instance.isCooking == false)
        {
            if(item.count != 0)
            {
                Debug.Log(item.name + "�� �����ߴ�. " + item.health + " "+item.description);
                GameManager.instance.ItemPanel.SetActive(true);
                GameManager.instance.ItemTitle.text = $"{item.Name}";
                GameManager.instance.ItemDescription.text = $"{item.description}";
                GameManager.instance.ItemImage.GetComponent<Image>().sprite= item.image;

                GameManager.instance.TempHp = item.health;

                GameManager.instance.eatenItem = item;
            }
            //�� ���� ��쿡 �κ��丮�� ��� �������� Ŭ������ ���
            
        }

        if (item.count != 0&& selectedCount<5&& CookingPot.instance.isCooking==true)
        {
            item.count--;
            SelectItem.GetComponent<Cooking>().SelectedItem = item;
            SelectItem.GetComponent<Cooking>().isClick = true;

            /*if (item.name == "����")
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
            }*/

        }

        if (item.count != 0&&Cafeteria.instance.isFeeding == true)
        {
            
            if (item.name == "���� ��ġ �ʹ�")
            {
                if (GameManager.instance.phase == 4)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "�̰ž�!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "�װ� �ƴϾ�!";
                }
            } 
            else if (item.name == "��ġ����")
            {
                if (GameManager.instance.phase == 2)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "�̰ž�!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "�װ� �ƴϾ�!";
                }
            }
            else if (item.name == "����� �ѻ�")
            {
                if(GameManager.instance.phase == 1)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "�̰ž�!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "�װ� �ƴϾ�!";
                }
            }
            else if (item.name == "���� ����")
            {
                if (GameManager.instance.phase == 3)
                {
                    item.count--;
                    CafeteriaPanel.instance.Cafeteria_text.text = "�̰ž�!";
                    CafeteriaPanel.instance.feed = true;
                }
                else
                {
                    CafeteriaPanel.instance.Cafeteria_text.text = "�װ� �ƴϾ�!";
                }
            }
            else
            {
                CafeteriaPanel.instance.Cafeteria_text.text = "�װ� �ƴϾ�!";
            }

            
        }

    }
}
