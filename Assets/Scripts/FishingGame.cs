using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
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
        Player.Instance.RayDestroy();
        Player.Instance.isFishing = false;
    }

    IEnumerator Slider()
    {
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
                slider.value += 0.3f * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                slider.value -= 0.3f * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}
