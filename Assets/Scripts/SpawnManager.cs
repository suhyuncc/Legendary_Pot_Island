using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public Transform Fishpool;
    public GameObject fishprefab;
    private GameObject[] Fishprefabs;
    public GameObject fruit;

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        Fishprefabs = new GameObject[50];
        Init();
        GetObject(30);
    }

    void Update()
    {
        
    }

    void Init()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject Object = Instantiate(fishprefab);
            Object.transform.SetParent(Fishpool);
            Object.SetActive(false);
            Fishprefabs[i] = Object;
        }
    }

    void GetObject(int max)
    {
        for (int i = 0; i < max; i++)
        {
            FishSpawn(Fishprefabs[i]);
        }
    }

    void ReturnObject(int max)
    {
        for (int i = 0; i < max; i++)
        {
            if (Fishprefabs[i].activeSelf)
            {
                Fishprefabs[i].SetActive(false);
            }
        }
    }

    void makeItem()
    {
        //int ItemCount = Random.Range(10, 30);
        //서쪽 바다
        for (int i = 0; i < 50; i++)
        {
            //int xPos = Random.Range(-20, -80);
            //int yPos = Random.Range(-50, 50);
            Fishprefabs[i] = Instantiate(fishprefab);
            Fishprefabs[i].SetActive(false);
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

    public void Respawn()
    {
        ReturnObject(30);
        GetObject(30);
    }

    public void FishSpawn(GameObject gameObject)
    {
        int xPos = Random.Range(-90, 90);
        int yPos = Random.Range(-55, 55);
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(xPos, yPos, 0);
    }

}
