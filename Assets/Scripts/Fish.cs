using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Item item;

    private void OnDestroy()
    {
        if (FishingGame.instance.isSuccess)
        {
            item.count++;
            FishingGame.instance.isSuccess = false;
        }
    }
}
