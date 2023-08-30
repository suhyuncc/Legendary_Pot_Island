using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeShake : MonoBehaviour
{

    public GameObject[] leaf = new GameObject[3];
    public GameObject[] fruit = new GameObject[3];

    private Vector3[] originPos = new Vector3[3];
    private GameObject playerObject;

    [SerializeField] 
    private GameObject honey;

    private bool isShaked = false;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        for (int i = 0; i < 3; i++)
        {
            fruit[i].GetComponent<CircleCollider2D>().enabled = false;
        }

        int ran = Random.Range(0, 9);

        if(ran < 3) 
        {
            honey.SetActive(true);
        }
    }
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !isShaked)
        {
            StartCoroutine(Shake());
            isShaked = true;
        }
    }



    IEnumerator Shake()
    {
        float time = 2f;
        float shakePower = 0.5f;

        for (int i = 0; i < 3; i++)
        {
            originPos[i] = leaf[i].transform.position;
        }
        while (time > 0f)
        {
            time -= 0.1f;
            for (int i = 0; i < 3; i++)
                leaf[i].transform.position = originPos[i] + (Vector3)Random.insideUnitCircle * shakePower * time;
            yield return null;
        }

        for (int i = 0; i < 3; i++)
            leaf[i].transform.position = originPos[i];
        StartCoroutine(Dropfruit());
    }

    IEnumerator Dropfruit()
    {
        float time = 2f;
        while (time > 0f)
        {
            time -= 0.1f;
            for (int i = 0; i < 3; i++)
            {
                fruit[i].transform.position = new Vector3(fruit[i].transform.position.x, fruit[i].transform.position.y - 0.2f, 0);
                
            }
            
            yield return null;
        }
        for (int i = 0; i < 3; i++)
        {
            fruit[i].GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}

