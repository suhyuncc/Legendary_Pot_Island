using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cafeteria : MonoBehaviour
{
    public static Cafeteria instance;

    private GameObject playerObject;
    public bool isFeeding=false;

    [SerializeField]
    private Image spaceFeed;

    [SerializeField]
    private TextMeshProUGUI text_feed;
    [SerializeField]
    private Sprite[] Sprites;
    [SerializeField]
    private Sprite[] EatingSprites;
    [SerializeField]
    private Sprite[] EndEatingSprites;

    public GameObject CafeteriaPanel;

    void Start()
    {
        instance = this;
        playerObject = GameObject.FindWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {

        if (isFeeding && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)))
        {
            CafeteriaPanel.SetActive(false);
            isFeeding = false;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            
            if (distance < 11)
            {

                if (!isFeeding)
                {
                    spaceFeed.gameObject.SetActive(true);
                }

                if (!isFeeding && Input.GetKeyDown(KeyCode.Space))
                {
                    // 쿠킹 시작!

                    isFeeding = true;
                    CafeteriaPanel.SetActive(true);
                    spaceFeed.gameObject.SetActive(false);
                }
            }
            else
            {
                spaceFeed.gameObject.SetActive(false);
            }
        }
        
    }

    IEnumerator EatingMotion()
    {
        Debug.Log("모션 함수 실행");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = EatingSprites[GameManager.instance.phase-1];

        yield return new WaitForSeconds(1f);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = EndEatingSprites[GameManager.instance.phase-1];
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[GameManager.instance.phase - 1];
        yield return new WaitForSeconds(2f);


        UpgradePhase();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[GameManager.instance.phase - 1];

        isFeeding = false;
        yield return new WaitForSeconds(2f);

    }
    public void Feeding()
    {
        Debug.Log("Feeding 함수 실행");
        CafeteriaPanel.SetActive(false);
        StartCoroutine(EatingMotion());
        //CafeteriaPanel.SetActive(true);
        
    }

    public void UpgradePhase()
    {
        GameManager.instance.phase++;
        Debug.Log("업그레이드됨");
    }
}
