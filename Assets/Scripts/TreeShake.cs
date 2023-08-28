using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    public GameObject[] leaf = new GameObject[3];
    public GameObject[] fruit = new GameObject[3];

    private Vector3[] originPos = new Vector3[3];
    private GameObject playerObject;

    private bool isShaked = false;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        for (int i = 0; i < 3; i++)
        {
            fruit[i].GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    void Update()
    {
               
        if (isShaked == false && Input.GetKeyDown(KeyCode.Space))
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            if (distance < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    fruit[i].GetComponent<CircleCollider2D>().enabled = true;
                }
                StartCoroutine(Shake());
                isShaked = true;
            }
            else
            {
                Debug.Log("가깝지 않아서 나무 흔들기 불가");
            }
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
                fruit[i].transform.position = new Vector3(fruit[i].transform.position.x, fruit[i].transform.position.y - 0.2f, 0);
            yield return null;
        }
    }
}

