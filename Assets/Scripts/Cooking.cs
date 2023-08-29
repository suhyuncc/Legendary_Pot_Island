using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Sprite[] sprites;
    public int ImageNum;
    public bool isClick;

    // Start is called before the first frame update
    void Start()
    {
        isClick = false;
        for(int i  = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isClick)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (!images[i].gameObject.activeSelf)
                {
                    images[i].sprite = sprites[ImageNum];
                    images[i].gameObject.SetActive(true);
                    break;
                }
            }

            ImageNum = 0;
            isClick = false;
        }
    }
}
