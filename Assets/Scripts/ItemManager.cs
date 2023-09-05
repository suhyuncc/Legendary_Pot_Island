using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();

    public static ItemManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

}
