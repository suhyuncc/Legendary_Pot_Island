using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fish;
    public GameObject fruit;

    void Start()
    {
        makeItem();
        makefruit();
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

    void makefruit()
    {
        int ItemCount = Random.Range(10, 20);
        //과일섬
        for (int i = 0; i < ItemCount; i++)
        {
            int xPos = Random.Range(55, 95);
            int yPos = Random.Range(20, 40);
            Instantiate(fruit, new Vector3(xPos, yPos, 0), fruit.transform.rotation);
        }
    }
}
