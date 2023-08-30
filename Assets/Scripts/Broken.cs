using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Broken : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private Item item;
    [SerializeField]
    private int Num;

    public void OnPointerClick(PointerEventData eventData)
    {
        item.count += Num;
        this.gameObject.SetActive(false);
    }
    
    public void OnButton()
    {
        for(int i  = 0; i < images.Length; i++)
        {
            images[i].SetActive(true);
        }

        Boat.instance.boatSpeed = 6;
        Panel.SetActive(false);
    }
}
