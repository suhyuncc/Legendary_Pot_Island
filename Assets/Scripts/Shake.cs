using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            this.gameObject.GetComponent<Image>().color= new Color(1,1,1,0);
            yield return new WaitForSeconds(0.3f);
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.3f);
/*            this.gameObject.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(0.3f);
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Space!!!";
            yield return new WaitForSeconds(0.3f);*/
        }
    }
}
