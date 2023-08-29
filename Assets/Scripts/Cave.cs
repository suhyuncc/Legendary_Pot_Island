using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cave : MonoBehaviour
{
    [SerializeField]
    private GameObject CaveMessage;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawnManager;
    [SerializeField]
    private Image fade;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CaveMessage.SetActive(true);
        }
    }

    public void OnYes()
    {
        CaveMessage.SetActive(false);
        spawnManager.GetComponent<SpawnManager>().Respawn();
        StartCoroutine(Fade());
    }

    public void OnNo()
    {
        Player.Instance.moveSpeed = 10;
        CaveMessage.SetActive(false);
    }

    IEnumerator Fade()
    {
        float F_time = 1f;
        float time = 0f;

        fade.gameObject.SetActive(true);
        Color alpha = fade.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            fade.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3(0, 0, 0);
        Player.Instance.anim.SetBool("lookFront", true);
        Player.Instance.anim.SetBool("lookBack", false);
        Player.Instance.anim.SetBool("isWalking", false);

        while (alpha.a > 0)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            fade.color = alpha;
            yield return null;
        }

        Player.Instance.moveSpeed = 10;
        fade.gameObject.SetActive(false);
        yield return null;
    }
}
