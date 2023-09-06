using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    //물고기
    public Transform Fishpool;
    public GameObject fishprefab;
    private GameObject[] Fishprefabs;

    //과일
    public Transform Fruitpool;
    public GameObject Appleprefab;
    public GameObject Stroprefab;
    public GameObject Lemonprefab;
    public GameObject Pichprefab;
    public GameObject Waterprefab;
    private GameObject[] Fruitprefabs;

    //버섯
    public Transform MushRoompool;
    public GameObject M1prefab;
    public GameObject M2prefab;
    public GameObject M3prefab;
    private GameObject[] MushRoomprefabs;

    public GameObject BrokenShipPrefab;
    private GameObject ShipPool;

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        Fishprefabs = new GameObject[50];
        Fruitprefabs = new GameObject[20];
        MushRoomprefabs = new GameObject[40];
        Init();
        GetObject(GameManager.instance.phase);
        
    }

    void Update()
    {
        
    }

    void Init()
    {
        ShipPool = Instantiate(BrokenShipPrefab);
        ShipPool.transform.SetParent(this.transform);
        ShipPool.SetActive(false);

        //물고기 초기 생성
        for (int i = 0; i < 50; i++)
        {
            GameObject Object = Instantiate(fishprefab);
            Object.transform.SetParent(Fishpool);
            Object.SetActive(false);
            Fishprefabs[i] = Object;
        }

        //과일 초기 생성
        for(int i = 0; i < 20; i++)
        {
            GameObject Object;
            if (i < 6)
            {
                Object = Instantiate(Appleprefab);
            }
            else if(i >= 6 && i < 12) 
            {
                Object = Instantiate(Stroprefab);
            }
            else if (i >= 12 && i < 16)
            {
                Object = Instantiate(Lemonprefab);
            }
            else if (i >= 16 && i < 19)
            {
                Object = Instantiate(Pichprefab);
            }
            else
            {
                Object = Instantiate(Waterprefab);
                
            }
            Object.transform.SetParent(Fruitpool);
            Object.SetActive(false);
            Fruitprefabs[i] = Object;
        }

        //버섯 초기 생성
        for (int i = 0; i < 40; i++)
        {
            GameObject Object;
            if (i < 12)
            {
                Object = Instantiate(M1prefab);
            }
            else if (i >= 12 && i < 24)
            {
                Object = Instantiate(M2prefab);
            }
            else
            {
                Object = Instantiate(M3prefab);
            }
            Object.transform.SetParent(MushRoompool);
            Object.SetActive(false);
            MushRoomprefabs[i] = Object;
        }
    }

    void GetObject(int phase)
    {
        int fish = 0;
        int fruit = 0;
        int mushroom = 0;
        switch (phase)
        {
            case 1:
                fish = 35;
                fruit = 6;
                mushroom = 25;
                break; 

            case 2:
                fish = 40;
                fruit = 8;
                mushroom = 30;
                break;

            case 3:
                fish = 45;
                fruit = 10;
                mushroom = 35;
                break;

            case 4:
                fish = 50;
                fruit = 12;
                mushroom = 40;
                break;
        }

        ShipSpawn();

        for (int i = 0; i < fish; i++)
        {
            FishSpawn(Fishprefabs[i]);
        }

        for (int i = 0; i < fruit; i++)
        {
            FruitSpawn();
        }

        for (int i = 0; i < mushroom; i++)
        {
            MushRoomSpawn();
        }

        Player.Instance.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    void ReturnObject()
    {
        ShipPool.SetActive(false);

        for (int i = 0; i < 50; i++)
        {
            if (Fishprefabs[i].activeSelf)
            {
                Fishprefabs[i].SetActive(false);
            }
        }

        for (int i = 0; i < 20; i++)
        {
            if (Fruitprefabs[i].activeSelf)
            {
                Fruitprefabs[i].SetActive(false);
            }
        }

        for (int i = 0; i < 40; i++)
        {
            if (MushRoomprefabs[i].activeSelf)
            {
                MushRoomprefabs[i].SetActive(false);
            }
        }
    }


    public void Respawn()
    {
        ReturnObject();
        GetObject(GameManager.instance.phase);
    }

    public void FishSpawn(GameObject gameObject)
    {
        int xPos = Random.Range(-90, 90);
        int yPos = Random.Range(-55, 55);
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(xPos, yPos, 0);
    }

    public void FruitSpawn()
    {
        int num = Random.Range(0, 20);
        if (Fruitprefabs[num].activeSelf)
        {
            FruitSpawn();
        }
        else
        {
            int xPos = Random.Range(65, 99);
            int yPos = Random.Range(22, 45);
            Fruitprefabs[num].SetActive(true);
            Fruitprefabs[num].transform.position = new Vector3(xPos, yPos, 0);
        }
        
    }

    public void MushRoomSpawn()
    {
        int num = Random.Range(0, 40);
        if (MushRoomprefabs[num].activeSelf)
        {
            MushRoomSpawn();
        }
        else
        {
            int xPos = Random.Range(-80, -50);
            int yPos = Random.Range(-43, -25);
            MushRoomprefabs[num].SetActive(true);
            MushRoomprefabs[num].transform.position = new Vector3(xPos, yPos, 0);
        }
    }

    public void ShipSpawn()
    {
        int spawn = Random.Range(0, 10);
        if(spawn < 3)
        {
            int area = Random.Range(0, 2);
            if (area == 0)
            {
                int xPos = Random.Range(95, 105);
                int yPos = Random.Range(-55, -45);
                ShipPool.SetActive(true);
                ShipPool.transform.position = new Vector3(xPos, yPos, 0);
            }
            else
            {
                int xPos = Random.Range(-85, -75);
                int yPos = Random.Range(45, 55);
                ShipPool.SetActive(true);
                ShipPool.transform.position = new Vector3(xPos, yPos, 0);
            }
        }
    }
}
