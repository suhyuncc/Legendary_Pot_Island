using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hungry : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Sprite[] Sprites;
    [SerializeField]
    private SaveData save;

    private int HungryCount;

    public float Maxtime = 120f;
    public float curtime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        HungryCount = 0;
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

    void Checking()
    {
        if(HungryCount % 2 == 0) 
        {
            images[HungryCount / 2].sprite = Sprites[1];
        }
        else
        {
            images[HungryCount / 2].gameObject.SetActive(false);
        }
    }
}
