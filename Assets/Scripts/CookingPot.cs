using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookingPot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text_cook;
    [SerializeField]


    //public TextMeshProUGUI text_cook;


    private bool isCooking = false;

    private GameObject playerObject;

    public GameObject CookingPanel;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isCooking)
        {
        }
        else
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            
            if (distance < 3)
            {
                if (!isCooking)
                {
                    text_cook.gameObject.SetActive(true);
                }

                if (!isCooking && Input.GetKeyDown(KeyCode.Space))
                {
                    // ��ŷ ����!

                    isCooking = true;
                    Cooking();
                    text_cook.gameObject.SetActive(false);
                }
            }
            else
            {
                text_cook.gameObject.SetActive(false);
            }
        }
    }

    void Cooking()
    {
        CookingPanel.SetActive(true);

    }
}