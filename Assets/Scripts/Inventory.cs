using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI Tcount;

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
            Tcount.gameObject.SetActive(true);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
        }

        Tcount.text = $"X{item.count}";
    }
}
