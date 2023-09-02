using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookingPot : MonoBehaviour
{
    public static CookingPot instance;

    [SerializeField]
    private TextMeshProUGUI text_cook;
    [SerializeField]
    private Image spaceCook;


    public bool isCooking = false;

    private GameObject playerObject;

    public GameObject CookingPanel;
    private bool isBlink;
    void Start()
    {
        instance = this;
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isCooking&&(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Escape)))
        {
            CookingPanel.SetActive(false);
            isCooking = false;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            
            if (distance < 3)
            {
                if (!isCooking)
                {
                   spaceCook.gameObject.SetActive(true);
                }

                if (!isCooking && Input.GetKeyDown(KeyCode.Space))
                {
                    // ÄíÅ· ½ÃÀÛ!

                    isCooking = true;
                    Cooking();
                    spaceCook.gameObject.SetActive(false);
                }
            }
            else
            {
                spaceCook.gameObject.SetActive(false);
            }
        }
    }

    void Cooking()
    {
        CookingPanel.SetActive(true);

    }

}
