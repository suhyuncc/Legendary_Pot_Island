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
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[GameManager.instance.phase - 1];
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);

        if (distance < 11)
        {

            if (!isFeeding && !Player.Instance.isSwimming)
            {
                spaceFeed.gameObject.SetActive(true);
            }

            if (!isFeeding && Input.GetKeyDown(KeyCode.Space) && !Player.Instance.isSwimming)
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

    IEnumerator EatingMotion()
    {
        Debug.Log("모션 함수 실행");
        Player.Instance.moveSpeed = 0;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = EatingSprites[GameManager.instance.phase-1];
        GameManager.instance.audio.clip = GameManager.instance.clips[3];
        GameManager.instance.audio.Play();
        yield return new WaitForSeconds(1f);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = EndEatingSprites[GameManager.instance.phase-1];
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[GameManager.instance.phase - 1];
        yield return new WaitForSeconds(1f);


        UpgradePhase();
        if(GameManager.instance.phase < 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[GameManager.instance.phase - 1];
        }
        

        isFeeding = false;
        yield return new WaitForSeconds(1f);
        Player.Instance.moveSpeed = 10;

    }
    public void Feeding()
    {
        CafeteriaPanel.SetActive(false);
        StartCoroutine(EatingMotion());
        
    }

    public void UpgradePhase()
    {
        GameManager.instance.phase++;
    }
}
