using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishingGame : MonoBehaviour
{
    public static FishingGame instance;

    [SerializeField]
    private RawImage image;
    [SerializeField]
    private Texture[] textures;

    private Coroutine coroutine;
    public bool sliderUp;
    public Slider slider;
    public int Fishindex;
    public GameObject gettingPool;

    private void Awake()
    {
        instance = this;
        
    }

    private void OnEnable()
    {
        Fishindex = 3;
        coroutine = StartCoroutine(Slider());
        image.texture = textures[0];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            image.texture = textures[1];
            StopCoroutine(coroutine);
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Boat.instance.boatSpeed = 6;
        Boat.instance.RayDestroy();
        Boat.instance.isFishing = false;
        FishGet(Fishindex);
    }

    IEnumerator Slider()
    {
        float speed = Random.Range(0.3f, 0.9f);

        slider.value = 0;
        sliderUp = true;
        while (true)
        {
            if (slider.value == 1)
            {
                sliderUp = false;
            }
            else if (slider.value == 0)
            {
                sliderUp = true;
            }

            if (sliderUp)
            {
                slider.value += speed * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                slider.value -= speed * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }

    private void FishGet(int index)
    {
        switch(index)
        {
            case 0:
                for (int i = 0; i < gettingPool.transform.childCount; i++)
                {
                    if (!gettingPool.transform.GetChild(i).gameObject.activeSelf)
                    {
                        gettingPool.transform.GetChild(i).gameObject.SetActive(true);
                        gettingPool.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text
                            = "고등어를 획득하였습니다!!";
                        break;
                    }
                }
                break;
            case 1:
                for (int i = 0; i < gettingPool.transform.childCount; i++)
                {
                    if (!gettingPool.transform.GetChild(i).gameObject.activeSelf)
                    {
                        gettingPool.transform.GetChild(i).gameObject.SetActive(true);
                        gettingPool.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text
                            = "연어를 획득하였습니다!!";
                        break;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < gettingPool.transform.childCount; i++)
                {
                    if (!gettingPool.transform.GetChild(i).gameObject.activeSelf)
                    {
                        gettingPool.transform.GetChild(i).gameObject.SetActive(true);
                        gettingPool.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text
                            = "참치를 획득하였습니다!!";
                        break;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < gettingPool.transform.childCount; i++)
                {
                    if (!gettingPool.transform.GetChild(i).gameObject.activeSelf)
                    {
                        gettingPool.transform.GetChild(i).gameObject.SetActive(true);
                        gettingPool.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text
                            = "놓쳤다!!";
                        break;
                    }
                }
                break;
        }
        Fishindex = 3;
    }
}
