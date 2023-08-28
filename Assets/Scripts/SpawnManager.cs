using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fish;

    void Start()
    {
        makeItem();
    }

    void Update()
    {
        
    }

    void makeItem()
    {
        int ItemCount = Random.Range(10, 30);
        //서쪽 바다
        for (int i = 0; i < ItemCount; i++)
        {
            int xPos = Random.Range(-20, -80);
            int yPos = Random.Range(-50, 50);
            Instantiate(fish, new Vector3(xPos, yPos, 0), fish.transform.rotation);
        }
    }
}
