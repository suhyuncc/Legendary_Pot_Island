using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CafeteriaPanel : MonoBehaviour
{
    public static CafeteriaPanel instance;

    [SerializeField]
    private Sprite[] Cafeteria_Images;
    [SerializeField] 
    private Image Cafeteria_Image;
    [SerializeField]
    private Sprite[] Foods;
    [SerializeField]
    private Image Food;

    private Color Alpha;
    private Item item;

    public bool feed;
    public TextMeshProUGUI Cafeteria_text;

    private void OnEnable()
    {
        instance = this;

        feed = false;

        Init(GameManager.instance.phase);

        Item thisItem = (Item)AssetDatabase.LoadAssetAtPath("Assets/Resorce/"
            + Food.sprite.name + ".asset", typeof(Item));

        item = thisItem;

        Alpha = new Color(Food.color.r, Food.color.g, Food.color.b, 0.3f);

        Cafeteria_text.text = "π‰ ¡‡!!";
    }

    // Update is called once per frame
    void Update()
    {
        if (feed)
        {
            Food.color = new Color(Food.color.r, Food.color.g, Food.color.b, 1f);
        }
        else
        {
            Food.color = Alpha;
        }
    }

    public void OnFeed()
    {
        Cafeteria.instance.Feeding();
        this.gameObject.SetActive(false);
        feed = false;
    }

    public void OnCancel()
    {
        this.gameObject.SetActive(false);
        Cafeteria.instance.isFeeding = false;

        if(feed)
        {
            item.count++;
            feed = false;
        }
    }
    
    void Init(int i)
    {
        Cafeteria_Image.sprite = Cafeteria_Images[i - 1];
        Food.sprite = Foods[i - 1];
    }
}
