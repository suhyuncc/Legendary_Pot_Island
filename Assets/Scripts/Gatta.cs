using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Gatta : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Gatcha;

    private Color orign_Co;
    private Vector3 orign_Vec;

    private void Awake()
    {
        orign_Co = Gatcha.color;
        orign_Vec = this.transform.position;
    }

    private void OnEnable()
    {
        Gatcha.color = orign_Co;
        this.transform.position = orign_Vec;
        StartCoroutine("Get");
    }

    IEnumerator Get()
    {
        float F_time = 1f;
        float time = 0f;

        Color alpha = Gatcha.color;
        Vector3 up = this.transform.position;

        while (alpha.a > 0)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            up.y = Mathf.Lerp(810, 830, time);
            Gatcha.color = alpha;
            this.transform.position = up;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
