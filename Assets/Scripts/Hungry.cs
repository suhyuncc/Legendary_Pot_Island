using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hungry : MonoBehaviour
{
    public static Hungry instance;

    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Sprite[] Sprites;
    [SerializeField]
    private SaveData save;

    public int HungryCount;

    public float Maxtime = 60f;
    public float curtime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        HungryCount = save.HungryCount;
        InitHungry(HungryCount);
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;

        if (curtime > Maxtime)
        {
            curtime = 0f;
            Checking();
            HungryCount++;
            save.HungryCount = HungryCount;
        }


    }

    public void Checking()
    {
        if (HungryCount >= 20)
        {
            SceneManager.LoadScene("BadEnding");
        }
        else
        {
            if (HungryCount % 2 == 0 || HungryCount == 0)
            {
                images[HungryCount / 2].sprite = Sprites[1];
            }
            else
            {
                images[HungryCount / 2].gameObject.SetActive(false);
            }
        }


    }

    public void EatChecking()
    {
       
        for(int i= 20; i > HungryCount; i--)
        {
            if (i % 2 != 0)
            {
                images[i / 2].gameObject.SetActive(true);
                images[i / 2].sprite = Sprites[0];
            }
            
        }

        if (HungryCount % 2 != 0)
        {
            images[HungryCount / 2].gameObject.SetActive(true);
            images[HungryCount / 2].sprite = Sprites[1];
        }
        else
        {
            images[HungryCount / 2].gameObject.SetActive(true);
            images[HungryCount / 2].sprite = Sprites[0];
        }

    }

    private void InitHungry(int hungrycount) 
    {
        for (int i = 0; i < HungryCount; i++)
        {
            if (i % 2 == 0 || i == 0)
            {
                images[i / 2].sprite = Sprites[1];
            }
            else
            {
                images[i / 2].gameObject.SetActive(false);
            }
        }
    }
}
