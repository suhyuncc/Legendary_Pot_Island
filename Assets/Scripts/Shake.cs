using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Coroutine coroutine;

    private void OnEnable()
    {
        coroutine = StartCoroutine(OnTextBlink());
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator OnTextBlink()
    {
        while (true)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(0.3f);
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Space!!";
            yield return new WaitForSeconds(0.3f);
        }
    }
}
