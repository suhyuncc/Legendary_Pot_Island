using System.Collections;
using System.Collections.Generic;
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
            int random= Random.Range(0, 3);
            item[random].count++;
            isCatched = false;
        }
    }
}
