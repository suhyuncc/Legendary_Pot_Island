using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public List<Item> ItemList = new List<Item>();

    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

}
