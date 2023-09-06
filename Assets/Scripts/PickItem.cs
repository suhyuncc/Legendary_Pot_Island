using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public Item item;

    public bool isPicked = false;

    private void OnDestroy()
    {
        if(isPicked)
        {
            item.count++;
            isPicked = false;
        }
    }

    private void OnDisable()
    {
        if (isPicked)
        {
            item.count++;
            isPicked = false;
        }
    }
}
