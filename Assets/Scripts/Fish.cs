using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fish : MonoBehaviour
{
    
    public Item[] item = new Item[3];
    public bool isCatched = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Sea"))
        {
            SpawnManager.instance.FishSpawn(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (isCatched)
        {
            int random= Random.Range(0, 9);

            if(random < 3)
            {
                FishingGame.instance.Fishindex = 1;
                item[1].count++;
            }
            else if(random >= 3 && random < 9) 
            {
                FishingGame.instance.Fishindex = 0;
                item[0].count++;
            }
            else
            {
                FishingGame.instance.Fishindex = 2;
                item[2].count++;
            }
            isCatched = false;
        }
    }
}
